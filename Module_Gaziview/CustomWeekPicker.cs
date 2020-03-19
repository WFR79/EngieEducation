using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module_Gaziview
{
    public class CustomWeekPicker:MonthCalendar
    {

        protected override void OnDateChanged(DateRangeEventArgs drevent)
        {
            
            
            
            //this.SetSelectionRange(firstdate, firstdate.AddDays(6));
            
            base.OnDateChanged(drevent);
        }
       
    }
}
