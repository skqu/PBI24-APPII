// See https://aka.ms/new-console-template for more information
Console.Clear();


Singleton First = Singleton.getInstance;
Singleton Second = Singleton.getInstance;

Second.Set("This is the second one");
First.Set("This is the first one");
Console.WriteLine("The string from first instance of singleton: " + First.Get());


Console.WriteLine("Hit enter when ready for second instance output");
string temp = Console.ReadLine();

Console.WriteLine("The string from second instance of singleton: " + Second.Get());
Console.ReadLine();

Console.Clear();

/*
DBMS dbms = new DBMS();
bool run = true;
Config config = new Config { db = "default" };
Idb DbConn1 = dbms.Conn(config.db);
Idb DbConn2 = dbms.Conn(config.db);

while(run)
{

    Console.WriteLine("Welcome to tha database factory.");
    Console.WriteLine("Select a item in the following menu and hit enter:");
    Console.WriteLine("1: mysql");
    Console.WriteLine("2: postgres");
    Console.WriteLine("3: all");
    Console.WriteLine("4: exit");
    string input = Console.ReadLine();

    Console.Clear();
    switch (input)
    {
        case "1":
            config = new Config { db = "mysql" };
            DbConn1 = dbms.Conn(config.db);
            DbConn2 = dbms.Conn(config.db);
            break;

        case "2":
            config = new Config { db = "postgres" };
            DbConn1 = dbms.Conn(config.db);
            DbConn2 = dbms.Conn(config.db);

            break;

        case "3":
            Console.WriteLine("All configured databases:");
            var allDbs = dbms.Getdb(); 
            foreach (var db in allDbs)
            {
                var conn = dbms.Conn(db);
                if (conn != null)
                    Console.WriteLine($"Database {db}: {conn.Get()}");
                else
                    Console.WriteLine($"Database {db}: [Unavailable]");
            }
            break;

        case "4":
            Console.WriteLine("Closing the application...");
            run = false;
            break;

        default:
                Console.WriteLine("Are you stupid?");
                Console.WriteLine("You can choose 1,2,3 or 4");
            break;
    }

        // Only runs for cases 1 and 2
    if (DbConn1 == null || DbConn2 == null)
    {
        Console.WriteLine("An error occurred - check log for more details.");
    }
    else
    {
        Console.WriteLine("Database 1 is = " + DbConn1.Get());
        Console.WriteLine("Database 2 is = " + DbConn2.Get());
    }
}



class Config
{
    public string db { get; set; }
}
*/