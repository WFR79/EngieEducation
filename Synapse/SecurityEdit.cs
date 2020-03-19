/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 23-05-2012
 * Time: 08:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Synapse
{
	/// <summary>
	/// Description of SecurityEdit.
	/// </summary>
	public partial class SecurityEdit : SynapseForm
	{
		IList<SynapseControl> AllControls;
		public SecurityEdit()
		{
			InitializeComponent();
            ColName.AspectGetter = delegate(object x)
            {
                SynapseProfile_Control spc = (SynapseProfile_Control)x;
                foreach (SynapseControl ctrl in AllControls)
                {
                    if (ctrl.ID == spc.FK_CONTROLID)
                        return ctrl.CTRL_NAME;
                }
                return "Unknown";
            };

            ColForm.AspectGetter = delegate(object x)
            {
                SynapseProfile_Control spc = (SynapseProfile_Control)x;
                foreach (SynapseControl ctrl in AllControls)
                {
                    if (ctrl.ID == spc.FK_CONTROLID)
                        return ctrl.FORM_NAME;
                }
                return "Unknown";
            };

            ColVisible.ImageGetter = delegate(object x)
            {
                SynapseProfile_Control spc = (SynapseProfile_Control)x;
                if (spc.IS_VISIBLE)
                    return 0;
                else
                    return 1;
            };

            ColActive.ImageGetter = delegate(object x)
            {
                SynapseProfile_Control spc = (SynapseProfile_Control)x;
                if (spc.IS_ACTIVE)
                    return 0;
                else
                    return 1;
            };

            ColVisible.AspectToStringConverter = delegate(object x)
            {
                return string.Empty;
            };
            ColActive.AspectToStringConverter = delegate(object x)
            { return string.Empty; };


            ColVisible.AspectPutter = delegate(object x, object newvalue)
            {
                SynapseProfile_Control spc = (SynapseProfile_Control)x;
                spc.IS_VISIBLE = (bool)newvalue;
                spc.save();
            };

            ColActive.AspectPutter = delegate(object x, object newvalue)
            {
                SynapseProfile_Control spc = (SynapseProfile_Control)x;
                spc.IS_ACTIVE = (bool)newvalue;
                spc.save();
            };
		}
		
		void SecurityEditLoad(object sender, EventArgs e)
		{
            tsbAddControl.Enabled = false;
            tsbDeleteControl.Enabled = false;
            tsbRemoveControl.Enabled = false;

            AllControls = SynapseControl.Load();

            var Modules = SynapseModule.Load();
			cb_Module.DataSource=Modules.OrderBy(x => x.FriendlyName.ToString()).ToList();
			cb_Module.ValueMember="ID";
			cb_Module.DisplayMember="FriendlyName";
            cb_Module.SelectedIndex = 0;

			lst_ListOfControl.DisplayMember="CTRL_NAME";
			lst_ListOfControl.ValueMember="ID";
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			var pc = SynapseProfile_Control.Load("WHERE FK_PROFILEID = " + ((SynapseProfile)cb_Profiles.SelectedItem).ID);
			
			objectListView1.SetObjects(pc);
            objectListView1.Refresh();
		}
		
		void ListBox1MouseDown(object sender, MouseEventArgs e)
		{
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                lst_ListOfControl.SelectedIndex = lst_ListOfControl.IndexFromPoint(e.X, e.Y);
                return;
            }

			int indexOfItem = lst_ListOfControl.IndexFromPoint(e.X, e.Y);
  			if(indexOfItem >= 0 && indexOfItem < lst_ListOfControl.Items.Count)  // check we clicked down on a string
  			{
    		// Set allowed DragDropEffect to Copy selected 
    		// from DragDropEffects enumberation of None, Move, All etc.
    			lst_ListOfControl.DoDragDrop(lst_ListOfControl.Items[indexOfItem], DragDropEffects.Copy );
			}
	    }

		
		void ObjectListView1DragDrop(object sender, DragEventArgs e)
		{
			SynapseControl c = (SynapseControl)e.Data.GetData(typeof(SynapseControl));
            addControltoProfile(c);
		}
		
		void ObjectListView1DragEnter(object sender, DragEventArgs e)
		{
			e.Effect= DragDropEffects.Copy;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
		}
		
        //void ToolStripButton1Click(object sender, EventArgs e)
        //{
        //    foreach (SynapseProfile_Control spc in objectListView1.Objects)
        //    {
        //        spc.save();
        //    }
        //    ComboBox1SelectedIndexChanged(this,e);
        //}
		
		void ComboBox3SelectedIndexChanged(object sender, EventArgs e)
		{
			cb_Form.Text="";
			cb_Form.Items.Clear();
			foreach (SynapseControl C in AllControls)
			{
                if (!cb_Form.Items.Contains(C.FORM_NAME) && C.FK_MODULE_ID == ((SynapseModule)cb_Module.SelectedItem).ID)
					cb_Form.Items.Add(C.FORM_NAME);
			}
			if (cb_Form.Items.Count>0)
				cb_Form.SelectedIndex=0;

            var ControlCollection = SynapseControl.Load("WHERE FORM_NAME='" + cb_Form.SelectedItem + "' AND FK_MODULE_ID=" + ((SynapseModule)cb_Module.SelectedItem).ID + " Order by CTRL_NAME");

            lst_ListOfControl.DataSource = ControlCollection.OrderBy(x => x.CTRL_NAME).ToList();

            var Groups = SynapseProfile.Load("WHERE FK_MODULEID=" + ((SynapseModule)cb_Module.SelectedItem).ID);
            cb_Profiles.DataSource = Groups.OrderBy(x => x.TECHNICALNAME).ToList();
            cb_Profiles.DisplayMember = "TECHNICALNAME";
            cb_Profiles.ValueMember = "ID";
            cb_Profiles.SelectedIndex = 0;
		}
		
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
            refreshControls();
		}

        private void refreshControls()
        {
            var ControlCollection = SynapseControl.Load("WHERE FORM_NAME='" + cb_Form.SelectedItem + "' AND FK_MODULE_ID=" + ((SynapseModule)cb_Module.SelectedItem).ID + " Order by CTRL_NAME");

            if (ckNotAttributed.Checked)
            {
                foreach (SynapseProfile_Control c in objectListView1.Objects)
                {
                   // ControlCollection.Remove(SynapseControl.LoadByID(c.FK_CONTROLID));
                    ControlCollection.Remove(ControlCollection.Where(x => x.ID==c.FK_CONTROLID).FirstOrDefault());
                }
            }
            
            lst_ListOfControl.DataSource=ControlCollection.OrderBy(x => x.CTRL_NAME).ToList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objectListView1.SelectedObjects != null)
            {
                foreach (SynapseProfile_Control c in objectListView1.SelectedObjects)
                {
                    objectListView1.RemoveObject(c);
                    c.delete();

                    if (ckNotAttributed.Checked)
                    {
                        refreshControls();
                    }
                }
            }
        }

        private void objectListView1_CellEditFinishing(object sender, SynapseAdvancedControls.CellEditEventArgs e)
        {

        }

        private void ctxAddControl_Click(object sender, EventArgs e)
        {
            addControltoProfile();
        }

        private void addControltoProfile(bool isActive=false, bool isVisible=false)
        {
            foreach (SynapseControl c in lst_ListOfControl.SelectedItems)
            {
                SynapseProfile_Control spc = new SynapseProfile_Control();
                spc.FK_CONTROLID = c.ID;
                spc.FK_PROFILEID = (Int64)cb_Profiles.SelectedValue;
                spc.IS_ACTIVE = isActive;
                spc.IS_VISIBLE = isVisible;

                objectListView1.AddObject(spc);

                spc.save();

                if (ckNotAttributed.Checked)
                {
                    refreshControls();
                }
            }
        }

        private void addControltoProfile(SynapseControl c)
        {
                SynapseProfile_Control spc = new SynapseProfile_Control();
                spc.FK_CONTROLID = c.ID;
                spc.FK_PROFILEID = (Int64)cb_Profiles.SelectedValue;
                spc.IS_ACTIVE = false;
                spc.IS_VISIBLE = false;

                objectListView1.AddObject(spc);

                spc.save();

                if (ckNotAttributed.Checked)
                {
                    refreshControls();
                }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctxDeleteControl_Click(object sender, EventArgs e)
        {
            deleteControl((SynapseControl)lst_ListOfControl.SelectedItem);
        }

        private void deleteControl(SynapseControl c)
        {
            if (MessageBox.Show(GetLabel("Quest.0004"), GetLabel("Quest"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                foreach (SynapseControl cs in lst_ListOfControl.SelectedItems)
                {
                    cs.delete();
                }
                refreshControls();

                if (lst_ListOfControl.Items.Count == 0)
                {
                    ComboBox3SelectedIndexChanged(this, null);
                }
            }
        }

        private void lst_ListOfControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_ListOfControl.SelectedItems.Count == 0)
            {
                tsbAddControl.Enabled = false;
                tsbDeleteControl.Enabled = false;
            }
            else
            {
                tsbAddControl.Enabled = true;
                tsbDeleteControl.Enabled = true;
            }
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objectListView1.SelectedObjects.Count > 0)
            {
                tsbRemoveControl.Enabled = true;
            }
            else
            {
                tsbRemoveControl.Enabled = false;
            }
        }

        private void ctxAddFalseFalse_Click(object sender, EventArgs e)
        {
            addControltoProfile(false, false);
        }

        private void ctxAddTrueFalse_Click(object sender, EventArgs e)
        {
            addControltoProfile(true, false);
        }

        private void ctxAddTrueTrue_Click(object sender, EventArgs e)
        {
            addControltoProfile(true, true);
        }

        private void ctxAddFalseTrue_Click(object sender, EventArgs e)
        {
            addControltoProfile(false, true);
        }

        private void ckNotAttributed_CheckedChanged(object sender, EventArgs e)
        {
            refreshControls();
        }
    }
}
