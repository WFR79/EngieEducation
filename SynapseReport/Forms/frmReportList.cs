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
using SynapseReport.Entities;
using SynapseReport.Functionalities;
using SynapseAdvancedControls;
using SynapseCore.Database;

namespace SynapseReport.Forms
{
    public partial class frmReportList : SynapseForm
    {
        public frmReportList()
        {
            InitializeComponent();

            olvReport.AddDecoration(new EditingCellBorderDecoration(true));
            TypedObjectListView<Category> tlist = new TypedObjectListView<Category>(olvReport);
            tlist.GenerateAspectGetters();

            colCat.AspectGetter = delegate(object x)
            {
                return (((Definition)x).CATEGORY.ToString());
            };
            colRep.AspectGetter = delegate(object x)
            {
                return (((Definition)x).LABEL.ToString());
            };
            colAva.AspectGetter = delegate(object x)
            {
                return (((Definition)x).AVAILABLE);
            };
            colAva.Renderer = new MappedImageRenderer(new Object[] { true, imageList.Images[0], false, imageList.Images[1] });
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            listReport();

            //mnuOpen.Enabled = false;
            //ctxOpen.Enabled = false;
            tsbOpen.Enabled = false;
            //mnuDelete.Enabled = false;
            //ctxDelete.Enabled = false;
            tsbDelete.Enabled = false;
            tsbCopy.Enabled = false;
        }

        private void ExitForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listReport()
        {
            IList<Definition> _Reports = new List<Definition>();
            switch (GlobalVariables.selectedOrigin.ORIGIN)
            {
                case Origin.Module:
                    _Reports = Definition.LoadFromQuery("SELECT SynapseReport_DEFINITION.ID, SynapseReport_DEFINITION.LABELID, SynapseReport_DEFINITION.FK_CATEGORY, SynapseReport_DEFINITION.AVAILABLE, SynapseReport_CATEGORY.LABELID AS CATEGORYLABELID FROM SynapseReport_DEFINITION INNER JOIN SynapseReport_CATEGORY ON SynapseReport_DEFINITION.FK_CATEGORY=SynapseReport_CATEGORY.ID WHERE SynapseReport_DEFINITION.FK_MODULE=" + GlobalVariables.selectedOrigin.MODULEID);
                    break;
                case Origin.Interface:
                    _Reports = Definition.LoadFromQuery("SELECT SynapseReport_DEFINITION.ID, SynapseReport_DEFINITION.LABELID, SynapseReport_DEFINITION.FK_CATEGORY, SynapseReport_DEFINITION.AVAILABLE, SynapseReport_CATEGORY.LABELID AS CATEGORYLABELID FROM SynapseReport_DEFINITION INNER JOIN SynapseReport_CATEGORY ON SynapseReport_DEFINITION.FK_CATEGORY=SynapseReport_CATEGORY.ID WHERE SynapseReport_DEFINITION.FK_INTERFACE=" + GlobalVariables.selectedOrigin.INTERFACEID);
                    break;
            }
            olvReport.SetObjects(_Reports);
        }

