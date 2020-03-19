using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_Education
{
    public partial class UC_Authentification : UserControl
    {
        public BindingSource ds_Education_Formations = new BindingSource();
        private AgentDataAccess db = new AgentDataAccess();
        private static UC_Authentification _instance;

        public static UC_Authentification Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_Authentification();
                return _instance;
            }
        }
        public UC_Authentification()
        {
            
            InitializeComponent();
            this.labelengieID.BackColor = System.Drawing.Color.Transparent;
            this.labelpwd.BackColor = System.Drawing.Color.Transparent;
            this.LabelAuthentification.BackColor = System.Drawing.Color.Transparent;
        }

        private void UC_Authentification_Load(object sender, EventArgs e)
        {

        }
    }
}
