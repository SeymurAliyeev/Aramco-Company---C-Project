using Company.Core.Entities;

namespace Company.DataAccess.Contexts;

public static class CompanyDbContext
{
    public static List<Department> Departments { get; set; }
    public static List<Employee> Employees { get; set; }

}
