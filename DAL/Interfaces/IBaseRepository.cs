namespace Mortiz.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool create(T entity);
        Task<List<T>> SelectAll();
        T Get(int id);
        bool Delete(int id);

    }
}
