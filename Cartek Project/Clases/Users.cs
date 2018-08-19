using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartek_Project
{
    public class Users
    {
        public string user;
        public string password;

        public Users(string User, string Password)
        {
            this.user = User;
            this.password = Password;
        }
        public string getUser()
        {
            return user;
        }
    }
}
