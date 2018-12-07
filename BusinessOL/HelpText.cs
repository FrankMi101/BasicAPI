using ClassLibrary;
using DataAccess;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessOL
{
    public class HelpText
    {
        private static string sp = "dbo.EPA_sys_HelpTextContent";
        public HelpText() { }
        public static string GetHelpContent(string operate, string userID, string categoryID, string areaID, string itemCode)
        {
            try
            {
                ParameterSP4 parameter = new ParameterSP4 { Operate = operate, UserID = userID, ItemCode = itemCode, CategoryID = categoryID, AreaID = areaID, ItemType = "Help" };
                return GeneralDataAccess.TextValue(sp, parameter);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
        public static string GetHelpContent(string operate, string userID, string categoryID, string areaID, string itemCode, string value)
        {
            try
            {
                sp += ",@Value";
                ParameterSP4 parameter = new ParameterSP4 { Operate = operate, UserID = userID, ItemCode = itemCode, CategoryID = categoryID, AreaID = areaID, ItemType = "Help", Value =value };
                return GeneralDataAccess.TextValue(sp, parameter);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
    }
}
