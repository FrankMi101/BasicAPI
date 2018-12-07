using ClassLibrary;
using DataAccess;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BusinessOL
{
    public static class FormData
    {
        public static string TitlebyCode(string itemCode)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_GetItemLabelNew @Operate,@UserID,@UserRole,@ItemCode";
                ParameterSP0 parameter = new ParameterSP0 {ItemCode = itemCode };
                 return GeneralDataAccess.TextValue(sp, parameter);
              }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Error Title";
            }

        }
        public static string Title(string itemCode)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_FormData_WebAPI @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@ItemCode";
                ParameterSP0 parameter = new ParameterSP0 { Operate ="Title", ItemCode = itemCode };
                return GeneralDataAccess.TextValue(sp, parameter);
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Error Title";
            }
        }
        public static string Content(ParameterSP0 parameter)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_FormData_WebAPI @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@ItemCode,@Value";
            //    ParameterSP0 parameter = new ParameterSP0 { Operate = "Content", SchoolYear = schoolYear, SchoolCode = schoolCode, ItemCode = itemCode, Value = value };
                return GeneralDataAccess.TextValue(sp, parameter);
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "";
            }
        }

        public static string Content(string operate, string userID, string userRole, string schoolYear, string schoolCode, string itemCode)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_FormData_WebAPI @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@ItemCode";
                ParameterSP0 parameter = new ParameterSP0 { Operate ="Content" ,SchoolYear = schoolYear, SchoolCode=schoolCode, ItemCode = itemCode };
                return GeneralDataAccess.TextValue(sp, parameter);
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "";
            }
        }
        public static string Content(string operate, string userID, string userRole, string schoolYear, string schoolCode, string itemCode,string value)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_FormData_WebAPI @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@ItemCode,@Value";
                ParameterSP0 parameter = new ParameterSP0 { Operate = "Content", SchoolYear = schoolYear, SchoolCode = schoolCode, ItemCode = itemCode,Value =value };
                return GeneralDataAccess.TextValue(sp, parameter);
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "";
            }
        }
       
        public static List<FormContent> ListofContent(string schoolYear, string schoolCode)
        {
            try
            {
                string sp = "dbo.tcdsb_PLF_FormData_WebAPI @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode";
                ParameterSP0 parameter = new ParameterSP0 { Operate = "Content", UserID = "mif",SchoolYear=schoolYear, SchoolCode=schoolCode };
                List<FormContent> myList = GeneralDataAccess.GetListofTypeT<FormContent>(sp, parameter);
           
                return myList;
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return null;
            }

        }
        static string sp = "dbo.tcdsb_PLF_FormNew @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@ItemCode";
        public static string TextContent(string operate, string userID, string userRole, string schoolYear, string schoolCode, string itemCode)
        {try
            {
                ParameterSP0 parameter = new ParameterSP0 { Operate = operate, UserID = userID, ItemCode = itemCode, SchoolYear = schoolYear, SchoolCode = schoolCode };
                return GeneralDataAccess.TextValue(sp, parameter);
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "";
            }
         }
        public static string TextContent(string operate, string userID, string userRole, string schoolYear, string schoolCode, string itemCode, string value)
        {
            try
            {
                ParameterSP0 parameter = new ParameterSP0 { Operate = operate, UserID = userID, ItemCode = itemCode, SchoolYear = schoolYear, SchoolCode = schoolCode, Value=value };
                return GeneralDataAccess.TextValue(sp + ",@Value", parameter);
                // return FormContent.TextValue(operate, userID, userRole, itemCode, schoolYear, schoolCode, value);
                // return "Successfully";
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return "Failed";
            }
        }

        public static void AssembliesPLFForm(Page myPage, string userID, string schoolYear, string schoolCode)
        {
            try
            {
                 
                List<FormContent> plfList = FormData.ListofContent(schoolYear, schoolCode);

                foreach (FormContent myitem in plfList)
                {
                    var code = myitem.ItemCode;
                    Label newLable = (Label)myPage.FindControl("Label" + code);
                    newLable.Text = myitem.Title;
                    HtmlTextArea newArea = (HtmlTextArea) myPage.FindControl("Text" + code);
                    newArea.Value = myitem.Notes;
                }
            }
            catch (Exception ex)
            {
                var ms = ex.Message;
            }

        }
    }
}
