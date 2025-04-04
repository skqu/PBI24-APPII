using System.Net.Http.Headers;

class Program 
{
    public static void Main(string[] args)
    {
        Singleton tmp1 = Singleton.GetInst;
        Singleton tmp2 = Singleton.GetInst;

        tmp2.SetString("Hello from 2");
        tmp1.SetString("Hello from 1");  

        Console.WriteLine(tmp2.GetString());
        Console.WriteLine(tmp1.GetString());

        bool run = true;

        Factory fac = new Factory();
        while (run)
        {
            Console.Clear();
            List<iProduct> products = new List<iProduct>();
            Console.WriteLine("Hello and welcome to the factory.");
            Console.WriteLine("Please select a option below");
            Console.WriteLine("1. Create Shirt");
            Console.WriteLine("2. Create Hat");
            Console.WriteLine("3. Create ALL");
            Console.WriteLine("4. Type a product");
            Console.WriteLine("5. Exist");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1": 
                    products.Add(fac.GetProduct("shirt"));
                    break;
                case "2": 
                    products.Add(fac.GetProduct("hat"));
                    break;
                case "3": 
                    products.Add(fac.GetProduct("hat"));
                    products.Add(fac.GetProduct("shirt"));
                    break;
                case "4":
                    string product = Console.ReadLine();
                    products.Add(fac.GetProduct(product));
                    break; 
                case "5":
                    run = false;
                    Console.WriteLine("Closing application ....");
                    break;
                default:
                    Console.WriteLine("Your idiot this is not an option");
                    
                    break;


            }
            foreach(iProduct product in products)
            {
                if (product == null)
                {
                    Console.WriteLine("Product unavailable");   
                }else
                {
                    Console.WriteLine(product.GetDesc());
                }
            }
            Console.WriteLine("Hit enter to select again");
            Console.ReadLine();
        
        }
    }
}

sealed class Singleton
{
    private static Singleton sngl = new Singleton();
    private string var = "";

    private Singleton()
    {

    }

    public static Singleton GetInst
    {
        get{
            return sngl;
        }
        
    }

    public void SetString(string str)
    {
        this.var = str;
    }

    public string GetString()
    {
        return this.var;
    }
}