
sealed class Singleton
{
    private static readonly Singleton instance = new Singleton();
    private string val = "";

    

    private Singleton()
    {
    }

    public static Singleton getInstance
    {
        get
        {
            return instance;
        }
    }

    public void Set(string str)
    {
        this.val = str;
    }

    public string Get()
    {
        return this.val;
    }
}
