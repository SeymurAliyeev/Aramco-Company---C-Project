namespace Aramco.Business.Interfaces;

public interface IEmployeeServices
{
    void Create(string Name, string Surname, string email, string DepartmentName, int Age, int Salary);
    void Delete(int EmployeeId);
    void Change(int EmployeeId, string Departmentname);
    void Update(int EmployeeId, int Salary, string email);

}
