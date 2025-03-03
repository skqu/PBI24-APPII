using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;

class Program
{
    static string connectionString = "server=localhost;user=root;database=ecommerce;";
    
    static void Main()
    {
        Console.WriteLine("Do you want to upload CSV to database?" );
        string upload = Console.ReadLine();
        if (upload == "yes")
        {
            CreateDatabaseSchema();
            ImportCSV("users.csv", "InsertUser", new bool[] { false, true, true, true });
            ImportCSV("products.csv", "InsertProduct", new bool[] { false, true, false, false });
            ImportCSV("orders.csv", "InsertOrder", new bool[] { false, false, true, false });
            ImportCSV("order_items.csv", "InsertOrderItem", new bool[] { false, false, false, false, false });
            Console.WriteLine("Data Import Completed!");
        }else 
        {
            Console.WriteLine("Total amount for Order ID 1002: " + GetTotalOrderAmount(1001));
        }
    }

    static void CreateDatabaseSchema()
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string sql = @"
                CREATE DATABASE IF NOT EXISTS ecommerce;
                USE ecommerce;
                
                CREATE TABLE IF NOT EXISTS users (
                    user_id INT PRIMARY KEY,
                    name VARCHAR(255),
                    email VARCHAR(255) UNIQUE,
                    created_at DATETIME
                );
                
                CREATE TABLE IF NOT EXISTS products (
                    product_id INT PRIMARY KEY,
                    product_name VARCHAR(255),
                    price DECIMAL(10,2),
                    stock_quantity INT
                );
                
                CREATE TABLE IF NOT EXISTS orders (
                    order_id INT PRIMARY KEY,
                    user_id INT,
                    order_date DATE,
                    total_amount DECIMAL(10,2),
                    FOREIGN KEY (user_id) REFERENCES users(user_id)
                );
                
                CREATE TABLE IF NOT EXISTS order_items (
                    order_item_id INT PRIMARY KEY,
                    order_id INT,
                    product_id INT,
                    quantity INT,
                    subtotal DECIMAL(10,2),
                    FOREIGN KEY (order_id) REFERENCES orders(order_id),
                    FOREIGN KEY (product_id) REFERENCES products(product_id)
                );
                
                CREATE TABLE IF NOT EXISTS order_logs (
                    log_id INT AUTO_INCREMENT PRIMARY KEY,
                    order_id INT,
                    log_message TEXT,
                    log_timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );
                
                CREATE PROCEDURE IF NOT EXISTS InsertUser(IN u_id INT, IN u_name VARCHAR(255), IN u_email VARCHAR(255), IN u_created_at DATETIME)
                BEGIN
                    INSERT INTO users (user_id, name, email, created_at) VALUES (u_id, u_name, u_email, u_created_at);
                END;
                
                CREATE PROCEDURE IF NOT EXISTS InsertProduct(IN p_id INT, IN p_name VARCHAR(255), IN p_price DECIMAL(10,2), IN p_stock INT)
                BEGIN
                    INSERT INTO products (product_id, product_name, price, stock_quantity) VALUES (p_id, p_name, p_price, p_stock);
                END;
                
                CREATE PROCEDURE IF NOT EXISTS InsertOrder(IN o_id INT, IN u_id INT, IN o_date DATE, IN total DECIMAL(10,2))
                BEGIN
                    INSERT INTO orders (order_id, user_id, order_date, total_amount) VALUES (o_id, u_id, o_date, total);
                END;
                
                CREATE PROCEDURE IF NOT EXISTS InsertOrderItem(IN oi_id INT, IN o_id INT, IN p_id INT, IN qty INT, IN sub DECIMAL(10,2))
                BEGIN
                    INSERT INTO order_items (order_item_id, order_id, product_id, quantity, subtotal) VALUES (oi_id, o_id, p_id, qty, sub);
                END;
                
                CREATE FUNCTION IF NOT EXISTS GetTotalOrderAmount(o_id INT) RETURNS DECIMAL(10,2)
                BEGIN
                    DECLARE total DECIMAL(10,2);
                    SELECT SUM(subtotal) INTO total FROM order_items WHERE order_id = o_id;
                    RETURN total;
                END;
                
                CREATE TRIGGER IF NOT EXISTS AfterOrderInsert
                AFTER INSERT ON orders
                FOR EACH ROW
                BEGIN
                    INSERT INTO order_logs (order_id, log_message)
                    VALUES (NEW.order_id, CONCAT('New order placed with ID: ', NEW.order_id));
                END;
            ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Database Schema Created");
        }
    }

    static void ImportCSV(string filePath, string procedureName, bool[] isStringField)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); // Skip header line
                while (!reader.EndOfStream)
                {
                    string[] values = reader.ReadLine().Split(',');
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (isStringField[i])
                        {
                            values[i] = $"'{values[i].Replace("'", "''")}'"; // Escape single quotes
                        }
                    }
                    string query = $"CALL {procedureName}({string.Join(",", values)});";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
    static decimal GetTotalOrderAmount(int orderId)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = $"SELECT GetTotalOrderAmount({orderId})";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToDecimal(result) : 0;
        }
    }
}