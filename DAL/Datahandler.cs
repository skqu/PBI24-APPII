class DataHandler
{
    public DataHandler()
    {

    }

    public List<string> getUser(string username)
    {
        List<string> user = new List<string>();

        user.Add("skqu");
        user.Add("secret");
        user.Add("admin");

        return user;
    }
}