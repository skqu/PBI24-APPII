class User
{
    private string username; // Attributes
    private string password; // Attributes
    private DataHandler thomas;  // Attributes

    public User(string username, string password, DataHandler dth)
    {
        this.username = username;
        this.password = password;
        this.thomas = dth;
    }

    public bool authorizeUser(string username, string password)
    {
        bool rtn = false;

        if (this.thomas.getUser(username)[1] == password)
        {
            this.username = username;
            this.password = password;
            rtn = true;
        }

        return rtn;
    }
}