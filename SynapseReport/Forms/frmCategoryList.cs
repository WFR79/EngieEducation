using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseCore.Entities;
using SynapseReport.Entities;
using SynapseReport.Functionalities;
using SynapseAdvancedControls;

namespace SynapseReport.Forms
{
    public partial class frmCategoryList : SynapseForm
    {
        public frmCategoryList()
        {
            InitializeComponent();

            olvCategory.AddDecoration(new EditingCellBorderDecoration(true));
            TypedObjectListView<Category> tlist = new TypedObjectListView<Category>(olvCategory);
            tlist.GenerateAspectGetters();

            colCat.AspectGetter = delegate(object x)
            {
                return (((Category)x).LABEL.ToString());
            };
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            listCategory();

            mnuOpen.Enabled = false;
            ctxOpen.Enabled = false;
            tsbOpen.Enabled = false;
            mnuDelete.Enabled = false;
            ctxDelete.Enabled = false;
            tsbDelete.Enabled = false;
        }

        private void ExitForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listCategory()
        {
            IList<Category> _Categories = new List<Category>();

            switch (GlobalVariables.selectedOrigin.ORIGIN)
            { 
                case Origin.Module:
                    _Categories = Category.Load("WHERE FK_MODULE=" + GlobalVariables.selectedOrigin.MODULEID);
                    break;
                case Origin.Interface:
                   _Categories = Category.Load("WHERE FK_INTERFACE=" + GlobalVariables.selectedOrigin.INTERFACEID);
                    break;
            }
            olvCategory.SetObjects(_Categories);
        }

        private void olvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvCategory.SelectedItems.Count > 0)
            {
                tsbOpen.Enabled = true;
                mnuOpen.Enabled = true;
                ctxOpen.Enabled = true;
                mnuDelete.Enabled = true;
                ctxDelete.Enabled = true;
                tsbDelete.Enabled = true;
            }
            else
            {
                tsbOpen.Enabled = false;
                mnuOpen.Enabled = false;
                ctxOpen.Enabled = false;
                mnuDelete.Enabled = false;
                ctxDelete.Enabled = false;
                tsbDelete.Enabled = false;
            }
        }

        private void Edit_Category(object sender, EventArgs e)
        {
            if (olvCategory.SelectedItems.Count > 0)
            {
                frmCategory fCategory = new frmCategory();
                fCategory.Action = "EDIT";
                fCategory.CategoryID = ((Category)olvCategory.SelectedObject).ID;
                if (fCategory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    listCategory();
                }
            }
        }

        private void New_Category(object sender, EventArgs e)
        {
            frmCategory fCategory = new frmCategory();
            fCategory.Action = "NEW";
            fCategory.CategoryID = 0;
            if (fCategory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listCategory();
            }
        }

        private void Delete_Category(object sender, EventArgs e)
        {
            IList<Definition> _Ldef = Definition.LoadFromQuery("SELECT * FROM SYNAPSEREPORT_DEFINITION WHERE FK_CATEGORY=" + ((Category)olvCategory.SelectedObject).ID);
            if (_Ldef.Count > 0)
            {
                GlobalFunctions.showMessage("INFO", "Info.0003");
            }
            else
            {
                if (GlobalFunctions.showMessage("QUEST", "Quest.0001") == System.Windows.Forms.DialogResult.Yes)
                {
                    SynapseLabel synLbl = SynapseLabel.LoadByID(((Category)olvCategory.SelectedObject).LABELID);

                    SynapseCore.Database.DBFunction.StartTransaction();
                    try
                    {
                        synLbl.delete();
                        ((Category)olvCategory.SelectedObject).delete();

                        SynapseCore.Database.DBFunction.CommitTransaction();

                        listCategory();
                    }
                    catch (Exception ex)
                    {
                        SynapseCore.Database.DBFunction.RollbackTransaction();
                        GlobalFunctions.showMessage("ERR", "Err.9999", ex.Message);
                    }
                }
            }
        }
    }
}
