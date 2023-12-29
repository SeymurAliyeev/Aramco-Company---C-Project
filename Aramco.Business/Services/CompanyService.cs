using Aramco.Business.Interfaces;
using Aramco.Business.Utilities.Exceptions;
using Aramco.Core.Entities;
using Aramco.DataAccess.Contexts;
using Company.Core.Entities;
using System.Data.SqlTypes;

namespace Aramco.Business.Services;

public class CompanyService : ICompanyServices
{
    public void Create(string? CompanyName, string description)
    {
        if (String.IsNullOrEmpty(CompanyName)) throw new ArgumentNullException();
        Aramco.Core.Entities.Company? dbCompany =
            AramcoDbContext.Companies.Find(c => c.CompanyName.ToLower() == CompanyName.ToLower());
        if (dbCompany is not null)
            throw new AlreadyExistException($"{dbCompany.CompanyName} is already exist");
        Aramco.Core.Entities.Company company = new(CompanyName, description);
        AramcoDbContext.Companies.Add(company);
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

    //public void Deactivate(string CompanyName)
    //{
    //    throw new NotImplementedException();
    //}

    public Core.Entities.Company GetCompanyByName(string CompanyName)
    {
        if (String.IsNullOrEmpty(CompanyName)) throw new ArgumentNullException();
        Aramco.Core.Entities.Company? dbCompany = AramcoDbContext.Companies.Find(c => c.CompanyName.ToLower() == CompanyName.ToLower());
        if(dbCompany is null)
            throw new NotFoundException($"{CompanyName} is not found");
        Console.WriteLine($"id:  {dbCompany.Id} \n" + 
                          $"Company Name:  {dbCompany.CompanyName} \n"  +
                          $"Company description:  {dbCompany.Description}");
    }

    public void GetDepartmentsIncluded(string CompanyName)
    {
        foreach (var department in AramcoDbContext.Departments)
        {
            if (department.Company.CompanyName.ToLower() == CompanyName.ToLower())
            {
                Console.WriteLine($"Id:  {department.Id} \n" +
                                  $"Name: {department.DepartmentName}\n" +
                                  $"Description: {department.Description}\n");
            }
        }
    }

    public void ShowAll()
    {
        foreach(var company in  AramcoDbContext.Companies)
        {
            Console.WriteLine($"Company Id:  {company.Id};   Company Name: {company.CompanyName}");
        }
    }
}
