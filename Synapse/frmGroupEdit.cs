/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 25-05-2012
 * Time: 12:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using SynapseCore.Entities;
using System.Collections.Generic;

namespace Synapse
{
	/// <summary>
	/// Description of frmGroupEdit.
	/// </summary>
	public partial class frmGroupEdit : Form
	{
		SynapseProfile CurrentProfile;
		public frmGroupEdit(ref SynapseProfile Profile, IList<SynapseModule> ModuleCollection)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			CurrentProfile=Profile;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			cb_Module.DisplayMember="TECHNICALNAME";
			cb_Module.ValueMember="ID";
			cb_Module.DataSource=ModuleCollection;
		}
		
		void Btn_OKClick(object sender, EventArgs e)
		{
			CurrentProfile.FK_ModuleID=(Int64)cb_Module.SelectedValue;
			CurrentProfile.TECHNICALNAME=txt_TechName.Text;
			CurrentProfile.IS_OWNER=chk_Owner.Checked;
			CurrentProfile.LEVEL=(Int64)num_Level.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
		}
		
		void FrmGroupEditLoad(object sender, EventArgs e)
		{
			cb_Module.SelectedValue=CurrentProfile.FK_ModuleID;
			txt_TechName.Text=CurrentProfile.TECHNICALNAME;
			chk_Owner.Checked=CurrentProfile.IS_OWNER;
			try
			{
			num_Level.Value=CurrentProfile.LEVEL;
			}
			catch (Exception ex)
			{}
		}

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
	}
}
