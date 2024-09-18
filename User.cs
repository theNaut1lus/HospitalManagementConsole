using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    public abstract class User
    {
        public string id, password, fullName, role;
        public string[] options = Array.Empty<string>();

        public User(string id, string password, string fullName, string role)
        {
            this.id = id;
            this.password = password;
            this.fullName = fullName;
            this.role = role;
            switch (role)
            {
                case "Patient":
                    options = new string[] { 
                        "1.List patient Details", 
                        "2. List my doctor details", 
                        "3. List all appointments", 
                        "4. Book appointment",
                        "5. Exit to login",
                        "6: Exit System"
                    };
                    break;
                case "Doctor":
                    options = new string[] {
                        "1. List doctor details",
                        "2. List patients",
                        "3. List appointments",
                        "4. Check particular patient",
                        "5. List appointment with patient",
                        "6. Logout",
                        "7. Exit"
                        };
                    break;
                case "Administrator":
                    options = new string[] {
                        "1. List all doctors",
                        "2. Check doctor details",
                        "3. List all patients",
                        "4. Check patient details",
                        "5. Add doctor",
                        "6. Add patient",
                        "7. Logout",
                        "8. Exit"
                        };
                    break;
                default:
                    throw new Exception("Invalid Role");
            }
        }

        public abstract void Menu();

        //User base class destructor doing garbage collection
        ~User() 
        {
            switch (role)
            {
                //depending on role, ensure that current logged on user has a file created in the DB, otherwise create a file and write it's contents
                //check if file exists in respective DB, if doesnt then create before object is destroyed.
                case "Patient":
                    break;
                case "Doctor":
                    break;
                case "Administrator":

                default:
                    throw new Exception("Invalid Role");
            }

        }
}
