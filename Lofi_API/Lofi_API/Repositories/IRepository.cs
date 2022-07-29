namespace Lofi_API.Repositories
{
    public interface IRepository<T1, T2> where T1 : class
    {
        Task<IEnumerable<T1>> GetALL();
        Task<T1> GetById(T2 id);
        Task<T2> Insert(T1 entity);
        Task Delete(T2 id);
        Task Save();
    }
}
