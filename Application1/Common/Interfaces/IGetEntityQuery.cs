
namespace Application.Common.Interfaces
{
    public interface IGetEntityQuery<T> where T : class
    {
        Task<T> GetEntityAsync(long id);
    }
}
