using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpworkTask.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class SaveUserResultDto
    {
        public bool Success { get; set; }
        public bool UserExists { get; set; }
    }
}