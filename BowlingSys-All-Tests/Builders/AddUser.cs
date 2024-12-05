using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingSys.Contracts.UserDtos;

namespace BowlingSYS_Tests.Builders
{
    public class AddUser
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public AddUser(string userName, string password, string email) 
        {
            this.userName = userName;
            this.password = password;
            this.email = email;
        }

        public UserCreationDto UserCreationBuilder()
        {
            return new UserCreationDto
            {
                Email = email,
                Username = userName,
                Password = password,
                Forename = "Test1",
                Surname = "Test1"
            };
        }
    }
}
