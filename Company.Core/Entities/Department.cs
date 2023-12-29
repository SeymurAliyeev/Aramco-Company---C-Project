using Company.Core.Interfaces;
using System.Xml.Linq;

namespace Company.Core.Entities;

public class Department : IEntity
{
    public int Id { get; }
    public string DepartmentName { get; set; }
    private static int _id;
    public int MaxEmployeeCount { get; set; }
    public int CurrentEmployeeCount { get; set; } = 0;
    public bool isActive { get; set; } = true;
    public string CompanyName { get; set; }
    public string Description { get; set; }
    public override string ToString()
    {
        return "Id:" + Id +
               "Name:" + DepartmentName;
    }

    public Department(string name, string description, string _CompanyName, int maxemployeecount)
    {
        Id = _id++;
        DepartmentName = name;
        CompanyName = _CompanyName;
        Description = description;
        MaxEmployeeCount = maxemployeecount;
    }

}
