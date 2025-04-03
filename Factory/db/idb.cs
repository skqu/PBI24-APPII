interface Idb
{
    private static readonly Idb instance;


    public static Singleton getInstance;

    public void Set(string str);

    public string Get();

}