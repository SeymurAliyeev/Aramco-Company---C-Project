namespace Aramco.Business.Interfaces;

public interface ICompanyServices
{
    void Create(string? CompanyName, string? description);
    void Delete(string CompanyName);
    void Deactivate(string CompanyName);
    Aramco.Core.Entities.Company GetCompanyByName(string CompanyName);
    void GetDepartmentsIncluded(string CompanyName);
    void ShowAll();
}
