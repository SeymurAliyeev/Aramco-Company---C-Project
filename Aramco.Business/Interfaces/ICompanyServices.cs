namespace Aramco.Business.Interfaces;

public interface ICompanyServices
{
    void Create(string? CompanyName, string? description);
    void Deactivate(string CompanyName);
    void GetCompanyByName(string CompanyName);
    void GetDepartmentsIncluded(string CompanyName);
    void ShowAllDeactivatedCompanies();
    void ShowAll();
    bool IsCompanyExist();
}
