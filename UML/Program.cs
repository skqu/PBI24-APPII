

class Alice
{
    static void Main()
    {
        Everything smt = new Everything();
        if (smt.Bob() == 0)
        {
            Console.WriteLine("Everything is fine");
        }else if(smt.Bob() == 1)
        {
            smt.Log("start");
            for (int i = 0; i < 1000; i++)
            {
                smt.Bob();
            }
            smt.Log("Stop");
        }else
        {
            Console.WriteLine("Repeat");
        }
    }
}

class Everything
{

    public byte Bob()
    {
        Random rnd = new Random();
        byte min = 0, max = 5;
        byte number = (byte) rnd.Next(min, max);
        return number;
    }

    public void Log(string msg)
    {
        Console.WriteLine("Log entry with msg: " + msg);
    }
}