using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLF.Models
{/// <summary>
/// 
/// </summary>
    public class Reservation
    {
        public User MadeBy { get; set; }
        public bool CanBeCancelledBy(User user)
        {
            // case 1
            if (user.IsAdmin)
                return true;
            // case 2
            if (MadeBy == user)
                return true;
            // case 3
            return false;
        }
    }
}