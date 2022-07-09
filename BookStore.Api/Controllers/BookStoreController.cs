using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        UserRepository _respository = new UserRepository();

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                User userServer = _respository.Login(model);
                if(userServer == null)
                {
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Invalid Username or Password!");

                }
                UserModel user = new UserModel(userServer);
                return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), e.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                User user = _respository.Register(model);
                if(user == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Bad Request");

                }
                return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), e.Message);
            }
        }
    }
}
