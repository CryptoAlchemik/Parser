

namespace Application.Common.Interfaces
{
    public interface IDeleteEntityCommand
    {
        Task DeleteEntityAsync(bool isdeleted, long id);
    }
}
