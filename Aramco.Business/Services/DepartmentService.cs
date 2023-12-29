using Aramco.Business.Interfaces;
using Aramco.Business.Utilities.Exceptions;
using Aramco.Core.Entities;
using Aramco.DataAccess.Contexts;
using Company.Core.Entities;

namespace Aramco.Business.Services;

public class DepartmentService : IDeparmentServices
{
    private ICompanyServices companyservice { get; }
    public DepartmentService()
    {
        companyservice = new CompanyService();
    }

    public void Create(string? DepartmentName, string? description, string? CompanyName, int MinEmployeeCount)
    {
        if (String.IsNullOrEmpty(DepartmentName)) throw new ArgumentNullException();
        Company.Core.Entities.Department dbDepartment =
            AramcoDbContext.Departments.Find(c => c.DepartmentName.ToLower() == DepartmentName.ToLower());
        if (dbDepartment is not null)
            throw new AlreadyExistException($"{dbDepartment.DepartmentName} is already exist");


        if (MinEmployeeCount < 5)
            throw new MinCountException($"There is insufficient count of department employees. Minimum count requirement is 5.");


        var company = AramcoDbContext.Companies.Find(x => x.CompanyName.ToLower() == CompanyName.ToLower());
        if (company is null) throw new NotFoundException($"{CompanyName} is not exist");
        Company.Core.Entities.Department department = new(DepartmentName, description, CompanyName, MinEmployeeCount);
        AramcoDbContext.Departments.Add(department);
    }

    public void Delete(string DepartmentName)
    {
        if (String.IsNullOrEmpty(DepartmentName)) throw new ArgumentNullException();
        Company.Core.Entities.Department dbDepartment =
             AramcoDbContext.Departments.Find(c => c.DepartmentName.ToLower() == DepartmentName.ToLower());
        if (dbDepartment is null)
            throw new NotFoundException($"{DepartmentName} is not found");
        dbDepartment.isActive = false;
    }
    public void GetByName(string DepartmentName)
    {
        if (String.IsNullOrEmpty(DepartmentName)) throw new ArgumentNullException();
        var byDepartment = AramcoDbContext.Departments.Find(d => d.DepartmentName.ToLower() == DepartmentName.ToLower());
        if (byDepartment is null)
            throw new NotFoundException($"{DepartmentName} is not found");

        if(byDepartment.isActive == true) 
        {
            Console.WriteLine($"id:  {byDepartment.Id} \n" +
                          $"Department Name:  {byDepartment.CompanyName} \n" +
                          $"Department description:  {byDepartment.Description}");
        }

    }

    public void GetEmployeesIncluded(string DepartmentName)
    {

        if (String.IsNullOrEmpty(DepartmentName)) throw new ArgumentNullException();
        var byDepartment = AramcoDbContext.Departments.Find(d => d.DepartmentName.ToLower() == DepartmentName.ToLower());
        if (byDepartment is null)
            throw new NotFoundException($"{DepartmentName} is not found");


        foreach (var employee in AramcoDbContext.Employees)
        {
            if (employee.DepartmentName.ToLower() == byDepartment.DepartmentName.ToLower() && employee.isActive == true)
            {
                Console.WriteLine($"Id:  {employee.Id} \n" +
                                  $"Name: {employee.Name}\n" +
                                  $"Surname: {employee.Surname}\n" +
                                  $"Email:  {employee.Email}\n");
            }
        }
    }

    public void ShowAll()
    {
        foreach (var department in AramcoDbContext.Departments)
        {
            if (department.isActive == true)
            {
                Console.WriteLine($"Department Id:  {department.Id};   Department Name: {department.DepartmentName}");
            }
        }
    }
}
