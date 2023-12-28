using Company.Core.Entities;

namespace Aramco.Business.Interfaces;

public interface IDeparmentServices
{
    void Create(string? DepartmentName,string CompanyName, string description);
    void Delete(string DepartmentName);
    Department GetById(int DepartmentId);
    void Deactivate (string DepartmentName);
    void ShowAll();
    void GetEmployeesIncluded(string DepartmentName);
}
