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
using SynapseCore.Database;
using SynapseAdvancedControls;
using SynapseReport.UserControls;

namespace SynapseReport.Forms
{
    public partial class frmReportDetail : SynapseForm
    {
        private string _action = "";
        private string _actionFilter = "";
        private string _actionExtraLine = "";
        private Int64 _reportID = 0;
        private Definition _report = new Definition();
        Filter _reportFilter;
        ExtraLine _reportExtraLine;
        private IList<Tables> _deletedTables = new List<Tables>();
        private IList<Field> _deletedFields = new List<Field>();
        private IList<Filter> _deletedFilters = new List<Filter>();
        private IList<ExtraLine> _deletedExtraLines = new List<ExtraLine>();

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        public Int64 ReportID
        {
            get { return _reportID; }
            set { _reportID = value; }
        }

        public frmReportDetail()
        {
            InitializeComponent();

            #region AspectGetter
            treeTable.CanExpandGetter = delegate(object x)
            {
                if (x is string)
                {
                    return true;
                }
                else
                    return false;
            };

            treeTable.ChildrenGetter = delegate(object x)
            {
                string _type = (string)x;
                IList<TablesAndViews> _tables=new List<TablesAndViews>();
                switch (GlobalVariables.selectedOrigin.ORIGIN)
                {
                    case Origin.Module:
                        switch (x.ToString())
                        {
                            case "T":
                                _tables = TablesAndViews.LoadFromQuery("SELECT SYS.TABLES.NAME AS TABLENAME, 'T' AS TYPE FROM SYS.TABLES WHERE UPPER(SYS.TABLES.NAME) LIKE '%" + GlobalVariables.selectedOrigin.TECHNICALNAME.ToUpper() + "%' ORDER BY TABLENAME");
                                break;
                            case "V":
                                _tables = TablesAndViews.LoadFromQuery("SELECT SYS.VIEWS.NAME AS TABLENAME, 'V' AS TYPE FROM SYS.VIEWS WHERE UPPER(SYS.VIEWS.NAME) LIKE '%" + GlobalVariables.selectedOrigin.TECHNICALNAME.ToUpper() + "%' ORDER BY TABLENAME");
                                break;    
                        }
                        break;
                    case Origin.Interface:
                        switch (x.ToString())
                        {
                            case "T":
                                _tables = TablesAndViews.LoadFromQuery(GlobalVariables.selectedOrigin.TABLESQUERY + " ORDER BY TABLENAME", GlobalVariables.selectedOrigin.DBCONNECTION);
                                break;
                            case "V":
                                _tables = TablesAndViews.LoadFromQuery(GlobalVariables.selectedOrigin.VIEWSQUERY + " ORDER BY TABLENAME", GlobalVariables.selectedOrigin.DBCONNECTION);
                                break;
                        }
                    break;
                }
                return _tables;
            };

            colName.AspectGetter = delegate(object x)
            {
                if (x is TablesAndViews)
                    return (((TablesAndViews)x).TABLENAME.ToString());
                else
                    switch (x.ToString())
                    { 
                        case "T":
                            return GetLabel("frmReportDetail.Tables");
                        default:
                            return GetLabel("frmReportDetail.Views");
                    }
            };

            colName.ImageGetter = delegate(object x)
            {
                if (x is string)
                {
                    switch (x.ToString())
                    {
                        case "T":
                            return "table";
                        case "V":
                            return "view";
                    }
                    return "";
                }

                return "";
            };

            colName.AspectToStringConverter = delegate(object x)
            {
                if (x is string && !x.ToString().Contains("is not a parameter-less method, property or field"))
                    return x.ToString();
                else
                    return string.Empty;
            };

            colTable.ImageGetter = delegate(object x)
            {
                if (x is Tables)
                {
                    switch (((Tables)x).TYPE)
                    {
                        case "T":
                            return "table";
                        case "V":
                            return "view";
                    }
                    return "";
                }

                return "";
            };

            colField.ImageGetter = delegate(object x)
            {
                if (x is TableField)
                {
                    switch (((TableField)x).FIELDTYPE.ToLower())
                    {
                        case "text":
                        case "ntext":
                        case "varchar":
                        case "nvarchar":
                        case "varchar2":
                        case "char":
                        case "nchar":
                            return "string";
                        case "date":
                        case "time":
                        case "datetime2":
                        case "datetimeoffset":
                        case "smalldatetime":
                        case "datetime":
                        case "timestamp":
                            return "datetime";
                        case "tinyint":
                        case "smallint":
                        case "int":
                        case "real":
                        case "float":
                        case "decimal":
                        case "numeric":
                        case "bigint":
                        case "smallmoney":
                        case "number":
                            return "numeric";
                        case "bit":
                        case "binary":
                            return "boolean";
                    }
                    return "default";
                }

                return "";
            };

            olvCol1.ImageGetter = delegate(object x)
            {
                foreach (Tables _tbl in olvTables.Objects)
                {
                    if (((Field)x).FIELDNAME.Contains(_tbl.TABLENAME))
                    {
                        return "ok";
                    }
                }
                return "notok";
            };

            olvCol2.AspectGetter = delegate(object x)
            {
                return (((Field)x).ALIAS.ToString());
            };

            colFilterLabel.AspectGetter = delegate(object x)
            {
                return (((Filter)x).LABEL.ToString());
            };

            colLineLabel.AspectGetter = delegate(object x)
            {
                return (((ExtraLine)x).LABEL.ToString());
            };

            colFieldFunction.AspectGetter = delegate(object x)
            {
                return GlobalFunctions.LoadFieldFunctionByCode(((ExtraLineField)x).FUNCTIONCODE).LABEL;
            };
            #endregion
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(Mode);

            fillType();
            fillCategory();
            fillTablesAndViews();
            fillControlType();
            fillFunctions();

            switch (_action)
            {
                case "NEW":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Create");

                    _report.ID = 0;
                    _report.LABEL = new LabelBag();
                    _report.LABEL.Labels = new List<SynapseLabel>();

                    foreach (SynapseLanguage lang in SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE"))
                    {
                        SynapseLabel newlabel = new SynapseLabel();

                        newlabel.LABELID = 0;
                        newlabel.LANGUAGE = lang.CODE;
                        newlabel.TEXT = "";
                        _report.LABEL.Labels.Add(newlabel);
                    }
                    ckAddCategory.Checked = false;
                    reportControl1.Enabled = false;
                    break;
                case "EDIT":
                    this.Text = this.Text + " - " + SynapseForm.GetLabel("global.Edit");
                    _report = Definition.LoadByID(_reportID);

                    cbType.SelectedValue = _report.FK_TYPE;
                    cbCategory.SelectedValue = _report.FK_CATEGORY;

                    txReport.Text = _report.LABEL.ToString();
                    ckAddCategory.Checked = _report.ADDCATEGORY;
                    ckAvailable.Checked = _report.AVAILABLE;

                    txFrom.Text = _report.QRY_JOIN;
                    txWhere.Text = _report.QRY_CONDITION;
                    txGroup.Text = _report.QRY_GROUP;

                    IList<Tables> _tables = Tables.Load("WHERE FK_REPORT=" + _reportID + " ORDER BY TABLENAME");
                    olvTables.SetObjects(_tables);

                    IList<Field> _fields = Field.Load("WHERE FK_REPORT=" + _reportID + " ORDER BY POSITION");
                    olvSelectedFields.SetObjects(_fields);

                    IList<Filter> _filters = Filter.Load("WHERE FK_REPORT=" + _reportID + " ORDER BY POSITION");
                    olvFilters.SetObjects(_filters);

                    IList<ExtraLine> _extralines = ExtraLine.Load("WHERE FK_REPORT=" + _reportID + " ORDER BY POSITION");
                    foreach (ExtraLine _ext in _extralines)
                    {
                        _ext.LINEFIELDS = ExtraLineField.Load("WHERE FK_EXTRALINE=" + _ext.ID).ToList();
                    }
                    olvExtraLine.SetObjects(_extralines);

                    reportControl1.ReportId = _reportID;
                    reportControl1.Load();

                    reportControl1.Enabled = true;
                    break;
            }
            ckAvailable.Text = SynapseForm.GetLabel("frmReportDetail.ckAvailable");
            ckAddCategory.Text = SynapseForm.GetLabel("frmReportDetail.ckAddCategory");
            ckAddToReportTitle.Text = SynapseForm.GetLabel("frmReportDetail.ckAddToReportTitle");
            ckLinked.Text = SynapseForm.GetLabel("frmReportDetail.ckLinked");

            txReport.ReadOnly = true;
            txAlias.ReadOnly = true;

            tsbDelete.Enabled = false;
            tsbUp.Enabled = false;
            tsbDown.Enabled = false;
            btAlias.Enabled = false;
            btColor.Enabled = false;

            tsbEditFilter.Enabled = false;
            tsbDeleteFilter.Enabled = false;
            tsbDownFilter.Enabled = false;
            tsbUpFilter.Enabled = false;

            tsbEditLine.Enabled = false;
            tsbDeleteLine.Enabled = false;
            tsbLineUp.Enabled = false;
            tsbLineDown.Enabled = false;

            gbFilterDetail.Enabled = false;
            gbExtraLineFields.Enabled = false;

            this.WindowState = FormWindowState.Maximized;
        }
        #region Tables and Views
        private void fillType()
        {
            IList<ReportType> _types = ReportType.Load();
            cbType.DisplayMember = "LABEL";
            cbType.ValueMember = "ID";
            cbType.DataSource = _types.OrderBy(x => x.ID.ToString()).ToList();
        }

        private void fillCategory()
        {
            IList<Category> _categories = new List<Category>();
            switch (GlobalVariables.selectedOrigin.ORIGIN)
            {
                case Origin.Module:
                    _categories = Category.Load("WHERE FK_MODULE=" + GlobalVariables.selectedOrigin.MODULEID);
                    break;
                case Origin.Interface:
                    _categories = Category.Load("WHERE FK_INTERFACE=" + GlobalVariables.selectedOrigin.INTERFACEID);
                    break;
            }
            cbCategory.DisplayMember = "LABEL";
            cbCategory.ValueMember = "ID";
            cbCategory.DataSource = _categories.OrderBy(x => x.LABEL.ToString()).ToList();            
        }

        private void fillTablesAndViews()
        {
            IList<string> _type = new List<string>();
            _type.Add("T");
            _type.Add("V");
            treeTable.SetObjects(_type);
        }

        private void btReportName_Click(object sender, EventArgs e)
        {
            frmLabelML fLabelML = new frmLabelML();
            fLabelML.Action = "EDIT";
            fLabelML.LabelBag = _report.LABEL;
            fLabelML.LabelName = GetLabel("frmReportDetail.ReportName");
            if (fLabelML.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _report.LABEL = fLabelML.LabelBag;
                _report.LABELID = _report.LABEL.Labels[0].LABELID;

                txReport.Text = _report.LABEL.ToString();
            }
        }

        private void treeTable_DoubleClick(object sender, EventArgs e)
        {
            if (treeTable.SelectedObject is string)
            {
                if (treeTable.IsExpanded(treeTable.SelectedObject))
                    treeTable.Collapse(treeTable.SelectedObject);
                else
                    treeTable.Expand(treeTable.SelectedObject);
            }
            else
            {
                if (treeTable.SelectedObject is TablesAndViews)
                {
                    Tables _tbl = new Tables();
                    _tbl.TABLENAME = ((TablesAndViews)treeTable.SelectedObject).TABLENAME;
                    _tbl.TYPE = ((TablesAndViews)treeTable.SelectedObject).TYPE;
                    _tbl.FK_REPORT = _reportID;

                    olvTables.AddObject(_tbl);

                    if (!txFrom.Text.Contains(_tbl.TABLENAME))
                    {
                        if (txFrom.Text.Trim() != "")
                            txFrom.Text = txFrom.Text + " INNER JOIN " + Environment.NewLine + _tbl.TABLENAME;
                        else
                            txFrom.Text = _tbl.TABLENAME;
                    }
                    else
                    {
                        txFrom.Text = txFrom.Text + " INNER JOIN " + Environment.NewLine + _tbl.TABLENAME + " AS _NewName";
                    }

                    if (olvSelectedFields.Objects != null)
                    {
                        foreach (Field _fld in olvSelectedFields.Objects)
                        {
                            olvSelectedFields.RefreshObject(_fld);
                        }
                    }
                }
            }
        }

        private void removeTable(object sender, EventArgs e)
        {
            if (olvTables.SelectedItems.Count > 0)
            {
                Tables _tbl = (Tables)olvTables.SelectedObject;
                txFrom.Text = txFrom.Text.Replace(_tbl.TABLENAME, "");
                _deletedTables.Add(_tbl);
                olvTables.RemoveObject(_tbl);

                if (olvSelectedFields.Objects != null)
                {
                    foreach (Field _fld in olvSelectedFields.Objects)
                    {
                        olvSelectedFields.RefreshObject(_fld);
                    }
                }
            }
        }

        private void olvTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvTables.SelectedItems.Count > 0)
            {
                Tables _tbl = (Tables)olvTables.SelectedObject;

                olvFields.Items.Clear();
                IList<TableField> _fields = new List<TableField>();
                switch (GlobalVariables.selectedOrigin.ORIGIN)
                {
                    case Origin.Module:
                        _fields = TableField.LoadFromQuery("SELECT SYS.ALL_OBJECTS.NAME AS TABLENAME, SYS.ALL_COLUMNS.NAME AS FIELDNAME, SYS.TYPES.NAME AS FIELDTYPE FROM SYS.ALL_COLUMNS, SYS.ALL_OBJECTS, SYS.TYPES WHERE SYS.ALL_COLUMNS.OBJECT_ID=SYS.ALL_OBJECTS.OBJECT_ID AND SYS.ALL_OBJECTS.NAME='" + _tbl.TABLENAME + "' AND SYS.ALL_COLUMNS.SYSTEM_TYPE_ID=SYS.TYPES.SYSTEM_TYPE_ID AND SYS.TYPES.USER_TYPE_ID = SYS.TYPES.SYSTEM_TYPE_ID ORDER BY SYS.ALL_COLUMNS.COLUMN_ID");
                        break;
                    case Origin.Interface:
                        _fields = TableField.LoadFromQuery(GlobalVariables.selectedOrigin.FIELDSQUERY.Replace("<tablename>", _tbl.TABLENAME), GlobalVariables.selectedOrigin.DBCONNECTION);
                        break;
                }
                olvFields.SetObjects(_fields);
            }
            else
            {
                olvFields.Items.Clear();
            }
        }

