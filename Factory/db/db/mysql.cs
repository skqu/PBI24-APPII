class MySql:Idb
{
       private static readonly MySql instance = new MySql();
    private string val = "Hello from MySql";

    static MySql()
    {
    }

    private MySql()
    {
    }

    public static MySql getInstance
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