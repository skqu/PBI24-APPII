using System;
using System.Collections.Generic;

/*
plantuml
@startuml

class Teacher {
    -string name
    +Teacher(string name)
    +string getName()
}

class Course {
    -list<Teacher> Teachers
    -string Name
    +void Course(Teacher teacher, name)
    +void addTeacher(Teacher teacher)
    +string getName()
    +List<string> getTeachers()
}

Course "*" --o "1" Teacher : Has a

@enduml

*/
/*
class Aggregation
{
    static void Main()
    {
        Teacher stefan = new Teacher("Stefan");
        Teacher lena = new Teacher("Lena");
        
        Course AppII = new Course(stefan, "AppII");
        Console.WriteLine(AppII.getName() + ": " + AppII.getTeachers());

        AppII.addTeacher(lena);
        Console.WriteLine(AppII.getName() + ": " + AppII.getTeachers());
    }
}*/

class Teacher
{
    private string name;

    public Teacher(string name)  
    {
        this.name = name;
    }

    public string getName()
    {
        return this.name;
    }
}

class Course
{
    private List<Teacher> Teachers = new List<Teacher>(); 
    private string name = ""; 

    public Course(Teacher teacher, string name)
    {
        this.Teachers.Add(teacher); 
        this.name = name;
    }

    public void addTeacher(Teacher teacher)
    {
        this.Teachers.Add(teacher);
    }

    public string getName()
    {
        return this.name;
    }

    public string getTeachers()
    {
        List<string> strTeachers = new List<string>();
        foreach (Teacher t in this.Teachers)
        {
            strTeachers.Add(t.getName()); 
        }
        return string.Join(", ", strTeachers); 
    }
}
