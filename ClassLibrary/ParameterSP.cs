using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ParameterSP
    {
        public string Operate { get; set; }
        public string UserID { get; set; }
        public string UserRole { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
    }
    public class ParameterSP0 : ParameterSP
    {
        public string ItemCode { get; set; }
        public string Value { get; set; }
    }

    public class ParameterSP1 : ParameterSP
    {
        public string ActionType { get; set; }
        public string ActionDate { get; set; }

    }
    public class ParameterSP2 : ParameterSP
    {
        public string SchoolArea { get; set; }

    }
    public class ParameterSP3 : ParameterSP
    {
        public string ActionType { get; set; }
        public string TeacherID { get; set; }
        public string Checked { get; set; }
        public string Comments { get; set; }


    }
    public class ParameterSP4 : ParameterSP0 {
        public string CategoryID { get; set; }
        public string AreaID { get; set; }
        public string ItemType { get; set; } 

    }
}


