namespace Aramco.Business.Interfaces;

public interface ICompanyServices
{
    void Create(string CompanyName, string description);
    void Delete(string CompanyName);
    void Deactivate(string CompanyName);
    void ShowAll();
    Company GetCompany(int Id);
    void GetDepartmentsIncluded(string CompanyName);
}
