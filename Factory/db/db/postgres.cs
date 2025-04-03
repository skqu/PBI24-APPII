class Postgres:Idb
{
       private static readonly Postgres instance = new Postgres();
    private string val = "Hello from Prostgres";

    static Postgres()
    {
    }

    private Postgres()
    {
    }

    public static Postgres getInstance
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