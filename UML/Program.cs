

using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

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


/*
@startuml

actor User
participant Alice
participant Everything

User -> Alice: Start program
Alice -> Everything: Bob()
Everything --> Alice: Return (0-4)

alt Bob() == 0
    Alice -> Console: "Everything is fine"
else Bob() == 1
    Alice -> Everything: Log("start")
    loop 1000 times
        Alice -> Everything: Bob()
    end
    Alice -> Everything: Log("Stop")
else
    Alice -> Console: "Repeat"
end

@enduml

*/