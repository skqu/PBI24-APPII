using Microsoft.VisualBasic.FileIO;

class Program
{
    static void Main()
    {
        Car Volvo = new Car("Volvo");
        Console.WriteLine(Volvo.Noise());
    }
}


public class Car
{
    private string sound = "wroom";
    private string  carName = "";

    public Car(string name)
    {
        carName = name;
    }

    ~Car()
    {

    }

    public string Noise()
    {
        return sound;
    }

}
