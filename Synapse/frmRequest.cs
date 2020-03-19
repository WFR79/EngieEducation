using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using SynapseCore.Entities;
using SynapseCore.Controls;

namespace Synapse
{
    public partial class frmRequest : SynapseForm
    {
        private string mailAlias="";
        private string mailError = "";
        IList<SynapseModule> Modules;
        public frmRequest()
        {
            InitializeComponent();
            gbDetail.Enabled = false;
            btSend.Enabled = false;
            tsbSend.Enabled = false;

            loadModules();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            lvModule.Columns[0].Text = GetLabel("frmRequest.lvModule.colModule");
            lvModule.Columns[1].Text = GetLabel("frmRequest.lvModule.colDescription");
            lvModule.Columns[2].Text = GetLabel("frmRequest.lvModule.colVersion");
        }

        private void loadModules()
        {
            lvModule.Items.Clear();

            Modules = SynapseModule.Load();
            var UserModuleID = from m in FormUser.Modules select m.ID;
            foreach (SynapseModule Module in from m in Modules where !UserModuleID.Contains(m.ID) select m)
            {
                if (Module.IS_ACTIVE && Module.IS_REQUESTABLE)
                {
                    if (File.Exists(Application.StartupPath + "\\ModulesIcons\\" + Module.TECHNICALNAME + ".ico"))
                    {
                        smallImages.Images.Add(Module.TECHNICALNAME, Image.FromFile(Application.StartupPath + "\\ModulesIcons\\" + Module.TECHNICALNAME + ".ico"));
                    }
                    else
                    {
                        smallImages.Images.Add(Module.TECHNICALNAME, Image.FromFile(Application.StartupPath + "\\ModulesIcons\\Default.png"));
                    }

                    ListViewItem item;
                    item = new ListViewItem(Module.FriendlyName.ToString());
                    item.Tag = 0;
                    item.SubItems.Add(Module.Description.ToString());
                    item.SubItems.Add(Module.VERSION);
                    item.ImageKey = Module.TECHNICALNAME;

                    lvModule.Items.Add(item);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvModule.SelectedItems.Count > 0)
            {
                txFor.Text = lvModule.SelectedItems[0].SubItems[0].Text;
                txReason.Text = "";
                SynapseModule mod = (from x in Modules where x.FriendlyName.ToString() == lvModule.SelectedItems[0].Text select x).FirstOrDefault();
                string[] to = (from s in mod.GetOwners() select s.UserID).ToArray();
                string[] alias = (from s in mod.GetOwners() select s.FIRSTNAME + " "+s.LASTNAME).ToArray();
                txTo.Text = string.Join(", ", alias);
                mailAlias = string.Join(",", to);
                mailAlias = mailAlias.Replace("CORP\\", "");
                gbDetail.Enabled = true;
                btSend.Enabled = true;
                tsbSend.Enabled = true;
            }
            else
            {
                txFor.Text = "";
                txReason.Text = "";
                txTo.Text = "";
                mailAlias = "";
                gbDetail.Enabled = false;
                btSend.Enabled = false;
                tsbSend.Enabled = false;
            }
        }

        private void SendMail(object sender, EventArgs e)
        {
            if (txReason.Text.Trim() == "")
            {
                MessageBox.Show(GetLabel("Err.0001"), GetLabel("frmRequest"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sendMail())
                {
                    MessageBox.Show(string.Format(GetLabel("Mess.0001"), txTo.Text));
                    txFor.Text = "";
                    txReason.Text = "";
                    txTo.Text = "";
                    mailAlias = "";
                    gbDetail.Enabled = false;
                    btSend.Enabled = false;
                }
                else
                {
                    MessageBox.Show(string.Format(GetLabel("Err.0002"), mailError), GetLabel("frmRequest"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean sendMail()
        {
            try
            {
                // Create the Outlook application.
                Outlook.Application oApp = new Outlook.Application();

                // Create a new mail item.
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMsg.GetInspector;
                // Set HTMLBody. 
                //add the body of the email
                oMsg.HTMLBody = string.Format(GetLabel("Mail.0001"), txFor.Text, txFor.Text, txReason.Text, FormUser.FirstName + " " + FormUser.LastName);
                //Add an attachment.
                //String sDisplayName = "MyAttachment";
                //int iPosition = (int)oMsg.Body.Length + 1;
                //int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                //now attached the file
                //Outlook.Attachment oAttach = oMsg.Attachments.Add(@"C:\\fileName.jpg", iAttachType, iPosition, sDisplayName);
                //Subject line
                oMsg.Subject = string.Format(GetLabel("Mail.0002"), txFor.Text);
                // Add a recipient.
                Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                //oRecips.Add(mailAlias);
                //oRecips.ResolveAll();
                // Change the recipient in the next line if necessary.
                //Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(mailAlias);
                string[] alias = mailAlias.Split(new string[] { "," }, StringSplitOptions.None);
                foreach (String recipient in alias) 
                { 
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient); 
                    
                    if (!oRecip.Resolve())
                        oRecips.Remove(oRecips.Count); 
                }
                //oRecip.Resolve();
                // Send.
                oMsg.Send();
                // Clean up.
                //oRecip = null;
                oRecips = null;
                oMsg = null;
                oApp = null;

                return true;
            }//end of try block
            catch (Exception ex)
            {
                mailError = ex.Message;
                return false;
            }
        }

        private void frmRequest_Load(object sender, EventArgs e)
        {

        }

        private void ExitForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
