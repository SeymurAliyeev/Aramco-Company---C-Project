using Company.Core.Entities;

namespace Aramco.Business.Interfaces;

public interface IDeparmentServices
{
    void Create(string? DepartmentName, string? description,string? CompanyName, int MinEmployeeCount);
    void Delete(string DepartmentName);
    void GetByName(string DepartmentName);
    void GetEmployeesIncluded(string DepartmentName);
    void ShowAll();
}
