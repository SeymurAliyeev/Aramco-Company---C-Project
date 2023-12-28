using Company.Core.Interfaces;

namespace Company.Core.Entities;

public class Department : IEntity
{
    public int Id { get; }
    public string DepartmentName { get; set; }
    private static int _id;
    public int MaxEmployeeCount { get; set; }
    public int MinEmployeeCount { get; set; }
    public int CurrentEmployeeCount { get; set; }
    public int CompanyId { get; set; }
    public string Description { get; set; }

    public Department(string name, string description, int maxEmployeeCount, int CompanyId)
    {
        Id = _id++;
        DepartmentName = name;
        MaxEmployeeCount = maxEmployeeCount;
        CompanyId = CompanyId;
        Description = description;
    }

}
