using Aramco.Business.Services;
using Aramco.Business.Utilities.Helpers;
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
                      "2 - Company Delete\n" +
                      "3 - Company Get By Name\n" +
                      "4 - Company Get Included Departments\n" +
                      "5 - Company Show All\n" + 
                      "------DEPARTMENT------\n" +
                      "6 - Department Create\n" + 
                      "7 - Department Delete\n" + 
                      "8 - Department Get By Name\n" + 
                      "9 - Department Get Included Employees\n" + 
                      "10 - Department Show All\n" + 
                      "------EMPLOYEE------\n" + 
                      "11 - Employee Create\n" + 
                      "12 - Employee Change\n" + 
                      "13 - Employee Delete\n" + 
                      "14 - Employee Get By Id\n" + 
                      "15 - Employee Show All\n" + 
                      "0 - Quit");

    string? option = Console.ReadLine();
    int OptionNumber;
    bool isInt = int.TryParse(option, out OptionNumber);
    if (isInt)
    {
        if(OptionNumber>= 0 && OptionNumber<=15)
        {
            switch (OptionNumber)
            {
                case (int)Menu.CompanyCreate:
                    try
                    {
                        Console.WriteLine("Enter company name:");
                        string? CompanyName = Console.ReadLine();
                        Console.WriteLine("Enter company description:");
                        string? Description = Console.ReadLine();
                        companyService.Create(CompanyName, Description);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 1;
                    }
                    break;
                case (int)Menu.CompanyDelete:
                    try
                    {
                        Console.WriteLine("Enter company name:");
                        string? CompanyName = Console.ReadLine();
                        companyService.Delete(CompanyName);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 2;
                    }
                    break;
                case (int)Menu.CompanyGetByName:
                    try
                    {
                        Console.WriteLine("Enter company name:");
                        string? CompanyName = Console.ReadLine();
                        companyService.GetCompanyByName(CompanyName);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 3;
                    }
                    break;
                case (int)Menu.CompanyGetIncludedDepartments:
                    try
                    {
                        Console.WriteLine("Enter company name:");
                        string? CompanyName = Console.ReadLine();
                        companyService.GetDepartmentsIncluded(CompanyName);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 4;
                    }
                    break;
                case (int)Menu.CompanyShowAll:
                    Console.WriteLine("All Companies:");
                    companyService.ShowAll();
                    break;
                case (int)Menu.DepartmentCreate:
                    try
                    {
                        Console.WriteLine("Enter department name:");
                        string? Departmentname = Console.ReadLine();
                        Console.WriteLine("Enter department description:");
                        string? Description = Console.ReadLine();
                        Console.WriteLine("Enter company name:");
                        string? CompanyName = Console.ReadLine();
                        Console.WriteLine("Enter minimum employee count:");
                        int MinEmployeeCount = Convert.ToInt32(Console.ReadLine());
                        departmentService.Create(Departmentname, Description,CompanyName,MinEmployeeCount);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 6;
                    }
                    break;
                case (int)Menu.DepartmentDelete:
                    try
                    {
                        Console.WriteLine("Enter department name:");
                        string? DepartmentName = Console.ReadLine();
                        departmentService.Delete(DepartmentName);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 7;
                    }
                    break;
                case (int)Menu.DepartmentGetByName:
                    try
                    {
                        Console.WriteLine("Enter department name:");
                        string? DepartmentName = Console.ReadLine();
                        departmentService.GetByName(DepartmentName);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 8;
                    }
                    break;
                case (int)Menu.DepartmentGetIncludedEmployees:
                    try
                    {
                        Console.WriteLine("Enter department name:");
                        string? DepartmentName = Console.ReadLine();
                        departmentService.GetEmployeesIncluded(DepartmentName);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 9;
                    }
                    break;
                case (int)Menu.DepartmentShowAll:
                    Console.WriteLine("All Departments:");
                    companyService.ShowAll();
                    break;
                case (int)Menu.EmployeeCreate:
                    try
                    {
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
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 11;
                    }
                    break;
                case (int)Menu.EmployeeChange:
                    try
                    {
                        Console.WriteLine("Enter employee Id:");
                        int EmployeeId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new department name:");
                        string newDepartmentName = Console.ReadLine();
                        employeeService.Delete(EmployeeId);
                        employeeService.Create(name, surname, email, DepartmentName, salary);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 12;
                    }
                    break;
                case (int)Menu.EmployeeDelete:
                    try
                    {
                        Console.WriteLine("Enter employee Id:");
                        int EmployeeId = Convert.ToInt32(Console.ReadLine());
                        employeeService.Delete(EmployeeId);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 13;
                    }
                    break;
                case (int)Menu.EmployeeGetById:
                    try
                    {
                        Console.WriteLine("Enter employee Id:");
                        int EmployeeId = Convert.ToInt32(Console.ReadLine());
                        employeeService.GetEmployeeById(EmployeeId);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case 14;
                    }
                    break;
                case (int)Menu.EmployeeShowAll:
                    Console.WriteLine("All Employees:");
                    companyService.ShowAll();
                    break;
                default:
                    keeplooping = false;
                    break;
            }
        }
        else
        {
            Console.WriteLine("Please, choose the one of available option numbers!");
        }
    }
    else
    {
        Console.WriteLine("Please, enter correct format!");
    }
}
