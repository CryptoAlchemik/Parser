
namespace Application.UserTgs.Interfaces
{
    public interface IUpdateUserTgCommand<T> : IUpdateEntityCommand<UserTg>
    {
        Task<string> UpdateUserTgNameAsync(string username, long chatid);
    }
}
