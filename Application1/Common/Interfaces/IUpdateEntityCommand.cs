

namespace Application.Common.Interfaces
{
    public interface IUpdateEntityCommand<T> where T : class
    {
        Task<T> UpdateEntitykAsync(T entity);
    }
}
