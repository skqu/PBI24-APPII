class DBMS
{
    private List<string> ldb = new List<string>();


    public DBMS()
    {
        this.ldb.Add("mysql");
        this.ldb.Add("postgres");
    }


    public List<string> Getdb()
    {
        return ldb;
    }

    public Idb Conn(string db)
    {
        if ( ldb.Contains(db))
        {
            switch(db)
            {
                case "mysql":
                    return MySql.getInstance;
                case "postgres":
                    return Postgres.getInstance;
            }
        }
        Console.WriteLine(db + " is not part of selectable db");
        return null;
    }
}