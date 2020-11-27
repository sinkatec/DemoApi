using Microsoft.EntityFrameworkCore;
using Npgsql;
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

            //var conn = this.context.Database.GetDbConnection();
            //NpgsqlCommand cmd = new NpgsqlCommand("SELECT t2.dept_name FROM t_user t1, t_dept t2 WHERE t1.login_id=t2.login_id AND t1.login_id=@id");
            //cmd.Parameters.Add(new NpgsqlParameter("@id", "user001"));
            //var list = Utils.EntityFrameworkCoreExtension.SqlQuery<QueryTest>(conn, cmd);

            return context.TUser.FromSqlInterpolated($"SELECT * FROM t_user WHERE login_id={loginId}").ToList();

        }
    }
}
