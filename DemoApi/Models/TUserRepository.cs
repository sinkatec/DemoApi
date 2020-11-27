using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Models
{
    /// <summary>
    /// ユーザーリポジトリ
    /// </summary>
    public class TUserRepository : ITUserRepository
    {

        private readonly MyDbContext context;

        public TUserRepository(MyDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Userテーブルから、ログインIDにより、ユーザ情報を検索する
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public List<TUser> GetUser(string loginId)
        {
            return context.TUser.FromSqlInterpolated($"SELECT * FROM t_user WHERE login_id={loginId}").ToList();

        }
    }
}
