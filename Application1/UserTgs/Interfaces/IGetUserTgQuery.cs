using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTgs.Interfaces
{
    public interface IGetUserTgQuery
    {
        Task<UserTg?> GetUserTgQueryAsync(long chatid);
    }
}
