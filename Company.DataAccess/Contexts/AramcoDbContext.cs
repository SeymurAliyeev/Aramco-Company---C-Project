using Company.Core.Entities;

namespace Aramco.DataAccess.Contexts;

public static class AramcoDbContext
{
    public static List<Aramco.Core.Entities.Company> Companies { get; set; }
    public static List<Department> Departments { get; set; }
    public static List<Employee> Employees { get; set; }

}
