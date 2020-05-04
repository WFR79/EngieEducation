using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education.Classes.Extensions
{
    public class ComboBoxExt : ComboBox
    {
        private ComboBox combobox;
        public ComboBoxExt()
        {
            Panel newPanel = new Panel();
            Size sizeCb = this.Size;
            newPanel.Size = new Size(sizeCb.Width + 1, sizeCb.Height + 1);
            newPanel.BackColor = Color.Red;
            newPanel.Controls.Add(this);
            //this.Parent = newPanel;
            //FlatStyle = FlatStyle.Flat;
            //BackColor = Color.White;
            //FlatAppearance.BorderColor = BorderColor;
            //FlatAppearance.BorderSize = BorderSize;
        }

        public ComboBox OnFocusTextbox(ComboBox tb)
        {
            tb.AutoSize = false;
            tb.Font = new Font("Arial", 10);

            Point locationTb = tb.Location;
            int width = tb.Width + 6;
            var heigh = tb.Height + 6;

            int difWidth = tb.Width - width;
            int difheigh = tb.Height - heigh;

            tb.Size = new System.Drawing.Size(width, heigh);
            locationTb.X = locationTb.X + difWidth / 2;
            locationTb.Y = locationTb.Y + difheigh / 2;

            //defaultlocationTb = locationTb
            tb.Location = locationTb;
            return tb;
        }

        public ComboBox DefautSizeTbFiche(ComboBox tb)
        {
            tb.AutoSize = false;
            tb.Font = new Font("Arial", 9);

            Point locationTb = tb.Location;
            int width = 186; 
            var height = 22;

            int difWidth = tb.Width - width;
            int difheigh = tb.Height - height;

            tb.Size = new System.Drawing.Size(width, height);
            //locationTb.X = locationTb.X + difWidth / 2;
            //locationTb.Y = locationTb.Y + difheigh / 2;

            ////defaultlocationTb = locationTb;
            //tb.Location = locationTb;
            return tb;
        }

        protected override void OnEnter(EventArgs e)
        {
            this.combobox = this;
            this.combobox.AutoSize = false;
            this.combobox.Font = new Font("Arial", 10);

            Point locationTb = this.combobox.Location;
            int width = this.combobox.Width + 6;
            var heigh = this.combobox.Height + 6;

            int difWidth = this.combobox.Width - width;
            int difheigh = this.combobox.Height - heigh;

            this.combobox.Size = new System.Drawing.Size(width, heigh);
            locationTb.X = locationTb.X + difWidth / 2;
            locationTb.Y = locationTb.Y + difheigh / 2;

            //defaultlocationTb = locationTb
            this.combobox.Location = locationTb;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
        }

        protected override void OnTextChanged(EventArgs e)
        {
            combobox = this;
            combobox.CausesValidation = true;
        }

        protected override void OnLeave(EventArgs e)
        {
            this.combobox = this;
            this.combobox.AutoSize = false;
            this.combobox.Font = new Font("Arial", 8.25f );

            Point locationTb = this.combobox.Location;
            int width = this.combobox.Width;
            var heigh = this.combobox.Height;

            int difWidth = this.combobox.Width - width;
            int difheigh = this.combobox.Height - heigh;

            this.combobox.Size = new System.Drawing.Size(width, heigh);
            locationTb.X = locationTb.X + difWidth / 2;
            locationTb.Y = locationTb.Y + difheigh / 2;

            //defaultlocationTb = locationTb
            this.combobox.Location = locationTb;

        }



        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
