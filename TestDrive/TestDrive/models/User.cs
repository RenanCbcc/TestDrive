using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public int Id { get; set; }
        
        public User(string _username, string _password)
        {
            UserName = _username;
            Password = _password;
        }
    }
}
