namespace Aramco.Business.Interfaces;

public interface ICompanyServices
{
    void Create(string? CompanyName, string description);
    void Delete(string CompanyName);
    void Deactivate(string CompanyName);
    void ShowAll();
    Aramco.Core.Entities.Company GetCompany(int Id);
    Aramco.Core.Entities.Company GetCompany(int Id);
    void GetDepartmentsIncluded(string CompanyName);
}
