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

    public void Create(string? DepartmentName, string description, string CompanyName, int MinEmployeeCount)
    {
        if (String.IsNullOrEmpty(DepartmentName)) throw new ArgumentNullException();
        Company.Core.Entities.Department dbDepartment =
            AramcoDbContext.Departments.Find(c => c.DepartmentName.ToLower() == DepartmentName.ToLower());
        if (dbDepartment is not null)
            throw new AlreadyExistException($"{dbDepartment.DepartmentName} is already exist");
        //if (dbDepartment.MaxEmployeeCount > 50)
        //    throw new MaxCountException($"You have already reached the maximum size of department employee count");
        if (dbDepartment.MinEmployeeCount < 5)
            throw new MinCountException($"There is insufficient count of department employees. Minimum count requirement is 5.");
        Aramco.Core.Entities.Company? company = companyservice.GetCompanyByName(CompanyName);
        if (company is null) throw new NotFoundException($"{CompanyName} is not exist");
        Company.Core.Entities.Department department = new(DepartmentName, description, CompanyName, MinEmployeeCount);
        AramcoDbContext.Departments.Add(department);
    }

    public void Deactivate(string DepartmentName)
    {
        if (String.IsNullOrEmpty(DepartmentName)) throw new ArgumentNullException();
        Company.Core.Entities.Department dbDepartment =
             AramcoDbContext.Departments.Find(c => c.DepartmentName.ToLower() == DepartmentName.ToLower());
        if (dbDepartment is null)
            throw new NotFoundException($"{DepartmentName} is not found");
        dbDepartment.isActive = false;
    }

    //public void Delete(string DepartmentName)
    //{
    //    throw new NotImplementedException();
    //}
    public Company.Core.Entities.Department? GetByName(string DepartmentName)
    {
        if (String.IsNullOrEmpty(DepartmentName)) throw new ArgumentNullException();
        Company.Core.Entities.Department? dbCompany = AramcoDbContext.Departments.Find(d => d.DepartmentName.ToLower() == DepartmentName.ToLower());
        if (dbDepartment is null)
            throw new NotFoundException($"{DepartmentName} is not found");
        Console.WriteLine($"id:  {dbDepartment.Id} \n" +
                          $"Department Name:  {dbDepartment.CompanyName} \n" +
                          $"Department description:  {dbDepartment.Description}");
    }

    public void GetEmployeesIncluded(string DepartmentName)
    {
        foreach (var employee in AramcoDbContext.Employees)
        {
            if (employee.Department.DepartmentName.ToLower() == DepartmentName.ToLower())
            {
                Console.WriteLine($"Id:  {employee.Id} \n"  +
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
            Console.WriteLine($"Department Id:  {department.Id};   Department Name: {department.DepartmentName}");
        }
    }
}
