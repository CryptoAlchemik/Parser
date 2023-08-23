

namespace Application.Common.Interfaces
{
    public interface ICeateEntityCommand<T> where T : class
    {
        Task<bool> CreateEntityAsync(T entity);
    }
}
