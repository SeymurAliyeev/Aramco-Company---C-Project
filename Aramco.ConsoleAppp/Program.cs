using Aramco.Business.Services;
Console.WriteLine("Aramco Project Starts:");

CompanyService companyService = new();
DepartmentService departmentService = new();
EmployeeService employeeService = new();

while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1 - Create Company \n" + 
                      "2 - Delete");
}
