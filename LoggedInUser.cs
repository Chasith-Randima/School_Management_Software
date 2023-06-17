using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class LoggedInUser
    {

        //public static string userName = "";
        //public static string userRole = "";
        private static string userName;
        private static string userRole;

        public static void setUserName(string uName)
        {
            userName = uName;
        }

        public static void setUserRole(string uRole)
        {
            userRole = uRole;
        }

        public static string getUserName()
        {
            return userName;
        }

        public  static string getUserRole()
        {
            return userRole;
        }
    }
}
