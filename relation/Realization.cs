using System;
using System.Collections.Generic;
/*
@startuml

interface IWorker {
    +avoid Work()
}

class Employee {
    +string name
    +Employee(string name)
    +void Work()
}

class Freelancer {
    +string name
    +Freelancer(string name)
    +void Work()
}

IWorker <|.. Employee
IWorker <|.. Freelancer

@enduml
*/

class Realization
{
    static void Main()
    {
        List<IWorker> workers = new List<IWorker>();

        workers.Add(new Employee("John"));
        workers.Add(new Freelancer("Sarah"));

        foreach (IWorker worker in workers)
        {
            worker.Work();
        }
    }
}

interface IWorker
{
    void Work();
}

class Employee : IWorker
{
    private string name;

    public Employee(string name)
    {
        this.name = name;
    }

    public void Work()
    {
        Console.WriteLine($"{name} is working full-time at the office.");
    }
}

class Freelancer : IWorker
{
    private string name;

    public Freelancer(string name)
    {
        this.name = name;
    }

    public void Work()
    {
        Console.WriteLine($"{name} is working remotely on a project.");
    }
}
