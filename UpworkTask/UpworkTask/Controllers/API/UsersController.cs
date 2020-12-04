using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

        [HttpPost]
        [Route("api/users/delete-all")]
        public async Task<IHttpActionResult> DeleteAllUsers()
        {
            var deleted = await _usersRepository.DeleteAllUsersAsync();

            return Ok(new
            {
                Success = deleted
            });
        }

        [HttpPost]
        [Route("api/users/import-users")]
        public async Task<IHttpActionResult> ImportUsers()
        {
            try
            {

                var file = HttpContext.Current.Request.Files["excelFile"];

                if (file == null)
                    return Ok(new
                    {
                        Success = false
                    });

                var users = new List<UserDto>();

                using (var stream = file.InputStream)
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                                var user = new UserDto
                                {
                                    FirstName = reader.GetString(0),
                                    LastName = reader.GetString(1),
                                    Email = reader.GetString(2),
                                };

                                users.Add(user);
                            }
                        } while (reader.NextResult());
                    }
                }

                // Remove column names
                if (users.Count > 0)
                    users.RemoveAt(0);

                var result = await _usersRepository.ImportUsersAsync(users);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Success = false
                });
            }
        }
    }
}
