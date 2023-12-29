namespace Aramco.Business.Interfaces;

public interface IEmployeeServices
{
    void Create(string Name, string Surname, string email, string DepartmentName, int Salary);
    void Delete(int EmployeeId);
    void Change(int EmployeeId, string Departmentname);
    void GetEmployeeById(int EmployeeId);
    void ShowAll();

}
