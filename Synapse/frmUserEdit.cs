/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 25-05-2012
 * Time: 11:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using SynapseCore.Entities;

namespace Synapse
{
	/// <summary>
	/// Description of frmUserEdit.
	/// </summary>
	public partial class frmUserEdit : Form
	{
		SynapseUser CurrentUser;
		
		public frmUserEdit(ref SynapseUser User)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			CurrentUser=User;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		
		void FrmUserEditLoad(object sender, EventArgs e)
		{
			txt_Firstname.Text=CurrentUser.FIRSTNAME;
			txt_Lastname.Text=CurrentUser.LASTNAME;
			txt_UserID.Text=CurrentUser.UserID;
		}
		
		void Btn_OKClick(object sender, EventArgs e)
		{
			CurrentUser.FIRSTNAME=txt_Firstname.Text;
			CurrentUser.LASTNAME=txt_Lastname.Text;
			CurrentUser.UserID=txt_UserID.Text;
		}
	}
}
