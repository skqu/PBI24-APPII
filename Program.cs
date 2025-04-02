
using System.Diagnostics;

class Program
{
    static void Main()
    {
        DataHandler dataHandler = new DataHandler();
        User admin = new User("skqu@iba.dk","secret", dataHandler);

        Rest api = new Rest([], admin);
        api.Build();
        api.get();
        api.post();
        api.run();
    }
}