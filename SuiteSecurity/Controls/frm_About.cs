using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseCore.Entities;
using SynapseCore.Database;

namespace SynapseCore.Controls
{
    public partial class frm_About : SynapseForm
    {
        public frm_About()
        {
            InitializeComponent();
            //listView1.BackColor = Color.FromArgb(30, Color.White);
            //listView2.BackColor = Color.FromArgb(30, Color.White);
        }

        private void frm_About_Load(object sender, EventArgs e)
        {
            lbl_CurrentUser.Text = FormUser.UserID;

            foreach (SynapseModule mod in FormUser.Modules)
            {
                if (mod.ID == 1)
                    lbl_Version.Text = mod.VERSION;
                if (mod.ID == FormUser.CurrentModuleID)
                { 
                    lbl_module.Text = mod.FriendlyName.ToString();
                    lbl_ModuleVersion.Text =  mod.VERSION;
                }
                    
                listView1.Items.Add(new ListViewItem(mod.FriendlyName.ToString(), "module"));
            }
            foreach(SynapseProfile profile in FormUser.Groups)
                listView2.Items.Add(new ListViewItem(profile.TECHNICALNAME,"group"));
            foreach (DBConnection Conn in DBFunction.ConnectionManager.Connections.Values)
            {
                ListViewItem lvi = new ListViewItem(Conn.Name, "connection");
                lvi.SubItems.Add(Conn.State.ToString());
                lvi.SubItems.Add((DateTime.Now- Conn.LastCheck).TotalMinutes.ToString("Not used for 0 min"));
                listView3.Items.Add(lvi);
            }
        }

        private void Change_Views(object sender, EventArgs e)
        {
            ctxTiles.Checked = false;
            ctxIcons.Checked = false;
            ctxList.Checked = false;
            ctxDetail.Checked = false;

            ToolStripMenuItem mnu;
            mnu = (ToolStripMenuItem)sender;

            switch (mnu.Name)
            {
                case "ctxTiles":
                    listView1.View = View.Tile;
                    listView2.View = View.Tile;
                    listView3.View = View.Tile;
                    ctxTiles.Checked = true;
                    break;
                case "ctxIcons":
                    listView1.View = View.LargeIcon;
                    listView2.View = View.LargeIcon;
                    listView3.View = View.LargeIcon;
                    ctxIcons.Checked = true;
                    break;
                case "ctxList":
                    listView1.View = View.List;
                    listView2.View = View.List;
                    listView3.View = View.List;
                    ctxList.Checked = true;
                    break;
                case "ctxDetail":
                    listView1.View = View.Details;
                    listView2.View = View.Details;
                    listView3.View = View.Details;
                    ctxDetail.Checked = true;
                    break;
                default:
                    listView1.View = View.LargeIcon;
                    listView2.View = View.LargeIcon;
                    listView3.View = View.LargeIcon;
                    ctxIcons.Checked = true;
                    break;
            }
        }
    }
}
