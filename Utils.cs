using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    internal static class Utils<T> where T : User
    {
        private static string[] fileAccess = { "administrators", "doctors", "patients" };

        private static T? userData;
        public static T? UserData { 
            get 
            {
                return userData;
            }
            set 
            {
                UserData = value;
            }
        }

        public static T? HandleLogin(string id, string password)
        {

            var options = new JsonSerializerOptions { WriteIndented = true };

            foreach (string file in fileAccess)
            {
                string jsonText = File.ReadAllText(file + ".json");

                List<T> users = JsonSerializer.Deserialize<List<T>>(jsonText, options);

                foreach (T user in users)
                {
                    if (user.id == id && user.password == password)
                    {
                        userData = user;
                        break;
                    }
                }

            }

            if (userData == null)
            {
                Console.WriteLine("User not found");
                return null;
            }
            else if (userData.id == id && userData.password == password)
            {
                Console.WriteLine("Login successful");
                return userData;
            }
            else
            {
                Console.WriteLine("Invalid credentials");
                return null;
            }
        }


    }
}
