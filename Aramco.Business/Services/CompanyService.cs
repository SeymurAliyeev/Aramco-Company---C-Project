using Aramco.Business.Interfaces;
using Aramco.Business.Utilities.Exceptions;
using Aramco.DataAccess.Contexts;
using System.Data.SqlTypes;

namespace Aramco.Business.Services;

public class CompanyService : ICompanyServices
{
    public void Create(string? CompanyName, string description)
    {
        if(String.IsNullOrEmpty(CompanyName))throw new ArgumentNullException();
        Aramco.Core.Entities.Company? dbCompany = 
            AramcoDbContext.Companies.Find(c=>c.CompanyName.ToLower() == CompanyName.ToLower());
        if (dbCompany is not null) 
            throw new AlreadyExistException($"{dbCompany.CompanyName} is already exist");
        Aramco.Core.Entities.Company company = new(CompanyName, description);
        AramcoDbContext.Companies.Add(company);
    }

    public void Deactivate(string CompanyName)
    {
        throw new NotImplementedException();
    }

    public void Delete(string CompanyName)
    {
        throw new NotImplementedException();
    }

    public Aramco.Core.Entities.Company GetCompany(int Id)
    {
        throw new NotImplementedException();
    }

    public void GetDepartmentsIncluded(string CompanyName)
    {
        throw new NotImplementedException();
    }

    public void ShowAll()
    {
        throw new NotImplementedException();
    }
}
