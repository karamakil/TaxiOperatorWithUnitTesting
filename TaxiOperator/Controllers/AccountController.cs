using Microsoft.AspNetCore.Mvc;
using System;
using TaxiOperator.BLL.Interface;
using TaxiOperator.BLL.Models;

namespace TaxiOperator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService tokenService;
        #region ctor

        public AccountController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        #endregion

        #region Login

        [HttpPost("login")]
        public ActionResult<UserModel> Login(UserModel userModel)
        {
            try
            {
                var user = TaxiOperator.BLL.Manager.UserManager.Find(userModel.UserName, userModel.Password);
                if (user == null) return Unauthorized("Invaled Credientials");
                return new UserModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password,
                    Token = this.tokenService.CreateToken(user),
                };
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        #endregion

    }
}