        private void olvReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvReport.SelectedItems.Count > 0)
            {
                tsbOpen.Enabled = true;
                //mnuOpen.Enabled = true;
                //ctxOpen.Enabled = true;
                //mnuDelete.Enabled = true;
                //ctxDelete.Enabled = true;
                tsbDelete.Enabled = true;
                tsbCopy.Enabled = true;
            }
            else
            {
                tsbOpen.Enabled = false;
                //mnuOpen.Enabled = false;
                //ctxOpen.Enabled = false;
                //mnuDelete.Enabled = false;
                //ctxDelete.Enabled = false;
                tsbDelete.Enabled = false;
                tsbCopy.Enabled = false;
            }
        }

        private void Edit_Report(object sender, EventArgs e)
        {
            if (olvReport.SelectedItems.Count > 0)
            {
                Int64 ID = ((Definition)olvReport.SelectedObject).ID;
                if (!GlobalFunctions.formAlreadyOpen("frmReportDetail", ID))
                {
                    frmReportDetail fReportDetail = new frmReportDetail();
                    fReportDetail.Action = "EDIT";
                    fReportDetail.ReportID = ((Definition)olvReport.SelectedObject).ID;
                    fReportDetail.MdiParent = (frmMain)Application.OpenForms["frmMain"];
                    fReportDetail.Show();
                }
            }
        }

        private void New_Report(object sender, EventArgs e)
        {
            frmReportDetail fReportDetail = new frmReportDetail();
            fReportDetail.Action = "NEW";
            fReportDetail.ReportID = 0;
            fReportDetail.MdiParent = (frmMain)Application.OpenForms["frmMain"];
            fReportDetail.Show();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            listReport();
        }

        private void delete_Report(object sender, EventArgs e)
        {
            if (GlobalFunctions.showMessage("QUEST", "Quest.0003") == System.Windows.Forms.DialogResult.Yes)
            {
                Definition reportDef = (Definition)olvReport.SelectedObject;
                List<SynapseLabel> reportLbl = new List<SynapseLabel>();

                foreach (SynapseLabel slbl in ((Definition)olvReport.SelectedObject).LABEL.Labels)
                {
                    reportLbl.Add(slbl);
                }
                IList<Tables> reportTbl = Tables.Load("WHERE FK_REPORT=" + reportDef.ID);
                IList<Field> reportFld = Field.Load("WHERE FK_REPORT=" + reportDef.ID);
                foreach (Field fld in reportFld)
                {
                    foreach (SynapseLabel slbl in fld.ALIAS.Labels)
                    {
                        reportLbl.Add(slbl);
                    }
                }
                IList<Filter> reportFlt = Filter.Load("WHERE FK_REPORT=" + reportDef.ID);
                foreach (Filter flt in reportFlt)
                {
                    foreach (SynapseLabel slbl in flt.LABEL.Labels)
                    {
                        reportLbl.Add(slbl);
                    }
                }

                SynapseCore.Database.DBFunction.StartTransaction();
                try
                {
                    foreach (SynapseLabel lbl in reportLbl)
                        lbl.delete();
                    foreach (Tables tbl in reportTbl)
                        tbl.delete();
                    foreach (Field fld in reportFld)
                        fld.delete();
                    foreach (Filter flt in reportFlt)
                        flt.delete();
                    reportDef.delete();

                    SynapseCore.Database.DBFunction.CommitTransaction();

                    listReport();
                }
                catch (Exception ex)
                {
                    SynapseCore.Database.DBFunction.RollbackTransaction();
                    GlobalFunctions.showMessage("ERR", "Err.9999", ex.Message);
                }
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            SynapseCore.Database.DBFunction.StartTransaction();

            Definition reportDef = Definition.LoadByID(((Definition)olvReport.SelectedObject).ID);
            Definition reportNew = new Definition();
            try
            {
                reportNew.ID = 0;
                reportNew.QRY_JOIN = reportDef.QRY_JOIN;
                reportNew.QRY_CONDITION = reportDef.QRY_CONDITION;
                reportNew.QRY_GROUP = reportDef.QRY_GROUP;
                reportNew.FK_MODULE = reportDef.FK_MODULE;
                reportNew.FK_INTERFACE = reportDef.FK_INTERFACE;
                reportNew.FK_CATEGORY = reportDef.FK_CATEGORY;
                reportNew.FK_TYPE = reportDef.FK_TYPE;
                reportNew.ADDCATEGORY = reportDef.ADDCATEGORY;
                reportNew.AVAILABLE = false;

                Int64 reportNew_lblID = SynapseLabel.GetNextID();
                foreach (SynapseLanguage lang in SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE"))
                {
                    SynapseLabel newlabel = new SynapseLabel();

                    newlabel.LABELID = reportNew_lblID;
                    newlabel.LANGUAGE = lang.CODE;
                    newlabel.TEXT = SynapseLabel.Load("WHERE LANGUAGE='" + lang.CODE + "' AND LABELID=" + reportDef.LABELID).FirstOrDefault().TEXT + " (*)";
                    newlabel.save();
                }
                reportNew.LABELID = reportNew_lblID;

                reportNew.save();

                foreach (Tables tbl in Tables.Load("WHERE FK_REPORT=" + reportDef.ID))
                {
                    Tables tblNew = new Tables();
                    tblNew.ID = 0;
                    tblNew.TABLENAME = tbl.TABLENAME;
                    tblNew.TYPE = tbl.TYPE;
                    tblNew.FK_REPORT = reportNew.ID;

                    tblNew.save();
                }

                foreach (Field fld in Field.Load("WHERE FK_REPORT=" + reportDef.ID))
                {
                    Field fldNew = new Field();
                    fldNew.ID = 0;
                    fldNew.FIELDNAME = fld.FIELDNAME;
                    fldNew.FORMAT = fld.FORMAT;
                    fldNew.POSITION = fld.POSITION;
                    fldNew.WIDTH = fld.WIDTH;
                    fldNew.FK_REPORT = reportNew.ID;

                    Int64 fldNew_lblID = SynapseLabel.GetNextID();
                    foreach (SynapseLanguage lang in SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE"))
                    {
                        SynapseLabel newlabel = new SynapseLabel();

                        newlabel.LABELID = fldNew_lblID;
                        newlabel.LANGUAGE = lang.CODE;
                        newlabel.TEXT = SynapseLabel.Load("WHERE LANGUAGE='" + lang.CODE + "' AND LABELID=" + fld.ALIASID).FirstOrDefault().TEXT;
                        newlabel.save();
                    }
                    fldNew.ALIASID = fldNew_lblID;

                    fldNew.save();
                }

                foreach (Filter flt in Filter.Load("WHERE FK_REPORT=" + reportDef.ID))
                {
                    Filter fltNew = new Filter();
                    fltNew.ID = 0;
                    fltNew.NAME = flt.NAME;
                    fltNew.TYPE = flt.TYPE;
                    fltNew.POSITION = flt.POSITION;
                    fltNew.CTRL_TABLE = flt.CTRL_TABLE;
                    fltNew.CTRL_FIELD = flt.CTRL_FIELD;
                    fltNew.CTRL_CUSTOM = flt.CTRL_CUSTOM;
                    fltNew.DATA_TABLE = flt.DATA_TABLE;
                    fltNew.DATA_VALUE = flt.DATA_VALUE;
                    fltNew.DATA_DISPLAY = flt.DATA_DISPLAY;
                    fltNew.DATA_QUERY = flt.DATA_QUERY;
                    fltNew.WIDTH = flt.WIDTH;
                    fltNew.ADD_TO_REPORTTITLE = flt.ADD_TO_REPORTTITLE;
                    fltNew.IS_LINKED = false;
                    fltNew.LINKED_FILTERID = 0;
                    fltNew.LINKED_FIELD = "";
                    fltNew.CTRL_TYPE = flt.CTRL_TYPE;
                    fltNew.FK_REPORT = reportNew.ID;

                    Int64 fltNew_lblID = SynapseLabel.GetNextID();
                    foreach (SynapseLanguage lang in SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE"))
                    {
                        SynapseLabel newlabel = new SynapseLabel();

                        newlabel.LABELID = fltNew_lblID;
                        newlabel.LANGUAGE = lang.CODE;
                        newlabel.TEXT = SynapseLabel.Load("WHERE LANGUAGE='" + lang.CODE + "' AND LABELID=" + flt.LABELID).FirstOrDefault().TEXT;
                        newlabel.save();
                    }
                    fltNew.LABELID = fltNew_lblID;

                    fltNew.save();
                }

                SynapseCore.Database.DBFunction.CommitTransaction();

                listReport();
            }
            catch (Exception ex)
            {
                SynapseCore.Database.DBFunction.RollbackTransaction();
                GlobalFunctions.showMessage("ERR", "Err.9999", ex.Message);
            }
        }
    }
}
