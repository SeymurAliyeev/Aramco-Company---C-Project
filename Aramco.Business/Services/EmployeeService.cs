using Aramco.Business.Interfaces;

namespace Aramco.Business.Services;

public class EmployeeService : IEmployeeServices
{
    public void Change(int EmployeeId, string Departmentname)
    {
        throw new NotImplementedException();
    }

    public void Create(string Name, string Surname, string email, string DepartmentName, int Age, int Salary)
    {
        throw new NotImplementedException();
    }

    public void Delete(int EmployeeId)
    {
        throw new NotImplementedException();
    }

    public void Update(int EmployeeId, int Salary, string email)
    {
        throw new NotImplementedException();
    }
}
