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
    public static class AssembleListItem
    {
        public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, ParameterSP parameter)
        {
            string sp = "dbo.tcdsb_PLF_ListDDL2New @Operate,@UserID,@UserRole,@SchoolYear";
            List<List2Item> myList = GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);
            AssemblingMyList(myListControl, myList);
        }
        public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, ParameterSP parameter, object initialValue)
        {
            SetLists(myListControl, parameter);
            SetValue(myListControl, initialValue);
        }
        public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, string operate, string userID, string userRole, string schoolYear)
        {
            //  string sp = "dbo.tcdsb_PLF_ListDDL2New @Operate,@UserID,@UserRole,@SchoolYear";
            ParameterSP parameter = new ParameterSP { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear };
            SetLists(myListControl, parameter);

            // List<List2Item> myList = UListItem.GetLists(operate, userID, userRole, schoolYear); /// new List<List2Item>();
            //   AssemblingMyList(myListControl, myList);
        }
        private static void AssemblingMyList(System.Web.UI.WebControls.ListControl myListControl, List<List2Item> myList)
        {
            try
            {
                myListControl.Items.Clear();
                myListControl.DataSource = myList;
                myListControl.DataTextField = "MyText";
                myListControl.DataValueField = "MyValue";
                myListControl.DataBind();
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }
        private static void AssemblingMyList(System.Web.UI.WebControls.ListControl myListControl, List<List2Item> myList, string ValueField, string TextField)
        {
            try
            {
                myListControl.Items.Clear();
                myListControl.DataSource = myList;
                myListControl.DataTextField = TextField;
                myListControl.DataValueField = ValueField;
                myListControl.DataBind();
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }
        public static void SetValue(System.Web.UI.WebControls.ListControl myListControl, object objectValue)

        {
            try
            {
                myListControl.ClearSelection();
                if (myListControl.Items.Count > 0)
                {
                    if (myListControl.Items.Count == 1)
                    {
                        myListControl.SelectedIndex = 0;
                    }
                    else
                    {
                        if (objectValue != null)
                        {
                            if (objectValue.ToString() == "0")
                            {
                                myListControl.SelectedIndex = 0;
                            }
                            else
                            {
                                foreach (ListItem item in myListControl.Items)
                                {
                                    if (item.Value.ToString().ToLower() == objectValue.ToString().ToLower())
                                    {
                                        item.Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (myListControl.Items.Count > 0)
                { myListControl.SelectedIndex = 0; }
                else
                {
                    var error = ex.Message;
                    throw new Exception(error);
                }

            }

        }

        public static void SetLists2(System.Web.UI.WebControls.DropDownList myListControl, System.Web.UI.WebControls.DropDownList myListControl2, string operate, string userID, string userRole, string schoolYear, string schoolCode)
        {
            ParameterSP parameter = new ParameterSP { Operate = operate, UserID = userID, UserRole = userRole, SchoolYear = schoolYear, SchoolCode = schoolCode };
            SetLists2(myListControl, myListControl2, parameter);
            // string sp = "dbo.tcdsb_PLF_ListSchoolsNew @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode";
            ////  List<List2Item> myList = GeneralDataAccess.GetLists(sp, parameter);
            //List<List2Item> myList = GeneralDataAccess.GetObjectList<List2Item>(sp, parameter);

            ////List<List2Item> myList = new List<List2Item>();
            ////   myList = DAListItem.GetLists(operate, userID);
            ////  myList = UListItem.GetLists(operate, userID, userRole, schoolYear, schoolCode);
            //AssemblingMyList(myListControl, myList, "myValue", "myValue"); // school Code DDL
            //AssemblingMyList(myListControl2, myList, "myValue", "myText"); // School Name DDL
        }
        public static void SetLists2(System.Web.UI.WebControls.DropDownList myListControl, System.Web.UI.WebControls.DropDownList myListControl2, ParameterSP parameter)
        {
            string sp = "dbo.tcdsb_PLF_ListSchoolsNew @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode";
            List<List2Item> myList = GeneralDataAccess.GetListofTypeT<List2Item>(sp, parameter);
            AssemblingMyList(myListControl, myList, "myValue", "myValue"); // school Code DDL

            AssemblingMyList(myListControl2, myList, "myValue", "myText"); // School Name DDL
        }

        public static void SetLists2(System.Web.UI.WebControls.DropDownList myListControl, System.Web.UI.WebControls.DropDownList myListControl2, ParameterSP parameter, object initialValue)
        {
            SetLists2(myListControl, myListControl2, parameter);
            SetValue(myListControl, initialValue);
            SetValue(myListControl2, initialValue);
        }

    }
}
