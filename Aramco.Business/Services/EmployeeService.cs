using Aramco.Business.Interfaces;
using Aramco.Business.Utilities.Exceptions;
using Aramco.Core.Entities;
using Aramco.DataAccess.Contexts;
using Company.Core.Entities;
using Department = Company.Core.Entities.Department;

namespace Aramco.Business.Services;

public class EmployeeService : IEmployeeServices
{
    private DepartmentService departmentservice { get; }
    public EmployeeService()
    {
        departmentservice = new DepartmentService();
    }
    public void Create(string Name, string Surname, string email, string DepartmentName, int Salary)
    {
        if (String.IsNullOrEmpty(Name)) throw new ArgumentNullException();
        Department? department = AramcoDbContext.Departments.Find(x => x.DepartmentName.ToLower() == DepartmentName.ToLower());
        if (department is null) throw new NotFoundException($"{DepartmentName} is not exist");


        if (department.MaxEmployeeCount == department.CurrentEmployeeCount)
        {
            throw new FullDepartmentException($"{department.DepartmentName} is already full");
        }
        Employee employee = new(Name, Surname, email, DepartmentName, Salary);
        if (department.isActive == true)
        {
            AramcoDbContext.Employees.Add(employee);
            Console.WriteLine("Employee Created!");
            department.CurrentEmployeeCount++;
        }
        else
        {
            Console.WriteLine($"New employee can not be created, because {DepartmentName} is not actively found!");
        }
    }
    public void Change(int EmployeeId, string newDepartmentName)
    {
        var employee = AramcoDbContext.Employees.Find(e => e.Id == EmployeeId);
        if (employee is null) throw new NotFoundException("Employee is not found");
        if (String.IsNullOrEmpty(newDepartmentName)) throw new ArgumentNullException();
        var department = AramcoDbContext.Departments.Find(g => g.DepartmentName.ToLower() == newDepartmentName.ToLower());
        if (department is null) throw new NotFoundException("Department is not found");
        Deactivate(EmployeeId);
        Create(employee.Name, employee.Surname, employee.Email, newDepartmentName, employee.Salary);
    }
    public void Deactivate(int EmployeeId)
    {
        var employee = AramcoDbContext.Employees.Find(e => e.Id == EmployeeId);
        if (employee is null) throw new NotFoundException("Employee is not found");
        employee.isActive = false;
    }
    public void GetEmployeeById(int EmployeeId)
    {
        foreach (var employee in AramcoDbContext.Employees)
        {
            if (employee.Id != EmployeeId)
            {
                throw new NotFoundException($"{EmployeeId} is not exist");
            }
            else employee.isActive = true;
            {
                Console.WriteLine($"id:  {EmployeeId} \n" +
                          $"Employee Name, Surname:  {employee.Name}  {employee.Surname} \n" +
                          $"Employee Salary:  {employee.Salary}");
            }
        }
    }

    public void ShowAllDeactivatedEmployees()
    {
        foreach (var employee in AramcoDbContext.Employees)
        {
            if (employee.isActive == false)
            {
                Console.WriteLine($"Id:  {employee.Id} \n" +
                                  $"Name: {employee.Name}\n" +
                                  $"Surname: {employee.Surname}\n" +
                                  $"Salary:  {employee.Salary}\n");
            }
        }
    }


    public void ShowAll()
    {
        foreach (var employee in AramcoDbContext.Employees)
        {
            if (employee.isActive == true)
            {
                Console.WriteLine($"Id:  {employee.Id} \n" +
                                  $"Name: {employee.Name}\n" +
                                  $"Surname: {employee.Surname}\n" +
                                  $"Salary:  {employee.Salary}\n");
            }
        }
    }

}
