using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementConsole
{
    internal static class Utils<T>
    {
        public static string GetFileData(T userObject)
        {
            return userObject.ToString();
        }

        public static string SetFileData(T userObject)
        {
            return userObject.ToString();
        }

      
    }
}
