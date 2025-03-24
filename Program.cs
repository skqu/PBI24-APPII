
class Program
{
    static void Main()
    {
        Rest api = new Rest([]);
        api.Build();
        api.get();
        api.run();
    }
}