using Aramco.Business.Services;
using Aramco.Business.Utilities.Helpers;
using Aramco.DataAccess.Contexts;
using Company.Core.Entities;
using System.Xml.Linq;
Console.WriteLine("Aramco Project Starts:");

CompanyService companyService = new();
DepartmentService departmentService = new();
EmployeeService employeeService = new();

bool keeplooping = true;
while (keeplooping)
{
    Console.WriteLine("Press the button:");
    Console.WriteLine("------COMPANY------\n" +
                      "1 - Company Create \n" +
                      "2 - Company Deactivate\n" +
                      "3 - Company Get By Name\n" +
                      "4 - Company Get Included Departments\n" +
                      "5 - Company Show All Deactivated Companies\n" +
                      "6 - Company Show All\n" +
                      "------DEPARTMENT------\n" +
                      "7 - Department Create\n" +
                      "8 - Department Deactivate\n" +
                      "9 - Department Get By Name\n" +
                      "10 - Department Get Included Employees\n" +
                      "11 - Department Show All Deactivated Departments\n" +
                      "12 - Department Show All\n" +
                      "------EMPLOYEE------\n" +
                      "13 - Employee Create\n" +
                      "14 - Employee Change\n" +
                      "15 - Employee Deactivate\n" +
                      "16 - Employee Get By Id\n" +
                      "17 - Employee Show All Deactivated Employees\n" +
                      "18 - Employee Show All\n" +
                      "0 - Quit");

    string? option = Console.ReadLine();
    int OptionNumber;
    bool isInt = int.TryParse(option, out OptionNumber);
    if (isInt)
    {
        if (OptionNumber >= 0 && OptionNumber <= 18)
        {
            switch (OptionNumber)
            {
                case (int)Menu.CompanyCreate:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter company name:");
                        string? CompanyName = Console.ReadLine();
                        Console.WriteLine("Enter company description:");
                        string? Description = Console.ReadLine();
                        companyService.Create(CompanyName, Description);
                        Console.WriteLine("Company Created!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.CompanyCreate;
                    }
                    break;
                case (int)Menu.CompanyDeactivate:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter company name:");
                        string? CompanyName = Console.ReadLine();
                        companyService.Deactivate(CompanyName);
                        Console.WriteLine("Company Deactivated!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.CompanyDeactivate;
                    }
                    break;
                case (int)Menu.CompanyGetByName:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter company name:");
                        string? CompanyName = Console.ReadLine();
                        companyService.GetCompanyByName(CompanyName);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.CompanyGetByName;
                    }
                    break;
                case (int)Menu.CompanyGetIncludedDepartments:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter company name:");
                        string? CompanyName = Console.ReadLine();
                        Console.WriteLine($"All Included Departments of {CompanyName} Company:");
                        Console.WriteLine("---------------------------------------------------");
                        companyService.GetDepartmentsIncluded(CompanyName);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.CompanyGetIncludedDepartments;
                    }
                    break;
                case (int)Menu.CompanyShowAllDeactivated:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("All Deactivated Companies:");
                    Console.WriteLine("---------------------------");
                    companyService.ShowAllDeactivatedCompanies();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (int)Menu.CompanyShowAll:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("All Companies:");
                    Console.WriteLine("---------------------------");
                    companyService.ShowAll();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (int)Menu.DepartmentCreate:
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (companyService.IsCompanyExist() == false)
                    {
                        Console.WriteLine("This company is not exist!");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.DepartmentCreate;
                    }
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter department name:");
                        string? Departmentname = Console.ReadLine();
                        Console.WriteLine("Enter department description:");
                        string? Description = Console.ReadLine();
                        Console.WriteLine("Enter company name:");
                        string? CompanyName = Console.ReadLine();
                        Console.WriteLine("Enter minimum employee count:");
                        int MinEmployeeCount = Convert.ToInt32(Console.ReadLine());
                        departmentService.Create(Departmentname, Description, CompanyName, MinEmployeeCount);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.DepartmentCreate;
                    }
                    break;
                case (int)Menu.DepartmentDeactivate:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter department name:");
                        string? DepartmentName = Console.ReadLine();
                        departmentService.Deactivate(DepartmentName);
                        Console.WriteLine("Department Deactivated!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.DepartmentDeactivate;
                    }
                    break;
                case (int)Menu.DepartmentGetByName:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter department name:");
                        string? DepartmentName = Console.ReadLine();
                        departmentService.GetByName(DepartmentName);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.DepartmentGetByName;
                    }
                    break;
                case (int)Menu.DepartmentGetIncludedEmployees:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter department name:");
                        string? DepartmentName = Console.ReadLine();
                        Console.WriteLine($"All Employees of {DepartmentName} Department:");
                        Console.WriteLine("------------------------------------------------");
                        departmentService.GetEmployeesIncluded(DepartmentName);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.DepartmentGetIncludedEmployees;
                    }
                    break;
                case (int)Menu.DepartmentShowAllDeactivated:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("All Deactivated Departments:");
                    Console.WriteLine("-----------------------------");
                    departmentService.ShowAllDeactivatedDepartments();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (int)Menu.DepartmentShowAll:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("All Departments:");
                    Console.WriteLine("-----------------------------");
                    departmentService.ShowAll();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (int)Menu.EmployeeCreate:
                    if (departmentService.IsDepartmentExist() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This department is not exist!");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.EmployeeCreate;
                    }
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter employee name:");
                        string? Name = Console.ReadLine();
                        Console.WriteLine("Enter employee surname:");
                        string? Surname = Console.ReadLine();
                        Console.WriteLine("Enter employee email:");
                        string? Email = Console.ReadLine();
                        Console.WriteLine("Enter department name:");
                        string Departmentname = Console.ReadLine();
                        Console.WriteLine("Enter salary:");
                        int Salary = Convert.ToInt32(Console.ReadLine());
                        employeeService.Create(Name, Surname, Email, Departmentname, Salary);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.EmployeeCreate;
                    }
                    break;
                case (int)Menu.EmployeeChange:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter employee Id:");
                        int EmployeeId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new department name:");
                        string newDepartmentName = Console.ReadLine();
                        employeeService.Change(EmployeeId, newDepartmentName);
                        Console.WriteLine("Employee has been replaced!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.EmployeeChange;
                    }
                    break;
                case (int)Menu.EmployeeDeactivate:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter employee Id:");
                        int EmployeeId = Convert.ToInt32(Console.ReadLine());
                        employeeService.Deactivate(EmployeeId);
                        Console.WriteLine("Employee Deactivated!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.EmployeeDeactivate;
                    }
                    break;
                case (int)Menu.EmployeeGetById:
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter employee Id:");
                        int EmployeeId = Convert.ToInt32(Console.ReadLine());
                        employeeService.GetEmployeeById(EmployeeId);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto case (int)Menu.EmployeeGetById;
                    }
                    break;
                case (int)Menu.EmployeeShowAllDeactivated:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("All Deactivated Employees:");
                    Console.WriteLine("---------------------------");
                    employeeService.ShowAllDeactivatedEmployees();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case (int)Menu.EmployeeShowAll:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("All Employees:");
                    Console.WriteLine("---------------------------");
                    employeeService.ShowAll();
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    keeplooping = false;
                    break;
                    Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please, choose the one of available option numbers!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please, enter correct format!");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
