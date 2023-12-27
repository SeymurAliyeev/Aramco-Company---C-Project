using Company.Core.Interfaces;

namespace Company.Core.Entities;

public class Department : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    private static int _id;
    public int MaxEmployeeCount { get; set; }
    public Company Company { get; set; }
    public string Description { get; set; }

    public Department(string name, string description, int maxEmployeeCount, Company company)
    {
        Id = _id++;
        Name = name;
        MaxEmployeeCount = maxEmployeeCount;
        Company = company;
        Description = description;
    }

}
