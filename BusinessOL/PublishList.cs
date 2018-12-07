using ClassLibrary;
using DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessOL
{
    public static class PublishandSignOffList
    {
        public static void BindGridView(ref GridView myGridView, string listPage, string method, string userID, string schoolYear, string schoolCode)
        {
            try
            {
                if (listPage == "SchoolHistory")
                {
                    string sp = "dbo.tcdsb_PLF_SchoolHistoryNew @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode";
                    ParameterSP parameter = new ParameterSP { Operate = method, UserID = userID,SchoolYear = schoolYear, SchoolCode = schoolCode };

                    List<School> schools = GeneralDataAccess.GetListofTypeT<School>(sp, parameter);
                    //schools = PublishListDA.GetSchoolHistroy("Get", "", userID, schoolyear, schoolcode);
                    myGridView.DataSource = schools;
                    myGridView.DataBind();
                }
           }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }
      
        public static void BindGridView(ref GridView myGridView, string listPage, string method, string userID, string schoolYear, string schoolCode, string schoolArea)
        {
            try
            {
                if (listPage == "SchoolListbyArea")
                {
                      string sp = "dbo.tcdsb_PLF_AreaSchoolList @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@SchoolArea";
                    ParameterSP2 parameter = new ParameterSP2 { Operate = "", UserID = userID,  SchoolYear = schoolYear, SchoolCode = schoolCode, SchoolArea = schoolArea };

                    List<School> schools = GeneralDataAccess.GetListofTypeT<School>(sp, parameter);

                    // List<School> schools = PublishList.GetAreaSchools("Get", "Role", userID, schoolyear, schoolcode, schoolArea); ;
                    myGridView.DataSource = schools;
                    myGridView.DataBind();
                }
            }
            catch (System.Exception ex)
            {
                string em = ex.Message;
            }
        }
   
    }
}
