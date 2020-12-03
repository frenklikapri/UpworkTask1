using AutoMapper;
using AutoMapper.QueryableExtensions;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UpworkTask.Dtos;
using UpworkTask.Helpers;
using UpworkTask.Interfaces;

namespace UpworkTask.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly Logger _logger;
        private readonly DataContext _dbContext;
        private readonly MapperConfiguration _mapper;

        public UsersRepository(DataContext dbContext, MapperConfiguration mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<PagedList<UserDto>> GetUsersAsync(PaginationParams paginationParams)
        {
            try
            {
                var usersQuery = _dbContext
                    .Users
                    .OrderBy(u => u.FirstName).ThenBy(u => u.LastName)
                    .ProjectTo<UserDto>(_mapper)
                    .AsQueryable();

                var users = await PagedList<UserDto>.CreateAsync(usersQuery, paginationParams.PageNumber, paginationParams.PageSize);

                return users;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}