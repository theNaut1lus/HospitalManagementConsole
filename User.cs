using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    public abstract class User
    {
        public string id, password, fullname, role;
        public string[] options = Array.Empty<string>();

        public User(string id, string password, string fullname, string role)
        {
            this.id = id;
            this.password = password;
            this.fullame = fullname;
            this.role = role;
        }

        public abstract void Menu();

    }
}
