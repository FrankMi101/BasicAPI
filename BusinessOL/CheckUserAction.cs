using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessOL
{
    public static class CheckUserAction
    {
        public static string formComplete = "InComplete";
        public static string SchoolSignedOff = "SignedOff";
        public static string SOSignedOff = "Not";
        public static bool ActionPermission(string action, string userRole)
        {
            if (ActionMessage(action, userRole) == "OK")
                return true;
            else
                return false;
        }
        public static string ActionMessage(string action, string userRole)
        {
            var returnMessage = "";
            if (action == "OpenForm")
                returnMessage = "OK";
            if (action == "SchoolSignOff")
            {
                if (userRole == "Principal" || userRole == "Admin")
                {
                    if (formComplete == "Complete")
                    { returnMessage = "OK"; }
                    else
                        returnMessage = "Please complete the Form, and then sign Off.";
                }
                else { returnMessage = "Has no permission to sign off the Form!"; }
            }
            if (action == "SOSignOff")
            {
                if (userRole == "Superintendent" || userRole == "Admin")
                {
                    if (SchoolSignedOff == "SignedOff")
                    { returnMessage = "OK"; }
                    else
                    { returnMessage = "Please has the school Principal signed off first!"; }
                }
                else { returnMessage = "Has no permission to sign off the Form!"; }
            }
            if (action == "Publish")
            {
                if (userRole == "Principal" || userRole == "Admin")
                {
                    if (SOSignedOff == "SignedOff")
                        returnMessage = "OK";
                    else
                        returnMessage = "Please has your school superintendent signe off first!";
                }
                else { returnMessage = "Has no permission to Publish the Form!"; }
            }
            return returnMessage;
        }
    }
}
