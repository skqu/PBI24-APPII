
// dotnet add package MySql.Data
using MySql.Data.MySqlClient;

MySql.Data.MySqlClient.MySqlConnection conn = null;
string myConnectionString = "server=127.0.0.1;user=root; database=test";

try
{
    conn = new MySql.Data.MySqlClient.MySqlConnection();
    conn.ConnectionString = myConnectionString;
    conn.Open();
    string sql = "CREATE TABLE IF NOT EXISTS users (  id INT PRIMARY KEY AUTO_INCREMENT,    name VARCHAR(100) NOT NULL,    email VARCHAR(100) UNIQUE NOT NULL);";
    create(sql, conn);
    sql = "CREATE TABLE IF NOT EXISTS user_logs (     log_id INT PRIMARY KEY AUTO_INCREMENT,     user_id INT,   action VARCHAR(50),    log_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP);";
    create(sql,conn);

    sql = "CREATE FUNCTION IF NOT EXISTS insert_user(user_name VARCHAR(100), user_email VARCHAR(100)) RETURNS INT DETERMINISTIC BEGIN    DECLARE user_id INT;    IF EXISTS (SELECT 1 FROM users WHERE email = user_email) THEN  RETURN -1;    ELSE   INSERT INTO users (name, email) VALUES (user_name, user_email);  set user_id = LAST_INSERT_ID();  RETURN user_id; END IF; END;"; 
    create(sql, conn);


    sql = "CREATE TRIGGER IF NOT EXISTS after_user_insert  AFTER INSERT ON users FOR EACH ROW BEGIN    INSERT INTO user_logs (user_id, action)     VALUES (NEW.id, 'User Added'); END;";
    create(sql, conn);


    sql = "SELECT insert_user('John Doe', 'jane.doe@google.com');";
    create(sql,conn);
    
    sql = "SELECT * FROM user_logs;";
    MySqlCommand cmd = new MySqlCommand(sql, conn);
    MySqlDataReader rdr = cmd.ExecuteReader();

    while (rdr.Read())
    {
        Console.WriteLine(rdr[1]+" -- "+rdr[2] + " -- " + rdr[3]);
    }
    rdr.Close();



    conn.Close();    
    Console.WriteLine("Success");
}
catch (MySql.Data.MySqlClient.MySqlException ex)
{
    Console.WriteLine(ex.Message);
}


void create(string sql, MySql.Data.MySqlClient.MySqlConnection conn)
{
    MySqlCommand cmd = new MySqlCommand(sql, conn);
    cmd.ExecuteNonQuery();
}