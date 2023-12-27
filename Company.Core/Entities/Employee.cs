using Company.Core.Interfaces;

namespace Company.Core.Entities;

public class Employee : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    private static int _id;
    public Department Department { get; set; }

    public Employee(string name, string surname, string email, Department department)
    {
        Id = _id++;
        Name = name;
        Surname = surname;
        Email = email;
        Department = department;
    }
}
