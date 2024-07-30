
namespace ThalesEmployees.Business.Services
{
    public interface IService<T, TId>
    {
        ValueTask<T[]> GetAllAsync();
    }
}
