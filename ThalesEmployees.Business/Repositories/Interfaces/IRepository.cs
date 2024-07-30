
namespace ThalesEmployees.Business.Repositories
{
    public interface IRepository<T, TId>
    {
        ValueTask<T[]> GetAllAsync();
    }
}
