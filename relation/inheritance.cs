using System;
using System.Collections.Generic;
/*
@startuml

class Car {
    -string model
    -int horsepower
    +Car(string model, int horsepower)
    +string getCarDetails()
}

class ElectricCar {
    -int batteryCapacity
    +ElectricCar(string model, int horsepower, int batteryCapacity)
    +string getCarDetails()
}

class PetrolCar {
    -int fuelCapacity
    +PetrolCar(string model, int horsepower, int fuelCapacity)
    +string getCarDetails()
}

Car <|-- ElectricCar : extends
Car <|-- PetrolCar : extends

@enduml
*/
/*
class Polymorphism
{
    static void Main()
    {
        List<Car> cars = new List<Car>();

        cars.Add(new ElectricCar("Tesla Model 3", 283, 75));
        cars.Add(new PetrolCar("Ford Mustang GT", 450, 60));

        foreach (Car car in cars)
        {
            Console.WriteLine(car.getCarDetails());
        }
    }
}*/

namespace inheritance
{

class Car
{
    protected string model;
    protected int horsepower;

    public Car(string model, int horsepower)
    {
        this.model = model;
        this.horsepower = horsepower;
    }

    public virtual string getCarDetails()
    {
        return $"Car Model: {this.model}, Horsepower: {this.horsepower}";
    }
}

class ElectricCar : Car
{
    private int batteryCapacity;

    public ElectricCar(string model, int horsepower, int batteryCapacity) : base(model, horsepower)
    {
        this.batteryCapacity = batteryCapacity;
    }

    public override string getCarDetails()
    {
        return $"{base.getCarDetails()}, Battery Capacity: {this.batteryCapacity} kWh";
    }
}

class PetrolCar : Car
{
    private int fuelCapacity;

    public PetrolCar(string model, int horsepower, int fuelCapacity) : base(model, horsepower)
    {
        this.fuelCapacity = fuelCapacity;
    }

    public override string getCarDetails()
    {
        return $"{base.getCarDetails()}, Fuel Capacity: {this.fuelCapacity} L";
    }
}
}