/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 25-05-2012
 * Time: 11:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Synapse
{
	partial class frmUserEdit
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.txt_UserID = new System.Windows.Forms.TextBox();
            this.txt_Firstname = new System.Windows.Forms.TextBox();
            this.txt_Lastname = new System.Windows.Forms.TextBox();
            this.lbl_UserID = new System.Windows.Forms.Label();
            this.lbl_Firstname = new System.Windows.Forms.Label();
            this.lbl_LastName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_UserID
            // 
            this.txt_UserID.Location = new System.Drawing.Point(6, 52);
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.Size = new System.Drawing.Size(296, 20);
            this.txt_UserID.TabIndex = 0;
            // 
            // txt_Firstname
            // 
            this.txt_Firstname.Location = new System.Drawing.Point(6, 101);
            this.txt_Firstname.Name = "txt_Firstname";
            this.txt_Firstname.Size = new System.Drawing.Size(296, 20);
            this.txt_Firstname.TabIndex = 1;
            // 
            // txt_Lastname
            // 
            this.txt_Lastname.Location = new System.Drawing.Point(6, 150);
            this.txt_Lastname.Name = "txt_Lastname";
            this.txt_Lastname.Size = new System.Drawing.Size(296, 20);
            this.txt_Lastname.TabIndex = 2;
            // 
            // lbl_UserID
            // 
            this.lbl_UserID.BackColor = System.Drawing.Color.Transparent;
            this.lbl_UserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserID.Location = new System.Drawing.Point(6, 26);
            this.lbl_UserID.Name = "lbl_UserID";
            this.lbl_UserID.Size = new System.Drawing.Size(100, 23);
            this.lbl_UserID.TabIndex = 3;
            this.lbl_UserID.Text = "UserID";
            this.lbl_UserID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl_UserID.Click += new System.EventHandler(this.Label1Click);
            // 
            // lbl_Firstname
            // 
            this.lbl_Firstname.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Firstname.Location = new System.Drawing.Point(6, 75);
            this.lbl_Firstname.Name = "lbl_Firstname";
            this.lbl_Firstname.Size = new System.Drawing.Size(100, 23);
            this.lbl_Firstname.TabIndex = 4;
            this.lbl_Firstname.Text = "Firstname";
            this.lbl_Firstname.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl_LastName
            // 
            this.lbl_LastName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LastName.Location = new System.Drawing.Point(6, 124);
            this.lbl_LastName.Name = "lbl_LastName";
            this.lbl_LastName.Size = new System.Drawing.Size(100, 23);
            this.lbl_LastName.TabIndex = 5;
            this.lbl_LastName.Text = "LastName";
            this.lbl_LastName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_UserID);
            this.groupBox1.Controls.Add(this.txt_Lastname);
            this.groupBox1.Controls.Add(this.lbl_LastName);
            this.groupBox1.Controls.Add(this.txt_UserID);
            this.groupBox1.Controls.Add(this.lbl_Firstname);
            this.groupBox1.Controls.Add(this.txt_Firstname);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 189);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New / Edit user";
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(268, 207);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.Btn_OKClick);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(187, 207);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // frmUserEdit
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(355, 241);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUserEdit";
            this.Text = "frmUserEdit";
            this.Load += new System.EventHandler(this.FrmUserEditLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.TextBox txt_Firstname;
		private System.Windows.Forms.TextBox txt_Lastname;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_OK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbl_LastName;
		private System.Windows.Forms.Label lbl_Firstname;
		private System.Windows.Forms.Label lbl_UserID;
		private System.Windows.Forms.TextBox txt_UserID;
	}
}
