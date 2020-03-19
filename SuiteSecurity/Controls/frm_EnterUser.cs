/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 30-05-2012
 * Time: 10:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SynapseCore.Controls
{
	/// <summary>
	/// Description of frm_EnterUser.
	/// </summary>
	public partial class frm_EnterUser : Form
	{
		public string UserID;
		public frm_EnterUser()
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			UserID=textBox1.Text;
		}
	}
}
