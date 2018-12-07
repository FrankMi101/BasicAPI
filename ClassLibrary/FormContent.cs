using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class FormContent
    {    
        public string ItemCode { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
    }
    public class FormContent1: FormContent
    {
        public int IDs { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
      
    }
    
}
