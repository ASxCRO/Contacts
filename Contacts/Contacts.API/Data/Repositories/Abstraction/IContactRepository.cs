using Contacts.API.Data.Entities;
using static Contacts.API.Data.Repositories.IRepository;

public interface IContactRepository : IRepository<Contact>
{
    int CountByTerm(string term);
}