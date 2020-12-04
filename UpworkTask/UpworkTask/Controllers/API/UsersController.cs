using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UpworkTask.Dtos;
using UpworkTask.Helpers;
using UpworkTask.Interfaces;

namespace UpworkTask.Controllers.API
{
    public class UsersController : BaseApiController
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = await _usersRepository.GetUsersAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveUser(UserDto userDto)
        {
            var result = await _usersRepository.SaveUserAsync(userDto);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            var deleted = await _usersRepository.DeleteUserAsync(id);

            return Ok(new
            {
                Success = deleted
            });
        }
    }
}
