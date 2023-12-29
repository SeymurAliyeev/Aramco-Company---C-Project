using Company.Core.Entities;

namespace Aramco.Business.Interfaces;

public interface IDeparmentServices
{
    void Create(string? DepartmentName, string description,string CompanyName, int MinEmployeeCount);
    void Deactivate (string DepartmentName);
    void Delete(string DepartmentName);
    Department? GetByName(string DepartmentName);
    Core.Entities.Department? GetByName(string DepartmentName);
    void GetEmployeesIncluded(string DepartmentName);
    void ShowAll();
}
