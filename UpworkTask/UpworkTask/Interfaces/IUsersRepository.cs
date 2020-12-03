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
        Task<PagedList<UserDto>> GetUsersAsync(PaginationParams paginationParams);
    }
}