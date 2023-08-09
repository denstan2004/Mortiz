namespace Mortiz.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
     void Create(T entity);
      public  Task<List<T>> SelectAll();
        T Get(int id);
        bool Delete(int id);

    }
}
