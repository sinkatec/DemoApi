using DemoApi.Models;
using DemoApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    /// <summary>
    /// User コントローラー
    /// </summary>
    [Route("[controller]")]
    public class DemoApiController : ControllerBase1
    {
        // loggerとuserRepositoryを定義する
        private readonly ILogger<DemoApiController> logger;
        private readonly ITUserRepository userRepository;

        // loggerとuserRepositoryのアノテーション
        public DemoApiController(ILogger<DemoApiController> logger, ITUserRepository userRepository)
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }

        /// <summary>
        ///  ログインIDにより、ユーザ情報を取得する
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Post(TUser user)
        {
            // 開始ロガー
            this.logger.LogInformation("DemoApiController Post 開始");

            // ユーザ情報を検索する
            List<TUser> userDb = this.userRepository.GetUser(user.login_id);
            ResposeViewModel vm = new ResposeViewModel();
            TUser queryUser = userDb.First();

            if (queryUser != null && queryUser.password.Equals(user.password))
            {
                vm.errcode = "0";
                vm.errmsg = "";
            }
            else 
            {
                vm.errcode = "10001";
                vm.errmsg = "ログインIDまたはパスワードに誤りがあります。";
            }

            // 終了ロガー
            this.logger.LogInformation("DemoApiController Post 終了");

            return new JsonResult(vm);
        }
    }
}
