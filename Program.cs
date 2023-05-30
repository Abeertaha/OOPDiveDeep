using System;

public abstract class Employee
{
    private string? name;
    private int id;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public Employee(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public abstract decimal Salary();
    public abstract void PrintInfo();
}

public class SeniorEmployee : Employee, IService, IDisplay
{
    private decimal yearlySalary;

    public SeniorEmployee(string name, int id, decimal yearlySalary)
        : base(name, id)                                                   //constructor 
    {
        this.yearlySalary = yearlySalary;
    }

    public override decimal Salary()
    {
        return yearlySalary;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Yearly Salary: {Salary()}");
    }

    decimal IService.CalculateSalary()
    {
        return Salary();
    }
}

public class JuniorEmployee : Employee, IService, IDisplay
{
    private decimal hourlySalary;

    public JuniorEmployee(string name, int id, decimal hourlySalary)
        : base(name, id)
    {
        this.hourlySalary = hourlySalary;
    }

    public override decimal Salary()
    {
        return hourlySalary;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Hourly Salary: {Salary()}");
    }

    decimal IService.CalculateSalary()
    {
        return Salary();
    }
}

public interface IService
{
    decimal CalculateSalary();
}

public interface IDisplay
{
    void PrintInfo();
}

class Program
{
    static void Main(string[] args)
    {
        SeniorEmployee seniorEmployee = new SeniorEmployee("Adam", 1, 1000);
        JuniorEmployee juniorEmployee = new JuniorEmployee("Julia", 2, 500);

        IService employee1 = seniorEmployee;
        IService employee2 = juniorEmployee;
        IDisplay employee3 = seniorEmployee;
        IDisplay employee4 = juniorEmployee;

        Console.WriteLine($"Employee 1 Salary: {employee1.CalculateSalary()}");
        Console.WriteLine($"Employee 2 Salary: {employee2.CalculateSalary()}");

        employee3.PrintInfo();
        employee4.PrintInfo();
    }
}