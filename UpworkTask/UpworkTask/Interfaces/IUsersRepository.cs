using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UpworkTask.Dtos;
using UpworkTask.Helpers;

namespace UpworkTask.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<SaveUserResultDto> SaveUserAsync(UserDto userDto);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> DeleteAllUsersAsync();
        Task<SaveUserResultDto> ImportUsersAsync(List<UserDto> users);
    }
}