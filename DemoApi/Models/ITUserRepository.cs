using DemoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Models
{
    /// <summary>
    /// ユーザーリポジトリインタフェース
    /// </summary>
    public interface ITUserRepository
    {
        List<TUser> GetUser(string loginId);
    }
}
