
using System.Diagnostics;

class Program
{
    static void Main()
    {
        DataHandler dataHandler = new DataHandler();
        User admin = new User("skqu@iba.dk","secret", dataHandler);

        Rest api = new Rest([]);
        api.Build();
        api.get();
        api.run();
    }
}