using Company.Core.Interfaces;

namespace Company.Core.Entities;

public class Employee : IEntity
{
    public int Id { get; }
    private static int _id;
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    //public string Department { get; }
    public bool isActive { get; set; } = true;

    public string DepartmentName { get; set; }
    public int Salary { get; set; }
    public override string ToString()
    {
        return "Id:" + Id +
               "Name:" + Name +
               "Surname:" + Surname +
               "Email:" + Email;
    }

    public Employee(string name, string surname, string email, string _DepartmentName, int salary)
    {
        Id = _id++;
        Name = name;
        Surname = surname;
        Email = email;
        DepartmentName = _DepartmentName;
        Salary = salary;
    }
}
