using Aramco.Business.Interfaces;
using Aramco.Business.Utilities.Exceptions;
using Aramco.DataAccess.Contexts;
using Company.Core.Entities;

namespace Aramco.Business.Services;

public class DepartmentService : IDeparmentServices
{
    public void Create(string? DepartmentName, string description, int maxEmployeeCount, int CompanyId)
    {
        if (String.IsNullOrEmpty(DepartmentName)) throw new ArgumentNullException();
        Department dbDepartment =
            AramcoDbContext.Departments.Find(c => c.DepartmentName.ToLower() == DepartmentName.ToLower());
        if (dbDepartment is not null)
            throw new AlreadyExistException($"{dbDepartment.DepartmentName} is already exist");
        if (dbDepartment.MaxEmployeeCount > 50)
            throw new MaxCountException($"You have already reached the maximum size of department employee count");
        if (dbDepartment.MinEmployeeCount < 5)
            throw new MinCountException($"There is insufficient count of department employees. Minimum count requirement is 5.");
        Department department = new(DepartmentName, description, maxEmployeeCount, CompanyId);
        AramcoDbContext.Departments.Add(department);
    }

    public void Create(string? DepartmentName, string CompanyName, string description)
    {
        throw new NotImplementedException();
    }

    public void Deactivate(string DepartmentName)
    {
        throw new NotImplementedException();
    }

    public void Delete(string DepartmentName)
    {
        throw new NotImplementedException();
    }

    public Department GetById(int DepartmentId)
    {
        throw new NotImplementedException();
    }

    public void GetEmployeesIncluded(string DepartmentName)
    {
        throw new NotImplementedException();
    }

    public void ShowAll()
    {
        throw new NotImplementedException();
    }
}
