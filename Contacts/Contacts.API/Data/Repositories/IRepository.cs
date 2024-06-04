namespace Contacts.API.Data.Repositories
{
    public interface IRepository
    {
         public interface IRepository<T> where T : class
    {
        int Add(T item);

        void Remove(int id);

        void Update(T item);

        T FindByID(int id); 

        IEnumerable<T> FindAll(int pageNumber, int pageSize, string sortField, string term);
        int CountAll();
    }
    }
}