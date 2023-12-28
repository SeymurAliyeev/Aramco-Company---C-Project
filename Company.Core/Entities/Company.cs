using Company.Core.Interfaces;

namespace Aramco.Core.Entities;

public class Company : IEntity
{
    public int Id { get; }
    public string CompanyName { get; set; }
    private static int _id;
    public string Description { get; set; }

    public Company(string name, string description)
    {
        Id = _id++;
        CompanyName = name;
        Description = description;
    }
}
