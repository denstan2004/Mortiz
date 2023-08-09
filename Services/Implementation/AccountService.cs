using Mortiz.DAL.Interfaces;
using Mortiz.Domain.Entity;
using Mortiz.Domain.Response;
using Mortiz.Domain.ViewModel;
using Mortiz.Services.Interfaces;
using System.Security.Claims;
using System.Linq;
using Domain.Enum;
using Mortiz.Domain.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Mortiz.Domain.Helpers;

namespace Mortiz.Services.Implementation
{
    public class AccountService : IAccountService
    {
       
        private readonly IBaseRepository<User> _userRepository;



        public AccountService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
          
        }


        public Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var users = await _userRepository.SelectAll();
                var user = users.FirstOrDefault(x => x.Email == model.Email);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "користувач не знайдений"
                    };
                }

                if (user.Password != HashPasswordHelper.HashPassowrd(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Невірний пароль"
                    };
                }
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
           try
            {
                var users = await _userRepository.SelectAll();
                var user = users.FirstOrDefault(x => x.Email==model.Email);
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "користувач з таким email вже існує",
                    };
                }
                else
                {
                    user = new User()
                    {
                        Name = "Default",
                        Email = model.Email,
                        Password = HashPasswordHelper.HashPassowrd(model.Password),
                        Role = Roles.User,
                    };
                     _userRepository.Create(user);
                  var result =  Authenticate(user);
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Data = result,
                        Description = "added",
                        StatusCode = StatusCode.OK
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
