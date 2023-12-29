using Aramco.Business.Interfaces;
using Aramco.Business.Utilities.Exceptions;
using Aramco.Core.Entities;
using Aramco.DataAccess.Contexts;
using Company.Core.Entities;
using System.Data.Common;
using System.Data.SqlTypes;

namespace Aramco.Business.Services;

public class CompanyService : ICompanyServices
{
    public void Create(string? CompanyName, string? description)
    {
        if (String.IsNullOrEmpty(CompanyName)) throw new ArgumentNullException();
        Aramco.Core.Entities.Company? dbCompany =
            AramcoDbContext.Companies.Find(c => c.CompanyName.ToLower() == CompanyName.ToLower());
        if (dbCompany is not null)
            throw new AlreadyExistException($"{dbCompany.CompanyName} is already exist");
        Aramco.Core.Entities.Company company = new(CompanyName, description);
        AramcoDbContext.Companies.Add(company);
        Console.WriteLine("Company created!!!");
    }

    public void Delete(string CompanyName)
    {
        if (String.IsNullOrEmpty(CompanyName)) throw new ArgumentNullException();
        Aramco.Core.Entities.Company? dbCompany =
            AramcoDbContext.Companies.Find(c => c.CompanyName.ToLower() == CompanyName.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"{CompanyName} is not found");
        dbCompany.isActive = false;
    }

    public void GetCompanyByName(string CompanyName)
    {
        if (String.IsNullOrEmpty(CompanyName)) throw new ArgumentNullException();
        var dbCompany = AramcoDbContext.Companies.Find(c => c.CompanyName.ToLower() == CompanyName.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"{CompanyName} is not found");

        if (dbCompany.isActive == true)
        {
            Console.WriteLine($"id:  {dbCompany.Id} \n" +
                              $"Company Name:  {dbCompany.CompanyName} \n" +
                              $"Company description:  {dbCompany.Description}");
        }
    }

    public void GetDepartmentsIncluded(string CompanyName)
    {
        if (String.IsNullOrEmpty(CompanyName)) throw new ArgumentNullException();
        var dbCompany = AramcoDbContext.Companies.Find(c => c.CompanyName.ToLower() == CompanyName.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"{CompanyName} is not found");


        foreach (var department in AramcoDbContext.Departments)
        {
            if (department.CompanyName.ToLower() == dbCompany.CompanyName.ToLower() && department.isActive == true)
            {
                Console.WriteLine($"Id:  {department.Id} \n" +
                                  $"Name: {department.DepartmentName}\n" +
                                  $"Description: {department.Description}\n");
            }
        }
    }

    public void ShowAll()
    {
        foreach (var company in AramcoDbContext.Companies)
        {
            if (company.isActive == true)
            {
                Console.WriteLine($"Company Id:  {company.Id};   Company Name: {company.CompanyName}");
            }
        }
    }
}
