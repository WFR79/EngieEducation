using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education.Classes
{
    public class TextBoxExtensions: TextBox 
    {
        public TextBox OnFocusTextbox(TextBox tb)
        {
            tb.AutoSize = false;
            tb.BorderStyle = BorderStyle.Fixed3D;
            tb.Font = new Font("Arial", 10);

            Point locationTb = tb.Location;
            int width = tb.Width + 5;
            var heigh = tb.Height + 5;

            int difWidth = tb.Width - width;
            int difheigh = tb.Height - heigh;

            tb.Size = new System.Drawing.Size(width, heigh);
            locationTb.X = locationTb.X + difWidth / 2;
            locationTb.Y = locationTb.Y + difheigh / 2;

            //defaultlocationTb = locationTb;
            tb.Location = locationTb;
            return tb;
        }

        public TextBox DefautSizeTbFiche(TextBox tb)
        {
            tb.AutoSize = false;
            tb.BorderStyle = BorderStyle.Fixed3D;
            tb.Font = new Font("Arial", 10);

            Point locationTb = tb.Location;
            int width = tb.Width + 5;
            var heigh = tb.Height + 5;

            int difWidth = tb.Width - width;
            int difheigh = tb.Height - heigh;

            tb.Size = new System.Drawing.Size(width, heigh);
            locationTb.X = locationTb.X + difWidth / 2;
            locationTb.Y = locationTb.Y + difheigh / 2;

            //defaultlocationTb = locationTb;
            tb.Location = locationTb;
            return tb;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
        }




    }
}
