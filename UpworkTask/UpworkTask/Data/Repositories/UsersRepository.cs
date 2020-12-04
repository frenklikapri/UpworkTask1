using AutoMapper;
using AutoMapper.QueryableExtensions;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UpworkTask.Dtos;
using UpworkTask.Entities;
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

        public async Task<bool> DeleteAllUsersAsync()
        {
            try
            {
                _dbContext.Users.RemoveRange(await _dbContext.Users.ToListAsync());

                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var userInDb = await _dbContext
                    .Users
                    .FirstAsync(u => u.Id == id);

                _dbContext.Users.Remove(userInDb);

                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            try
            {
                var usersQuery = _dbContext
                    .Users
                    .OrderBy(u => u.FirstName).ThenBy(u => u.LastName)
                    .ProjectTo<UserDto>(_mapper)
                    .AsQueryable();

                var users = await usersQuery
                    .ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        public async Task<SaveUserResultDto> ImportUsersAsync(List<UserDto> users)
        {
            try
            {
                var usersInDb = await _dbContext
                    .Users
                    .ToListAsync();

                // Remove users that already exists
                users = users
                    .Where(u => !usersInDb.Any(uDb => uDb.Email == u.Email))
                    .ToList();

                foreach (var user in users)
                {
                    var mapper = new Mapper(_mapper);
                    var toAdd = mapper.Map<User>(user);

                    _dbContext.Users.Add(toAdd);
                }

                var success = await _dbContext.SaveChangesAsync() > 0 || users.Count == 0;

                return new SaveUserResultDto
                {
                    Success = success
                };
            }
            catch (Exception ex)
            {
                return new SaveUserResultDto
                {
                    Success = false,
                    UserExists = false
                };
            }
        }

        public async Task<SaveUserResultDto> SaveUserAsync(UserDto userDto)
        {
            try
            {
                var exists = await _dbContext
                    .Users
                    .AnyAsync(u => u.Email == userDto.Email && u.Id != userDto.Id);

                if (exists)
                    return new SaveUserResultDto
                    {
                        UserExists = true
                    };

                if (userDto.Id > 0)
                {
                    var userInDb = await _dbContext
                        .Users
                        .FirstAsync(u => u.Id == userDto.Id);

                    userInDb.FirstName = userDto.FirstName;
                    userInDb.LastName = userDto.LastName;
                    userInDb.Email = userDto.Email;

                    var success = await _dbContext.SaveChangesAsync() > 0;

                    return new SaveUserResultDto
                    {
                        Success = success
                    };
                }
                else
                {
                    var mapper = new Mapper(_mapper);

                    var toAdd = mapper.Map<User>(userDto);

                    _dbContext.Users.Add(toAdd);

                    var success = await _dbContext.SaveChangesAsync() > 0;

                    return new SaveUserResultDto
                    {
                        Success = success
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new SaveUserResultDto
                {
                    Success = false,
                    UserExists = false
                };
            }
        }
    }
}