using System;
/*
@startuml

class Car {
    -string model
    -Engine engine
    +Car(string model, int horsepower)
    +string getCarDetails()
}

class Engine {
    -int horsepower
    +Engine(int horsepower)
    +int getHorsepower()
}

Car --* Engine : has a

@enduml


*/
/*

class Composition
{
    static void Main()
    {
        Car car = new Car("Tesla Model S", 670);
        Console.WriteLine(car.getCarDetails());
    }
}*/

namespace composition
{

class Engine
{
    private int horsepower;

    public Engine(int horsepower)
    {
        this.horsepower = horsepower;
    }

    public int getHorsepower()
    {
        return this.horsepower;
    }
}

class Car
{
    private string model;
    private Engine engine;

    public Car(string model, int horsepower)
    {
        this.model = model;
        this.engine = new Engine(horsepower);
    }

    public string getCarDetails()
    {
        return $"Car Model: {this.model}, Engine Horsepower: {this.engine.getHorsepower()}";
    }
}
}