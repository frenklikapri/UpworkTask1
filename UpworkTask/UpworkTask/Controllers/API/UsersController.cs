using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
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
        public async Task<IHttpActionResult> GetUsers([FromUri] PaginationParams paginationParams)
        {
            var users = await _usersRepository.GetUsersAsync(paginationParams);

            return Ok(users);
        }
    }
}
