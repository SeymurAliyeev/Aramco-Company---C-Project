using Company.Core.Entities;

namespace Aramco.DataAccess.Contexts;

public static class AramcoDbContext
{
    public static List<Aramco.Core.Entities.Company> Companies { get; set; } = new List<Core.Entities.Company> { };
    public static List<Department> Departments { get; set; } = new List<Department> { };
    public static List<Employee> Employees { get; set; } = new List<Employee> { };

}