        private void addField(object sender, EventArgs e)
        {
            if (olvFields.SelectedItems.Count > 0)
            {
                TableField _tabelfield=(TableField)olvFields.SelectedObject;

                Field _field = new Field();
                _field.FIELDNAME = _tabelfield.TABLENAME + "." + _tabelfield.FIELDNAME;
                _field.ALIAS = new LabelBag();
                _field.ALIAS.Labels = new List<SynapseLabel>();

                foreach (SynapseLanguage lang in SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE"))
                {
                    SynapseLabel newlabel = new SynapseLabel();

                    newlabel.LABELID = 0;
                    newlabel.LANGUAGE = lang.CODE;
                    newlabel.TEXT = _tabelfield.TABLENAME + "." + _tabelfield.FIELDNAME;
                    _field.ALIAS.Labels.Add(newlabel);
                }
                _field.FK_REPORT = _reportID;
                _field.WIDTH = 150;
                _field.SORTING = "";
                _field.POSITION = olvSelectedFields.Items.Count + 1;

                olvSelectedFields.AddObject(_field);
            }
        }

        private void olvSelectedFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvSelectedFields.SelectedItems.Count > 0)
            {
                Field _field = (Field)olvSelectedFields.SelectedObject;
                txFieldName.Text = _field.FIELDNAME;
                txAlias.Text = _field.ALIAS.ToString();
                txFieldWidth.Text = _field.WIDTH.ToString();
                txFormat.Text = _field.FORMAT;
                tsbDelete.Enabled = true;
                btAlias.Enabled = true;
                btColor.Enabled = true;
                cbSorting.SelectedItem = _field.SORTING;
                txSortingOrder.Text = _field.SORTING_ORDER.ToString();
                if (olvSelectedFields.SelectedItem.Index < olvSelectedFields.Items.Count - 1)
                    tsbDown.Enabled = true;
                else
                    tsbDown.Enabled = false;
                if (olvSelectedFields.SelectedItem.Index > 0)
                    tsbUp.Enabled = true;
                else
                    tsbUp.Enabled = false;
            }
            else
            {
                txFieldName.Text = string.Empty;
                txAlias.Text = string.Empty;
                txFieldWidth.Text = string.Empty;
                txFormat.Text = string.Empty;
                tsbDelete.Enabled = false;
                tsbUp.Enabled = false;
                tsbDown.Enabled = false;
                btAlias.Enabled = false;
                btColor.Enabled = false;
                cbSorting.SelectedIndex = -1;
                txSortingOrder.Text = "";
            }
        }

        private void btAlias_Click(object sender, EventArgs e)
        {
            if (olvSelectedFields.SelectedItems.Count > 0)
            {
                frmLabelML fLabelML = new frmLabelML();
                fLabelML.Action = "EDIT";
                fLabelML.LabelBag = ((Field)olvSelectedFields.SelectedObject).ALIAS;
                fLabelML.LabelName = GetLabel("frmReportDetail.FieldAlias");
                if (fLabelML.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ((Field)olvSelectedFields.SelectedObject).ALIAS = fLabelML.LabelBag;
                    ((Field)olvSelectedFields.SelectedObject).ALIASID = ((Field)olvSelectedFields.SelectedObject).ALIAS.Labels[0].LABELID;
                    olvSelectedFields.RefreshObject(olvSelectedFields.SelectedObject);

                    txAlias.Text = ((Field)olvSelectedFields.SelectedObject).ALIAS.ToString();
                }
            }
        }

        private void deleteField(object sender, EventArgs e)
        {
            if (olvSelectedFields.SelectedItems.Count > 0)
            {
                Field _fld = (Field)olvSelectedFields.SelectedObject;
                _deletedFields.Add(_fld);
                olvSelectedFields.RemoveObject(_fld);
            }
        }

        private void saveReport(object sender, EventArgs e)
        {
            if (checkFields())
            {
                IList<SynapseLanguage> languages = SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE");

                SynapseCore.Database.DBFunction.StartTransaction();
                try
                {
                    _report.FK_TYPE = ((ReportType)cbType.SelectedItem).ID;
                    _report.FK_CATEGORY = ((Category)cbCategory.SelectedItem).ID;
                    _report.QRY_JOIN = txFrom.Text.Trim();
                    _report.QRY_CONDITION = txWhere.Text.Trim();
                    _report.QRY_GROUP = txGroup.Text.Trim();
                    _report.ADDCATEGORY = ckAddCategory.Checked;
                    _report.AVAILABLE = ckAvailable.Checked;

                    switch (GlobalVariables.selectedOrigin.ORIGIN)
                    {
                        case Origin.Module:
                            _report.FK_MODULE = GlobalVariables.selectedOrigin.MODULEID;
                            _report.FK_INTERFACE = 0;
                            break;
                        case Origin.Interface:
                            _report.FK_INTERFACE = GlobalVariables.selectedOrigin.INTERFACEID;
                            _report.FK_MODULE = 0;
                            break;
                    }
                    _report.save();

                    foreach (Tables _tbl in _deletedTables)
                    {
                        _tbl.delete();
                    }
                    if (olvTables.Objects != null)
                    {
                        foreach (Tables _tbl in olvTables.Objects)
                        {
                            _tbl.FK_REPORT = _report.ID;
                            _tbl.save();
                        }
                    }

                    foreach (Field _fld in _deletedFields)
                    {
                        if (_fld.ALIASID != 0)
                        {
                            foreach (SynapseLabel _lbl in _fld.ALIAS.Labels)
                            {
                                _lbl.delete();
                            }
                        }
                        _fld.delete();
                    }

                    if (olvSelectedFields.Objects != null)
                    {
                        Int32 pos = 1;
                        foreach (Field _fld in olvSelectedFields.Objects)
                        {
                            _fld.POSITION = pos++;
                            _fld.FK_REPORT = _report.ID;

                            if (_fld.ALIASID == 0)
                            {
                                Int64 lblID = SynapseLabel.GetNextID();
                                foreach (SynapseLanguage lang in languages)
                                {
                                    SynapseLabel newlabel = new SynapseLabel();

                                    newlabel.LABELID = lblID;
                                    newlabel.LANGUAGE = lang.CODE;
                                    newlabel.TEXT = _fld.FIELDNAME;
                                    newlabel.save();
                                }
                                _fld.ALIASID = lblID;
                            }
                            _fld.save();
                        }
                    }

                    foreach (Filter _flt in _deletedFilters)
                    {
                        if (_flt.LABELID != 0)
                        {
                            foreach (SynapseLabel _lbl in _flt.LABEL.Labels)
                            {
                                _lbl.delete();
                            }
                        }
                        _flt.delete();
                    }

                    if (olvFilters.Objects != null)
                    {
                        Int32 pos = 1;
                        foreach (Filter _flt in olvFilters.Objects)
                        {
                            _flt.POSITION = pos++;
                            _flt.FK_REPORT = _report.ID;

                            if (_flt.LABELID == 0)
                            {
                                Int64 lblID = SynapseLabel.GetNextID();
                                foreach (SynapseLanguage lang in languages)
                                {
                                    SynapseLabel newlabel = new SynapseLabel();

                                    newlabel.LABELID = lblID;
                                    newlabel.LANGUAGE = lang.CODE;
                                    newlabel.TEXT = _flt.NAME;
                                    newlabel.save();
                                }
                                _flt.LABELID = lblID;
                            }
                            _flt.save();
                        }
                    }

                    foreach (ExtraLine _ext in _deletedExtraLines)
                    {
                        if (_ext.LABELID != 0)
                        {
                            foreach (SynapseLabel _lbl in _ext.LABEL.Labels)
                            {
                                _lbl.delete();
                            }
                        }

                        foreach (ExtraLineField _elf in _ext.LINEFIELDS)
                        {
                            _elf.delete();
                        }

                        _ext.delete();
                    }

                    if (olvExtraLine.Objects != null)
                    {
                        Int32 pos = 1;
                        foreach (ExtraLine _ext in olvExtraLine.Objects)
                        {
                            _ext.POSITION = pos++;
                            _ext.FK_REPORT = _report.ID;

                            if (_ext.LABELID == 0)
                            {
                                Int64 lblID = SynapseLabel.GetNextID();
                                foreach (SynapseLanguage lang in languages)
                                {
                                    SynapseLabel newlabel = new SynapseLabel();

                                    newlabel.LABELID = lblID;
                                    newlabel.LANGUAGE = lang.CODE;
                                    newlabel.TEXT = _ext.NAME;
                                    newlabel.save();
                                }
                                _ext.LABELID = lblID;
                            }
                            _ext.save();

                            foreach (ExtraLineField _elf in _ext.LINEFIELDS)
                            {
                                _elf.FK_EXTRALINE = _ext.ID;
                                _elf.save();
                            }
                        }
                    }

                    SynapseCore.Database.DBFunction.CommitTransaction();

                    if (_action == "NEW")
                    {
                        _action = "EDIT";
                        _reportID = _report.ID;
                        reportControl1.ReportId = _reportID;
                        reportControl1.Load();
                        reportControl1.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    SynapseCore.Database.DBFunction.RollbackTransaction();
                    GlobalFunctions.showMessage("ERR", "Err.9999", ex.Message);
                }
            }
            else
            {
                GlobalFunctions.showError();
            }
        }

        private Boolean checkFields()
        {
            Boolean check = true;

            GlobalFunctions.resetError();
            synapseErrorProvider1.SetError(txReport, "");
            synapseErrorProvider1.SetError(cbCategory, "");

            if (txReport.Text == "")
            {
                GlobalFunctions.addError("Err.0002");
                synapseErrorProvider1.SetError(txReport, SynapseForm.GetLabel("Err.0002"));
                check = false;
            }
            if (cbCategory.SelectedIndex < 0)
            {
                GlobalFunctions.addError("Err.0003");
                synapseErrorProvider1.SetError(cbCategory, SynapseForm.GetLabel("Err.0003"));
                check = false;
            }

            return check;
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            Int32 x = olvSelectedFields.SelectedItem.Index;
            Field _fld = (Field)olvSelectedFields.SelectedObject;

            if (x == 0)
                tsbUp.Enabled = false;
            else
            {
                List<Field> _flds = new List<Field>();
                _flds.Add(_fld);

                olvSelectedFields.RemoveObject(_fld);
                olvSelectedFields.InsertObjects(x - 1, _flds);

                olvSelectedFields.SelectObject(_flds[0]);
            }
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {
            Int32 x = olvSelectedFields.SelectedItem.Index;
            Field _fld = (Field)olvSelectedFields.SelectedObject;

            if (x == olvSelectedFields.Items.Count-1)
                tsbDown.Enabled = false;
            else
            {
                List<Field> _flds = new List<Field>();
                _flds.Add(_fld);

                olvSelectedFields.RemoveObject(_fld);
                olvSelectedFields.InsertObjects(x + 1, _flds);

                olvSelectedFields.SelectObject(_flds[0]);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateField(object sender, KeyEventArgs e)
        {
            Int32 _int;
            if (olvSelectedFields.SelectedObject != null)
            {
                ((Field)olvSelectedFields.SelectedObject).FIELDNAME = txFieldName.Text;
                ((Field)olvSelectedFields.SelectedObject).FORMAT = txFormat.Text;
                if (Int32.TryParse(txFieldWidth.Text, out _int))
                    ((Field)olvSelectedFields.SelectedObject).WIDTH = _int;
                else
                    ((Field)olvSelectedFields.SelectedObject).WIDTH = 150;
                if (Int32.TryParse(txSortingOrder.Text, out _int))
                    ((Field)olvSelectedFields.SelectedObject).SORTING_ORDER = _int;
                else
                    ((Field)olvSelectedFields.SelectedObject).SORTING_ORDER = null;
                olvSelectedFields.RefreshObject(olvSelectedFields.SelectedObject);
            }
        }


        private void cbSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvSelectedFields.SelectedObject != null)
            {
                ((Field)olvSelectedFields.SelectedObject).SORTING = cbSorting.SelectedItem.ToString();
                olvSelectedFields.RefreshObject(olvSelectedFields.SelectedObject);
            }
        }
        #endregion

        #region Filters
        private void fillControlType()
        {
            DataSet _data = new DataSet();
            DataTable _tbl = new DataTable("CONTROLTYPE");

            _tbl.Columns.Add("VALUE", System.Type.GetType("System.String"));
            _tbl.Columns.Add("DISPLAY", System.Type.GetType("System.String"));
            _data.Tables.Add(_tbl);

            DataRow _row = _data.Tables["CONTROLTYPE"].NewRow();
            _row["VALUE"] = "EQUAL";
            _row["DISPLAY"] = "IS EQUAL TO";
            _data.Tables["CONTROLTYPE"].Rows.Add(_row);

            _row = _data.Tables["CONTROLTYPE"].NewRow();
            _row["VALUE"] = "LIKE";
            _row["DISPLAY"] = "IS LIKE";
            _data.Tables["CONTROLTYPE"].Rows.Add(_row);

            cbControlType.DataSource = _data;
            cbControlType.DisplayMember = "CONTROLTYPE.DISPLAY";
            cbControlType.ValueMember = "CONTROLTYPE.VALUE";

            cbControlType.SelectedIndex = 0;
        }

        private void initFilterDetail()
        {
            IList<FilterType> _type = FilterType.Load();
            cbFilterType.Items.Clear();
            foreach (FilterType Flt in _type)
            {
                cbFilterType.Items.Add(Flt);
            }

            cbFilterType.DisplayMember = "TYPE";
            cbFilterType.ValueMember = "ID";

            cbTables.Items.Clear();
            foreach (Tables Tbl in olvTables.Objects)
            {
                cbTables.Items.Add(Tbl);
            }

            cbTables.DisplayMember = "TABLENAME";
            cbTables.ValueMember = "TABLENAME";

            cbTableData.Items.Clear();
            IList<Tables> _tables = new List<Tables>();
            switch (GlobalVariables.selectedOrigin.ORIGIN)
            {
                case Origin.Module:
                    _tables = Tables.LoadFromQuery("SELECT SYS.TABLES.NAME AS TABLENAME FROM SYS.TABLES WHERE UPPER(SYS.TABLES.NAME) LIKE '%" + GlobalVariables.selectedOrigin.TECHNICALNAME.ToUpper() + "%' UNION SELECT SYS.VIEWS.NAME AS TABLENAME FROM SYS.VIEWS WHERE UPPER(SYS.VIEWS.NAME) LIKE '%" + GlobalVariables.selectedOrigin.TECHNICALNAME.ToUpper() + "%' ORDER BY TABLENAME");
                    break;
                case Origin.Interface:
                    _tables = Tables.LoadFromQuery(GlobalVariables.selectedOrigin.TABLESQUERY + " UNION " + GlobalVariables.selectedOrigin.VIEWSQUERY + " ORDER BY TABLENAME", GlobalVariables.selectedOrigin.DBCONNECTION);
                    break;
            }
            foreach (Tables Tbl in _tables)
            {
                cbTableData.Items.Add(Tbl);
            }

            cbTableData.DisplayMember = "TABLENAME";
            cbTableData.ValueMember = "TABLENAME";

            cbControlType.SelectedIndex = -1;

            gbFilterQuery.Enabled = false;
        }

        private void displayDetail()
        {
            initFilterDetail();

            Filter _Flt = (Filter)olvFilters.SelectedObject;
            txFilterName.Text = _Flt.NAME;
            cbFilterType.Text = _Flt.TYPE;
            txFilterLabel.Text = _Flt.LABEL.ToString();
            ckAddToReportTitle.Checked = _Flt.ADD_TO_REPORTTITLE;
            txWidth.Text = _Flt.WIDTH.ToString();
            cbTables.Text = _Flt.CTRL_TABLE;
            cbFields.Text = _Flt.CTRL_FIELD;
            cbControlType.SelectedValue = _Flt.CTRL_TYPE;
            txFilterField.Text = _Flt.CTRL_CUSTOM;
            cbTableData.Text = _Flt.DATA_TABLE;
            cbValueData.Text = _Flt.DATA_VALUE;
            cbDisplayData.Text = _Flt.DATA_DISPLAY;
            txQueryData.Text = _Flt.DATA_QUERY;
            ckLinked.Checked = _Flt.IS_LINKED;
            if (ckLinked.Checked)
            {
                foreach (Filter flt in cbLinkedFilter.Items)
                {
                    if (flt.ID == _Flt.LINKED_FILTERID)
                    {
                        cbLinkedFilter.SelectedIndex = cbLinkedFilter.Items.IndexOf(flt);
                        txLinkedFilterField.Text = ((Filter)cbLinkedFilter.SelectedItem).DATA_TABLE + "." + ((Filter)cbLinkedFilter.SelectedItem).DATA_VALUE;
                    }
                }
                cbLinkedField.Text = _Flt.LINKED_FIELD;
            }
            _reportFilter = _Flt;
        }

        private void resetDetail()
        {
            txFilterName.Text = "";
            txFilterLabel.Text = "";
            ckAddToReportTitle.Checked = false;
            txWidth.Text = "";
            txFilterField.Text = "";
            txQueryData.Text = "";
            cbFilterType.SelectedIndex = -1;
            cbTables.SelectedIndex = -1;
            cbFields.SelectedIndex = -1;
            cbTableData.SelectedIndex = -1;
            cbValueData.SelectedIndex = -1;
            cbDisplayData.SelectedIndex = -1;
            cbControlType.SelectedIndex = -1;
            ckLinked.Checked = false;
            gbFilterDetail.Enabled = false;
            gbFilter.Enabled = true;
        }

        private void New_Filter(object sender, EventArgs e)
        {
            initFilterDetail();
            resetDetail();

            _actionFilter = "NEW";
            _reportFilter = new Filter();
            _reportFilter.FK_REPORT = 0;
            _reportFilter.LABEL = new LabelBag();
            _reportFilter.LABEL.Labels = new List<SynapseLabel>();
            ckAddToReportTitle.Checked = false;
            foreach (SynapseLanguage lang in SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE"))
            {
                SynapseLabel newlabel = new SynapseLabel();

                newlabel.LABELID = 0;
                newlabel.LANGUAGE = lang.CODE;
                newlabel.TEXT = "";
                _reportFilter.LABEL.Labels.Add(newlabel);
            }
            ckLinked.Checked = false;
            gbFilterDetail.Enabled = true;
            gbFilter.Enabled = false;
            txFilterName.Focus();
        }

        private void Edit_Filter(object sender, EventArgs e)
        {
            displayDetail();

            _actionFilter = "EDIT";
            gbFilterDetail.Enabled = true;
            gbFilter.Enabled = false;
            txFilterName.Focus();
        }

        private void tsbCancelFilter_Click(object sender, EventArgs e)
        {
            olvFilters.SelectedObject = null;
            resetDetail();
        }

        private void tsbSaveFilter_Click(object sender, EventArgs e)
        {
            Int32 _int;

            _reportFilter.NAME = txFilterName.Text;
            _reportFilter.TYPE = cbFilterType.Text;
            _reportFilter.POSITION = 0;
            _reportFilter.CTRL_TABLE = cbTables.Text;
            _reportFilter.CTRL_FIELD = cbFields.Text;
            _reportFilter.CTRL_TYPE = cbControlType.SelectedValue==null ? "" : cbControlType.SelectedValue.ToString();
            _reportFilter.CTRL_CUSTOM = txFilterField.Text;
            _reportFilter.DATA_TABLE = cbTableData.Text;
            _reportFilter.DATA_VALUE = cbValueData.Text;
            _reportFilter.DATA_DISPLAY = cbDisplayData.Text;
            _reportFilter.DATA_QUERY = txQueryData.Text;
            _reportFilter.ADD_TO_REPORTTITLE = ckAddToReportTitle.Checked;
            _reportFilter.IS_LINKED = ckLinked.Checked;
            if (_reportFilter.IS_LINKED)
            {
                _reportFilter.LINKED_FILTERID = ((Filter)cbLinkedFilter.SelectedItem).ID;
                _reportFilter.LINKED_FIELD = cbLinkedField.Text;
            }
            else
            {
                _reportFilter.LINKED_FILTERID = 0;
                _reportFilter.LINKED_FIELD = "";
            }
            if (Int32.TryParse(txWidth.Text, out _int))
                _reportFilter.WIDTH = _int;
            else
                _reportFilter.WIDTH = 200;

            if (_actionFilter=="NEW")
                olvFilters.AddObject(_reportFilter);
            else
                olvFilters.RefreshObject(olvFilters.SelectedObject);

            olvFilters.SelectedObject = null;
            resetDetail();
        }

        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterType.SelectedIndex != -1)
            {
                if (((FilterType)cbFilterType.SelectedItem).HASDATA)
                {
                    if (txQueryData.Text =="")
                        generateQuery();

                    gbFilterQuery.Enabled = true;
                }
                else
                {
                    cbTableData.SelectedIndex = -1;
                    txQueryData.Text = "";
                    gbFilterQuery.Enabled = false;
                }

                if (((FilterType)cbFilterType.SelectedItem).TYPE.Contains("LIST"))
                {
                    cbControlType.SelectedIndex = 0;
                    cbControlType.Enabled = true;
                }
                else
                {
                    cbControlType.SelectedIndex = -1;
                    cbControlType.Enabled = false;
                }
            }
            else
            {
                cbTableData.SelectedIndex = -1;
                cbControlType.SelectedIndex = -1;
                txQueryData.Text = "";
                gbFilterQuery.Enabled = false;
            }
            
        }

        private void generateQuery()
        {
            StringBuilder txQuery = new StringBuilder();

            switch (GlobalVariables.selectedOrigin.DBTYPE)
            {
                case DatabaseType.SQLServer:
                case DatabaseType.Access:
                    txQuery.Append("SELECT CONVERT(VARCHAR, 0) AS VALUE, ' * ' AS DISPLAY " + Environment.NewLine);
                    txQuery.Append("UNION " + Environment.NewLine);
                    txQuery.Append("SELECT DISTINCT CONVERT(VARCHAR, " + cbTableData.Text + "." + cbValueData.Text + ") AS VALUE, CONVERT(VARCHAR, " + cbTableData.Text + "." + cbDisplayData.Text + ") AS DISPLAY " + Environment.NewLine);
                    txQuery.Append("FROM " + cbTableData.Text + Environment.NewLine);
                    txQuery.Append("ORDER BY DISPLAY" + Environment.NewLine);
                    break;
                case DatabaseType.Oracle:
                    txQuery.Append("SELECT TO_CHAR(0) AS VALUE, ' * ' AS DISPLAY FROM DUAL " + Environment.NewLine);
                    txQuery.Append("UNION " + Environment.NewLine);
                    txQuery.Append("SELECT DISTINCT TO_CHAR(" + cbTableData.Text + "." + cbValueData.Text + ") AS VALUE, TO_CHAR(" + cbTableData.Text + "." + cbDisplayData.Text + ") AS DISPLAY " + Environment.NewLine);
                    txQuery.Append("FROM " + cbTableData.Text + Environment.NewLine);
                    txQuery.Append("ORDER BY DISPLAY" + Environment.NewLine);
                    break;
                default:
                    txQuery.Append("SELECT CONVERT(VARCHAR, 0) AS VALUE, ' * ' AS DISPLAY " + Environment.NewLine);
                    txQuery.Append("UNION " + Environment.NewLine);
                    txQuery.Append("SELECT DISTINCT CONVERT(VARCHAR, " + cbTableData.Text + "." + cbValueData.Text + ") AS VALUE, CONVERT(VARCHAR, " + cbTableData.Text + "." + cbDisplayData.Text + ") AS DISPLAY " + Environment.NewLine);
                    txQuery.Append("FROM " + cbTableData.Text + Environment.NewLine);
                    txQuery.Append("ORDER BY DISPLAY" + Environment.NewLine);
                    break;
            }

            txQueryData.Text = txQuery.ToString();
        }

        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTables.SelectedIndex != -1)
            {
                Tables _tbl = (Tables)cbTables.SelectedItem;

                cbFields.Items.Clear();
                IList<TableField> _fields = new List<TableField>();
                switch (GlobalVariables.selectedOrigin.ORIGIN)
                {
                    case Origin.Module:
                        _fields = TableField.LoadFromQuery("SELECT SYS.ALL_OBJECTS.NAME AS TABLENAME, SYS.ALL_COLUMNS.NAME AS FIELDNAME, SYS.TYPES.NAME AS FIELDTYPE FROM SYS.ALL_COLUMNS, SYS.ALL_OBJECTS, SYS.TYPES WHERE SYS.ALL_COLUMNS.OBJECT_ID=SYS.ALL_OBJECTS.OBJECT_ID AND SYS.ALL_OBJECTS.NAME='" + _tbl.TABLENAME + "' AND SYS.ALL_COLUMNS.SYSTEM_TYPE_ID=SYS.TYPES.SYSTEM_TYPE_ID AND SYS.TYPES.USER_TYPE_ID = SYS.TYPES.SYSTEM_TYPE_ID ORDER BY SYS.ALL_COLUMNS.COLUMN_ID");
                        break;
                    case Origin.Interface:
                        _fields = TableField.LoadFromQuery(GlobalVariables.selectedOrigin.FIELDSQUERY.Replace("<tablename>", _tbl.TABLENAME), GlobalVariables.selectedOrigin.DBCONNECTION);
                        break;
                }
                foreach (TableField Fld in _fields)
                {
                    cbFields.Items.Add(Fld);
                }
                cbFields.DisplayMember = "FIELDNAME";
                cbFields.ValueMember = "FIELDNAME";

                cbFields.SelectedIndex = -1;
            }
            else
            {
                cbFields.Items.Clear();
            }
        }

        private void cbTableData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTableData.SelectedIndex != -1)
            {
                Tables _tbl = (Tables)cbTableData.SelectedItem;

                cbValueData.Items.Clear();
                cbDisplayData.Items.Clear();
                IList<TableField> _fields = new List<TableField>();
                switch (GlobalVariables.selectedOrigin.ORIGIN)
                {
                    case Origin.Module:
                        _fields = TableField.LoadFromQuery("SELECT SYS.ALL_OBJECTS.NAME AS TABLENAME, SYS.ALL_COLUMNS.NAME AS FIELDNAME, SYS.TYPES.NAME AS FIELDTYPE FROM SYS.ALL_COLUMNS, SYS.ALL_OBJECTS, SYS.TYPES WHERE SYS.ALL_COLUMNS.OBJECT_ID=SYS.ALL_OBJECTS.OBJECT_ID AND SYS.ALL_OBJECTS.NAME='" + _tbl.TABLENAME + "' AND SYS.ALL_COLUMNS.SYSTEM_TYPE_ID=SYS.TYPES.SYSTEM_TYPE_ID AND SYS.TYPES.USER_TYPE_ID = SYS.TYPES.SYSTEM_TYPE_ID ORDER BY SYS.ALL_COLUMNS.COLUMN_ID");
                        break;
                    case Origin.Interface:
                        _fields = TableField.LoadFromQuery(GlobalVariables.selectedOrigin.FIELDSQUERY.Replace("<tablename>", _tbl.TABLENAME), GlobalVariables.selectedOrigin.DBCONNECTION);
                        break;
                }
                foreach (TableField Fld in _fields)
                {
                    cbValueData.Items.Add(Fld);
                    cbDisplayData.Items.Add(Fld);
                }
                cbValueData.DisplayMember = "FIELDNAME";
                cbValueData.ValueMember = "FIELDNAME";
                cbDisplayData.DisplayMember = "FIELDNAME";
                cbDisplayData.ValueMember = "FIELDNAME";

                cbValueData.SelectedIndex = -1;
                cbDisplayData.SelectedIndex = -1;
            }
            else
            {
                cbValueData.Items.Clear();
                cbDisplayData.Items.Clear();
            }

            generateQuery();
        }

        private void cbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFields.SelectedIndex != -1)
                txFilterField.Text = cbTables.Text + "." + cbFields.Text;
            else
                txFilterField.Text = "";
        }        

        private void cbValueData_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateQuery();
        }

        private void cbDisplayData_SelectedIndexChanged(object sender, EventArgs e)
        {
            generateQuery();
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            frmLabelML fLabelML = new frmLabelML();
            fLabelML.Action = "EDIT";
            fLabelML.LabelBag = _reportFilter.LABEL;
            fLabelML.LabelName = GetLabel("frmReportDetail.FilterLabel");
            if (fLabelML.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _reportFilter.LABEL = fLabelML.LabelBag;
                _reportFilter.LABELID = _reportFilter.LABEL.Labels[0].LABELID;
                txFilterLabel.Text = _reportFilter.LABEL.ToString();
            }
        } 

        private void olvFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvFilters.SelectedItems.Count > 0)
            {
                displayDetail();

                tsbEditFilter.Enabled = true;
                tsbDeleteFilter.Enabled = true;
                if (olvFilters.SelectedItem.Index < olvFilters.Items.Count - 1)
                    tsbDownFilter.Enabled = true;
                else
                    tsbDownFilter.Enabled = false;
                if (olvFilters.SelectedItem.Index > 0)
                    tsbUpFilter.Enabled = true;
                else
                    tsbUpFilter.Enabled = false;
            }
            else
            {
                resetDetail();

                tsbEditFilter.Enabled = false;
                tsbDeleteFilter.Enabled = false;
                tsbDownFilter.Enabled = false;
                tsbUpFilter.Enabled = false;
            }
        }

        private void deleteFilter(object sender, EventArgs e)
        {
            if (olvFilters.SelectedItems.Count > 0)
            {
                if (GlobalFunctions.showMessage("QUEST", "Quest.0002") == System.Windows.Forms.DialogResult.Yes)
                {
                    Filter _flt = (Filter)olvFilters.SelectedObject;
                    _deletedFilters.Add(_flt);
                    olvFilters.RemoveObject(_flt);
                }
            }
        }

        private void tsbUpFilter_Click(object sender, EventArgs e)
        {
            Int32 x = olvFilters.SelectedItem.Index;
            Filter _flt = (Filter)olvFilters.SelectedObject;

            if (x == 0)
                tsbUpFilter.Enabled = false;
            else
            {
                List<Filter> _flts = new List<Filter>();
                _flts.Add(_flt);

                olvFilters.RemoveObject(_flt);
                olvFilters.InsertObjects(x - 1, _flts);

                olvFilters.SelectObject(_flts[0]);
            }
        }

        private void tsbDownFilter_Click(object sender, EventArgs e)
        {
            Int32 x = olvFilters.SelectedItem.Index;
            Filter _flt = (Filter)olvFilters.SelectedObject;

            if (x == olvFilters.Items.Count - 1)
                tsbDownFilter.Enabled = false;
            else
            {
                List<Filter> _flts = new List<Filter>();
                _flts.Add(_flt);

                olvFilters.RemoveObject(_flt);
                olvFilters.InsertObjects(x + 1, _flts);

                olvFilters.SelectObject(_flts[0]);
            }
        }

        private void reportControl1_QueryChanged(object sender, UserControls.QueryEventArgs e)
        {
            txQuery.Text = e.NewQuery;
        }


        private void ckLinked_CheckedChanged(object sender, EventArgs e)
        {
            if (ckLinked.Checked)
            {
                cbLinkedFilter.Items.Clear();
                IList<Filter> _flts = Filter.Load("WHERE FK_REPORT=" + _reportID + " AND TYPE='ONE VALUE LIST' ORDER BY NAME");
                foreach (Filter flt in _flts)
                {
                    cbLinkedFilter.Items.Add(flt);
                }
                cbLinkedFilter.DisplayMember = "NAME";
                cbLinkedFilter.ValueMember = "ID";
  
                cbLinkedField.Items.Clear();
                if (cbTableData.SelectedIndex != -1)
                {
                    Tables _tbl = (Tables)cbTableData.SelectedItem;
                    IList<TableField> _fields = new List<TableField>();
                    switch (GlobalVariables.selectedOrigin.ORIGIN)
                    {
                        case Origin.Module:
                            _fields = TableField.LoadFromQuery("SELECT SYS.ALL_OBJECTS.NAME + '.' + SYS.ALL_COLUMNS.NAME AS FIELDNAME, SYS.TYPES.NAME AS FIELDTYPE FROM SYS.ALL_COLUMNS, SYS.ALL_OBJECTS, SYS.TYPES WHERE SYS.ALL_COLUMNS.OBJECT_ID=SYS.ALL_OBJECTS.OBJECT_ID AND SYS.ALL_OBJECTS.NAME='" + _tbl.TABLENAME + "' AND SYS.ALL_COLUMNS.SYSTEM_TYPE_ID=SYS.TYPES.SYSTEM_TYPE_ID AND SYS.TYPES.USER_TYPE_ID = SYS.TYPES.SYSTEM_TYPE_ID ORDER BY SYS.ALL_COLUMNS.COLUMN_ID");
                            break;
                        case Origin.Interface:
                            _fields = TableField.LoadFromQuery(GlobalVariables.selectedOrigin.FIELDSQUERY.Replace("<tablename>", _tbl.TABLENAME), GlobalVariables.selectedOrigin.DBCONNECTION);
                            break;
                    }
                    foreach (TableField fld in _fields)
                    {
                        cbLinkedField.Items.Add(fld);
                    }
                    cbLinkedField.DisplayMember = "FIELDNAME";
                    cbLinkedField.ValueMember = "FIELDNAME";
                }

                cbLinkedFilter.Enabled=true;
                cbLinkedField.Enabled = true;
                txLinkedFilterField.Enabled = true;
            }
            else
            {
                cbLinkedFilter.Items.Clear();
                cbLinkedField.Items.Clear();
                txLinkedFilterField.Text = "";

                cbLinkedFilter.Enabled = false;
                cbLinkedField.Enabled = false;
                txLinkedFilterField.Enabled = false;
            }
        }

        private void cbLinkedFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLinkedFilter.SelectedItem != null)
            {
                txLinkedFilterField.Text = ((Filter)cbLinkedFilter.SelectedItem).DATA_TABLE + "." + ((Filter)cbLinkedFilter.SelectedItem).DATA_VALUE;
            }
        }

        #endregion

        #region Extra Lines
        private void fillFunctions()
        {
            IList<FieldFunction> _functions = GlobalFunctions.LoadFieldFunction();
            cbFieldFunction.DisplayMember = "LABEL";
            cbFieldFunction.ValueMember = "CODE";
            cbFieldFunction.DataSource = _functions.ToList();
        }

        private void initExtraLineDetail()
        {
            cbFieldFunction.SelectedIndex = -1;
        }

        private void displayExtraLineDetail()
        {
            initExtraLineDetail();

            ExtraLine _XtraLine = (ExtraLine)olvExtraLine.SelectedObject;
            txLineName.Text = _XtraLine.NAME;
            txLineLabel.Text = _XtraLine.LABEL.ToString();
            olvLineFields.SetObjects(_XtraLine.LINEFIELDS);

            _reportExtraLine = _XtraLine;
        }

        private void resetExtraLineDetail()
        {
            txLineName.Text = "";
            txLineLabel.Text = "";
            cbFieldFunction.SelectedIndex = -1;
            txFieldFormat.Text = "";

            //Reset ExtraLine Fields
            olvLineFields.Items.Clear();

            gbExtraLines.Enabled = true;
            gbExtraLineFields.Enabled = false;
        }

        private void New_ExtraLine(object sender, EventArgs e)
        {
            resetExtraLineDetail();

            _actionExtraLine = "NEW";
            _reportExtraLine = new ExtraLine();
            _reportExtraLine.FK_REPORT = 0;
            _reportExtraLine.LABEL = new LabelBag();
            _reportExtraLine.LABEL.Labels = new List<SynapseLabel>();
            foreach (SynapseLanguage lang in SynapseLanguage.LoadFromQuery("SELECT * FROM SYNAPSE_LANGUAGE ORDER BY CODE"))
            {
                SynapseLabel newlabel = new SynapseLabel();

                newlabel.LABELID = 0;
                newlabel.LANGUAGE = lang.CODE;
                newlabel.TEXT = "";
                _reportExtraLine.LABEL.Labels.Add(newlabel);
            }
            _reportExtraLine.LINEFIELDS = new List<ExtraLineField>();

            txLineName.Focus();

            foreach (Field fld in olvSelectedFields.Objects)
            {
                ExtraLineField ext = new ExtraLineField();
                ext.ID=0;
                ext.POSITION=fld.POSITION;
                ext.FUNCTIONCODE="";
                ext.FORMAT="";
                ext.FK_EXTRALINE=0;
                _reportExtraLine.LINEFIELDS.Add(ext);

                olvLineFields.AddObject(ext);
            }

            gbExtraLineFields.Enabled = true;
            gbExtraLines.Enabled = false;

            cbFieldFunction.Enabled = false;
            txFieldFormat.Enabled = false;
        }

        private void Edit_ExtraLine(object sender, EventArgs e)
        {
            displayExtraLineDetail();

            _actionExtraLine = "EDIT";
            txLineName.Focus();

            gbExtraLineFields.Enabled = true;
            gbExtraLines.Enabled = false;

            cbFieldFunction.Enabled = false;
            txFieldFormat.Enabled = false;
        }

        private void tsbSaveExtraLine_Click(object sender, EventArgs e)
        {
            _reportExtraLine.NAME = txLineName.Text;
            _reportExtraLine.POSITION = 0;

            if (_actionExtraLine == "NEW")
                olvExtraLine.AddObject(_reportExtraLine);
            else
                olvExtraLine.RefreshObject(olvExtraLine.SelectedObject);

            olvExtraLine.SelectedObject = null;
            resetExtraLineDetail();
        }

        private void tsbCancelLine_Click(object sender, EventArgs e)
        {
            olvExtraLine.SelectedObject = null;
            resetExtraLineDetail();
        }

        private void btLineLabel_Click(object sender, EventArgs e)
        {
            frmLabelML fLabelML = new frmLabelML();
            fLabelML.Action = "EDIT";
            fLabelML.LabelBag = _reportExtraLine.LABEL;
            fLabelML.LabelName = GetLabel("frmReportDetail.ExtraLineLabel");
            if (fLabelML.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _reportExtraLine.LABEL = fLabelML.LabelBag;
                _reportExtraLine.LABELID = _reportExtraLine.LABEL.Labels[0].LABELID;
                txLineLabel.Text = _reportExtraLine.LABEL.ToString();
            }
        }

        private void olvExtraLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvExtraLine.SelectedItems.Count > 0)
            {
                displayExtraLineDetail();

                tsbEditLine.Enabled = true;
                tsbDeleteLine.Enabled = true;
                if (olvExtraLine.SelectedItem.Index < olvExtraLine.Items.Count - 1)
                    tsbLineDown.Enabled = true;
                else
                    tsbLineDown.Enabled = false;
                if (olvExtraLine.SelectedItem.Index > 0)
                    tsbLineUp.Enabled = true;
                else
                    tsbLineUp.Enabled = false;
            }
            else
            {
                resetExtraLineDetail();

                tsbEditLine.Enabled = false;
                tsbDeleteLine.Enabled = false;
                tsbLineDown.Enabled = false;
                tsbLineUp.Enabled = false;
            }
        }

        private void deleteExtraLine(object sender, EventArgs e)
        {
            if (olvExtraLine.SelectedItems.Count > 0)
            {
                if (GlobalFunctions.showMessage("QUEST", "Quest.0004") == System.Windows.Forms.DialogResult.Yes)
                {
                    ExtraLine _ext = (ExtraLine)olvExtraLine.SelectedObject;
                    _deletedExtraLines.Add(_ext);
                    olvExtraLine.RemoveObject(_ext);
                }
            }
        }

        private void tsbUpExtraLine_Click(object sender, EventArgs e)
        {
            Int32 x = olvExtraLine.SelectedItem.Index;
            ExtraLine _ext = (ExtraLine)olvExtraLine.SelectedObject;

            if (x == 0)
                tsbLineUp.Enabled = false;
            else
            {
                List<ExtraLine> _exts = new List<ExtraLine>();
                _exts.Add(_ext);

                olvExtraLine.RemoveObject(_ext);
                olvExtraLine.InsertObjects(x - 1, _exts);

                olvExtraLine.SelectObject(_exts[0]);
            }
        }

        private void tsbDownExtraLine_Click(object sender, EventArgs e)
        {
            Int32 x = olvExtraLine.SelectedItem.Index;
            ExtraLine _ext = (ExtraLine)olvExtraLine.SelectedObject;

            if (x == olvFilters.Items.Count - 1)
                tsbLineDown.Enabled = false;
            else
            {
                List<ExtraLine> _exts = new List<ExtraLine>();
                _exts.Add(_ext);

                olvExtraLine.RemoveObject(_ext);
                olvExtraLine.InsertObjects(x + 1, _exts);

                olvExtraLine.SelectObject(_exts[0]);
            }
        }

        private void olvLineField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvLineFields.SelectedItems.Count > 0)
            {
                displayLineFieldDetail();

                cbFieldFunction.Enabled = true;
                txFieldFormat.Enabled = true;
            }
            else
            {
                resetLineFieldDetail();

                cbFieldFunction.Enabled = false;
                txFieldFormat.Enabled = false;
            }
        }

        private void displayLineFieldDetail()
        {
            ExtraLineField _XtraLineField = (ExtraLineField)olvLineFields.SelectedObject;
            cbFieldFunction.SelectedValue = _XtraLineField.FUNCTIONCODE;
            txFieldFormat.Text = _XtraLineField.FORMAT;
        }

        private void resetLineFieldDetail()
        {
            txFieldFormat.Text = "";
            cbFieldFunction.SelectedIndex = -1;
        }

        private void cbFieldFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvLineFields.SelectedObject != null && cbFieldFunction.SelectedItem != null)
            {
                ((ExtraLineField)olvLineFields.SelectedObject).FUNCTIONCODE = ((FieldFunction)cbFieldFunction.SelectedItem).CODE;
                olvLineFields.RefreshObject(olvLineFields.SelectedObject);
            }
        }

        private void updateLineField(object sender, KeyEventArgs e)
        {
            if (olvLineFields.SelectedObject != null)
            {
                ((ExtraLineField)olvLineFields.SelectedObject).FORMAT = txFieldFormat.Text;
                olvLineFields.RefreshObject(olvLineFields.SelectedObject);
            }
        }
        #endregion  

        private void tsbChangeTags_Click(object sender, EventArgs e)
        {
            frmMissingTags fMissingTags = new frmMissingTags();

            foreach (string key in GlobalVariables.XtraVariables.Keys)
            {
                missingTag mTag = new missingTag();
                mTag.lbTag.Text = key.Replace("[#","").Replace("#]","").ToUpper();
                mTag.txTagValue.Text = GlobalVariables.XtraVariables[key];
                mTag.Tag = key;
                mTag.Width = fMissingTags.pnlMissingTags.Width;
                fMissingTags.pnlMissingTags.Controls.Add(mTag);
            }

            if (fMissingTags.ShowDialog() == DialogResult.OK)
            {
                foreach (missingTag tag in fMissingTags.pnlMissingTags.Controls)
                {
                    string tagName = tag.Tag.ToString();
                    string tagValue = tag.txTagValue.Text;

                    if (GlobalVariables.XtraVariables.ContainsKey(tagName))
                        GlobalVariables.XtraVariables[tagName] = tagValue;
                    else
                        GlobalVariables.XtraVariables.Add(tagName, tagValue);
                }
            }
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            if (olvSelectedFields.SelectedItems.Count > 0)
            {
                frmColorize fColor = new frmColorize();
                fColor.ColorWhat = ((Field)olvSelectedFields.SelectedObject).COLORWHAT;
                fColor.ColorColor = ((Field)olvSelectedFields.SelectedObject).COLORNAME;
                fColor.ColorCondition = ((Field)olvSelectedFields.SelectedObject).COLORCONDITION;
                fColor.ColorConvertTo = ((Field)olvSelectedFields.SelectedObject).COLORCONVERTION;
                fColor.ColorValue = ((Field)olvSelectedFields.SelectedObject).COLORVALUE;

                if (fColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ((Field)olvSelectedFields.SelectedObject).COLORWHAT=fColor.ColorWhat == "NONE" ? string.Empty : fColor.ColorWhat;
                    ((Field)olvSelectedFields.SelectedObject).COLORNAME = fColor.ColorColor;
                    ((Field)olvSelectedFields.SelectedObject).COLORCONDITION = fColor.ColorCondition;
                    ((Field)olvSelectedFields.SelectedObject).COLORCONVERTION = fColor.ColorConvertTo;
                    ((Field)olvSelectedFields.SelectedObject).COLORVALUE = fColor.ColorValue;
                    olvSelectedFields.RefreshObject(olvSelectedFields.SelectedObject);
                }
            }
        }

        private void olvSelectedFields_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == this.olvCol7.Index)
            {
                Field fld = (Field)e.Model;
                if (fld.COLORWHAT != "NONE" && fld.COLORWHAT != string.Empty && fld.COLORWHAT != null)
                    e.SubItem.BackColor = Color.FromArgb(int.Parse(fld.COLORNAME));
            }
        }
    }
}
