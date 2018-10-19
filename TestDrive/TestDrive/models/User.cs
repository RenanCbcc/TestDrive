using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class User
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string dataNascimento { get; set; }
        public string telefone { get; set; }
    }

    public class ResultOfLogin
    {
        public User usuario { get; set; }
    }
}
