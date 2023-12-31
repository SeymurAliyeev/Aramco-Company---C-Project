using Company.Core.Entities;

namespace Aramco.Business.Interfaces;

public interface IDeparmentServices
{
    void Create(string? DepartmentName, string? description,string? CompanyName, int MinEmployeeCount);
    void Deactivate(string DepartmentName);
    void GetByName(string DepartmentName);
    void GetEmployeesIncluded(string DepartmentName);
    void ShowAllDeactivatedDepartments();
    void ShowAll();
    bool IsDepartmentExist();
}
