using Company.Core.Interfaces;
using System.Xml.Linq;

namespace Company.Core.Entities;

public class Department : IEntity
{
    public int Id { get; }
    public string DepartmentName { get; set; }
    private static int _id;
    public int MinEmployeeCount { get; set; }
    public int MaxEmployeeCount { get; set; }
    public int CurrentEmployeeCount { get; set; }
    public bool isActive { get; set; } = true;
    public Aramco.Core.Entities.Company CompanyName { get; set; }
    public string Description { get; set; }
    public object Company { get; set; }
    public override string ToString()
    {
        return "Id:" + Id +
               "Name:" + DepartmentName;
    }

    public Department(string name, string description, string CompanyName, int minemployeecount)
    {
        Id = _id++;
        DepartmentName = name;
        CompanyName = CompanyName;
        Description = description;
        MinEmployeeCount = minemployeecount;
    }

}
