using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseCore.Entities;
using SynapseReport.Entities;
using SynapseReport.Forms;
using SynapseReport.GraphTemplates;
using SynapseReport.Functionalities;
using SynapseCore.Database;
using SynapseAdvancedControls;
using System.Reflection;
using System.Threading;
namespace SynapseReport.UserControls
{
    public delegate void QueryEventHandler(Object sender, QueryEventArgs e);
    public partial class reportControl : UserControl
    {
        private Category _category;
        private Definition _report;
        private ReportType _reportType;
        private IList<Field> _fields;
        private IList<Filter> _filters;
        private IList<ExtraLine> _extralines;
        private Int64 _reportId;
        private bool _IsForDesign;
        private IGraph ctrlGraph;
        private Type[] typelist;

        private StringBuilder _queryFilter;
        private StringBuilder _query;
        private string Query;
        private string XtraTitle;

        private bool ShowXtraLines = false;
        private List<object[]> XtraLines = new List<object[]>();


        public event QueryEventHandler QueryChanged;
        protected virtual void OnQueryChanged(QueryEventArgs e)
        {
            if (QueryChanged!=null)
                QueryChanged(this, e);
        }

        [Category("Report Control"), Description("The Control is used for Report Design")]
        public bool IsForDesign
        {
            get { return _IsForDesign; }
            set { _IsForDesign = value; }
        }

        [Category("Report Control"), Description("Id of the Report")]
        public Int64 ReportId
        {
            get { return _reportId; }
            set { _reportId = value; }
        }

        public reportControl()
        {
            InitializeComponent();

            tsbRefresh.Text = SynapseForm.GetLabel("reportControl.tsbRefresh");
            tsbClose.Text = SynapseForm.GetLabel("reportControl.tsbClose");
            tsbApply.Text = SynapseForm.GetLabel("reportControl.tsbApply");
            tsbReset.Text = SynapseForm.GetLabel("reportControl.tsbReset");
            gbFilter.Text = SynapseForm.GetLabel("reportControl.gbFilter");
            gbResult.Text = SynapseForm.GetLabel("reportControl.gbResult");

            typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "SynapseReport.GraphTemplates");
        }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        public void Load()
        {
            if (_IsForDesign)
            {
                tsbRefresh.Visible = true;
                tsbClose.Visible = false;
                synapseListFilter1.Visible = false;
            }
            else
            {
                tsbRefresh.Visible = false;
                tsbClose.Visible = true;
                synapseListFilter1.Visible = true;
            }

            _report = Definition.LoadByID(_reportId);
            _category = Category.LoadByID(_report.FK_CATEGORY);
            _reportType = ReportType.LoadByID(_report.FK_TYPE);
            _fields = Field.Load("WHERE FK_REPORT=" + _reportId + " ORDER BY POSITION");
            _filters = Filter.Load("WHERE FK_REPORT=" + _reportId + " ORDER BY POSITION");
            _extralines = ExtraLine.Load("WHERE FK_REPORT=" + _reportId + " ORDER BY POSITION");
            if (_extralines.Count > 0)
                ShowXtraLines = true;
            else
                ShowXtraLines = false;

            if (_report.ADDCATEGORY)
                lbName.Text = _category.LABEL.ToString() + " - " + _report.LABEL.ToString();
            else
                lbName.Text = _report.LABEL.ToString();

            if (_reportType.ISGRAPH)
            {
                zedGraphControl1.Visible = true;
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.GraphPane.XAxis.Title.Text = "";
                zedGraphControl1.GraphPane.YAxis.Title.Text = "";
                zedGraphControl1.GraphPane.AxisChange();
                zedGraphControl1.AxisChange();
                zedGraphControl1.Refresh();

                Type t = typelist.First(z => String.Equals(z.FullName.ToUpper(), ("SynapseReport.GraphTemplates." + _reportType.TYPENAME + "_Template").ToUpper()));
                ctrlGraph = (IGraph)Activator.CreateInstance(t);

                olvResult.Visible = false;
                olvXtraLines.Visible = false;
                synapseListFilter1.Visible = false;
            }
            else
            {
                olvResult.AllColumns.RemoveAll(x => x.Text.Length > 0);
                olvResult.Columns.Clear();

                olvXtraLines.AllColumns.RemoveAll(x => x.Text.Length > 0);
                olvXtraLines.Columns.Clear();

                if (ShowXtraLines)
                {
                    olvXtraLines.Visible = true;
                    olvXtraLines.Items.Clear();
                    splitResult.Panel2Collapsed = false;
                    synapseListFilter1.FooterListView = olvXtraLines;
                }
                else
                {
                    olvXtraLines.Visible = false;
                    splitResult.Panel2Collapsed = true;
                    synapseListFilter1.FooterListView = null;
                }

                olvResult.Visible = true;
                olvResult.AccessibleName = lbName.Text;
                olvResult.Items.Clear();

                zedGraphControl1.Visible = false;

                synapseListFilter1.ListID = _report.ID.ToString();
                synapseListFilter1.HideSaveConfig = false;
                synapseListFilter1.ListView = olvResult;
            }

            createFilterControls();

            gbResult.Top = gbFilter.Top + gbFilter.Height + 5;
            gbResult.Height = this.Height - gbFilter.Height - 40;

            OnQueryChanged(new QueryEventArgs(""));
        }

        private void createFilterControls()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (Filter _flt in _filters)
            {
                switch (_flt.TYPE)
                { 
                    case "ONE VALUE LIST":
                        reportCombo _combo = new reportCombo(FilterData.LoadFromQuery(GlobalFunctions.ReplaceXtraVariables(_flt.DATA_QUERY), GlobalVariables.selectedOrigin.DBCONNECTION));
                        _combo.lbLabel.Text = _flt.LABEL.ToString();
                        _combo.Width = _flt.WIDTH;
                        _combo.Tag = _flt.ID;
                        _combo.Visible = true;
                        flowLayoutPanel1.Controls.Add(_combo);
                        break;
                    case "MULTI VALUE LIST":
                        reportList _list = new reportList(FilterData.LoadFromQuery(GlobalFunctions.ReplaceXtraVariables(_flt.DATA_QUERY), GlobalVariables.selectedOrigin.DBCONNECTION));
                        _list.lbLabel.Text = _flt.LABEL.ToString();
                        _list.Width = _flt.WIDTH;
                        _list.Tag = _flt.ID;
                        _list.Visible = true;
                        flowLayoutPanel1.Controls.Add(_list);
                        break;
                    case "TEXT":
                        reportText _text = new reportText();
                        _text.lbLabel.Text = _flt.LABEL.ToString();
                        _text.Width = _flt.WIDTH;
                        _text.Tag = _flt.ID;
                        _text.Visible = true;
                        flowLayoutPanel1.Controls.Add(_text);
                        break;
                    case "DATE":
                        reportDate _date = new reportDate();
                        _date.lbLabel.Text = _flt.LABEL.ToString();
                        _date.Width = _flt.WIDTH;
                        _date.Tag = _flt.ID;
                        _date.Visible = true;
                        flowLayoutPanel1.Controls.Add(_date);
                        break;
                    case "BOOLEAN":
                        reportBool _bool = new reportBool();
                        _bool.lbLabel.Text = _flt.LABEL.ToString();
                        _bool.Width = _flt.WIDTH;
                        _bool.Tag = _flt.ID;
                        _bool.ckBoolean.CheckState = CheckState.Indeterminate;
                        _bool.Visible = true;
                        flowLayoutPanel1.Controls.Add(_bool);
                        break;
                    case "NUMERIC":
                        reportNumeric _num = new reportNumeric();
                        _num.lbLabel.Text = _flt.LABEL.ToString();
                        _num.Width = _flt.WIDTH;
                        _num.Tag = _flt.ID;
                        _num.Visible = true;
                        flowLayoutPanel1.Controls.Add(_num);
                        break;
                    case "PERIOD":
                        reportPeriod _period = new reportPeriod();
                        _period.lbLabel.Text = _flt.LABEL.ToString();
                        _period.Width = _flt.WIDTH;
                        _period.Tag = _flt.ID;
                        _period.Visible = true;
                        flowLayoutPanel1.Controls.Add(_period);
                        break;
                }
            }
        }

        public void Apply_Filter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            generateFilters();
            generateQuery();
            refreshResult();
            Cursor.Current = Cursors.Default;
        }

        public void Refresh_LinkedList(object sender, EventArgs e)
        {
            reportCombo _mainList = (reportCombo)sender;
            Filter _mainFilter = Filter.LoadByID((Int64)_mainList.Tag);

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                switch (ctrl.GetType().ToString())
                {
                    case "SynapseReport.UserControls.reportCombo":
                         reportCombo _combo = (reportCombo)ctrl;
                        Filter _flt1 = Filter.LoadByID((Int64)_combo.Tag);
                        if (_flt1.LINKED_FILTERID == _mainFilter.ID)
                        {
                            if (((FilterData)_mainList.comboBox.SelectedItem).VALUE != "0")
                            {
                                switch (GlobalVariables.selectedOrigin.DBTYPE)
                                {
                                    case DatabaseType.Oracle:
                                        _combo.refreshList(", " + _mainFilter.DATA_TABLE + " WHERE " + _mainFilter.DATA_TABLE + "." + _mainFilter.DATA_VALUE + "=" + _flt1.LINKED_FIELD + " AND TO_CHAR(" + _flt1.LINKED_FIELD + ") = '" + ((FilterData)_mainList.comboBox.SelectedItem).VALUE + "'");
                                        break;
                                    default:
                                        _combo.refreshList("INNER JOIN " + _mainFilter.DATA_TABLE + " AS " + _mainFilter.NAME + " ON " + _mainFilter.DATA_TABLE + "." + _mainFilter.DATA_VALUE + "=" + _mainFilter.NAME + "." + _flt1.LINKED_FIELD + " AND CONVERT(VARCHAR, " + _mainFilter.NAME + "." +_flt1.LINKED_FIELD + ") = '" + ((FilterData)_mainList.comboBox.SelectedItem).VALUE + "'");
                                        break;
                                }
                            }
                            else
                            {
                                _combo.refreshList();
                            }
                        }
                        break;
                    case "SynapseReport.UserControls.reportList":
                        reportList _list = (reportList)ctrl;
                        Filter _flt2 = Filter.LoadByID((Int64)_list.Tag);
                        if (_flt2.LINKED_FILTERID == _mainFilter.ID)
                        {
                            if (((FilterData)_mainList.comboBox.SelectedItem).VALUE != "0")
                            {
                                switch (GlobalVariables.selectedOrigin.DBTYPE)
                                {
                                    case DatabaseType.Oracle:
                                        _list.refreshList(", " + _mainFilter.DATA_TABLE + " WHERE " + _mainFilter.DATA_TABLE + "." + _mainFilter.DATA_VALUE + "=" + _flt2.LINKED_FIELD + " AND TO_CHAR(" + _flt2.LINKED_FIELD + ") = '" + ((FilterData)_mainList.comboBox.SelectedItem).VALUE + "'");
                                        break;
                                    default:
                                        _list.refreshList("INNER JOIN " + _mainFilter.DATA_TABLE + " ON " + _mainFilter.DATA_TABLE + "." + _mainFilter.DATA_VALUE + "=" + _flt2.LINKED_FIELD + " AND CONVERT(VARCHAR, " + _flt2.LINKED_FIELD + ") = '" + ((FilterData)_mainList.comboBox.SelectedItem).VALUE + "'");
                                        break;
                                }
                            }
                            else
                            {
                                _list.refreshList();
                            }
                        }
                        break;
                }
            }
        }

        private void generateFilters()
        {
            _queryFilter = new StringBuilder("");
            XtraTitle = "";

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                switch (ctrl.GetType().ToString())
                {
                    case "SynapseReport.UserControls.reportCombo":
                        reportCombo _combo = (reportCombo)ctrl;
                        Filter _flt1 = Filter.LoadByID((Int64)_combo.Tag);

                        if (_combo.comboBox.SelectedItem != null)
                        {
                            string value = ((FilterData)_combo.comboBox.SelectedItem).VALUE;
                            if (_flt1.ADD_TO_REPORTTITLE)
                            {
                                if (XtraTitle != "")
                                    XtraTitle += " - ";
                                XtraTitle += _flt1.LABEL.ToString() + ": " + ((FilterData)_combo.comboBox.SelectedItem).DISPLAY;
                            }
                            if (value != "0" && value != null)
                            {
                                if (_queryFilter.ToString() != "")
                                {
                                    _queryFilter.Append(" AND ");
                                }
                                _queryFilter.Append(" (");
                                Array arrVal = value.Split(';');

                                foreach (string sVal in arrVal)
                                {
                                    switch (GlobalVariables.selectedOrigin.DBTYPE)
                                    {
                                        case DatabaseType.Oracle:
                                            if (_flt1.CTRL_TYPE == "LIKE")
                                                _queryFilter.Append("TO_CHAR(" + _flt1.CTRL_CUSTOM + ") LIKE '" + sVal + "%'");
                                            else
                                                _queryFilter.Append("TO_CHAR(" + _flt1.CTRL_CUSTOM + ")='" + sVal + "'");
                                            break;
                                        default:
                                            if (_flt1.CTRL_TYPE == "LIKE")
                                                _queryFilter.Append("CONVERT(VARCHAR, " + _flt1.CTRL_CUSTOM + ") LIKE '" + sVal + "%'");
                                            else
                                                _queryFilter.Append("CONVERT(VARCHAR, " + _flt1.CTRL_CUSTOM + ")='" + sVal + "'");
                                            break;
                                    }

                                    _queryFilter.Append(" OR ");
                                }
                                _queryFilter.Remove(_queryFilter.Length - 4, 4);
                                _queryFilter.Append(")");
                            }
                        }
                        break;
                    case "SynapseReport.UserControls.reportList":
                        reportList _list = (reportList)ctrl;
                        Filter _flt2 = Filter.LoadByID((Int64)_list.Tag);
                        bool hasSelectedValue=false;

                        for (Int32 x=0; x < _list.listBox.SelectedItems.Count; x++)
                        {
                            if (_list.listBox.SelectedItems[x] != null)
                            {
                                string value = ((FilterData)_list.listBox.SelectedItems[x]).VALUE;
                                if (_flt2.ADD_TO_REPORTTITLE)
                                {
                                    if (XtraTitle != "")
                                        XtraTitle += " - ";
                                    XtraTitle += _flt2.LABEL.ToString() + ": " + ((FilterData)_list.listBox.SelectedItems[x]).DISPLAY;
                                }
                                if (value != "0" && value != null)
                                {
                                    if (!hasSelectedValue)
                                    {
                                        if (_queryFilter.ToString() != "")
                                        {
                                            _queryFilter.Append(" AND (");
                                        }
                                        else
                                        {
                                            _queryFilter.Append(" (");
                                        }
                                    }
                                    else
                                    {
                                        _queryFilter.Append(" OR ");
                                    }
                                    switch (GlobalVariables.selectedOrigin.DBTYPE)
                                    {
                                        case DatabaseType.Oracle:
                                            if (_flt2.CTRL_TYPE == "LIKE")
                                                _queryFilter.Append("TO_CHAR(" + _flt2.CTRL_CUSTOM + ") LIKE '" + value + "%'");
                                            else
                                                _queryFilter.Append("TO_CHAR(" + _flt2.CTRL_CUSTOM + ")='" + value + "'");
                                            break;
                                        default:
                                            if (_flt2.CTRL_TYPE == "LIKE")
                                                _queryFilter.Append("CONVERT(VARCHAR, " + _flt2.CTRL_CUSTOM + ") LIKE '" + value + "%'");
                                            else
                                                _queryFilter.Append("CONVERT(VARCHAR, " + _flt2.CTRL_CUSTOM + ")='" + value + "'");
                                            break;
                                    }
                                    hasSelectedValue = true;
                                }
                            }
                        }
                        if (hasSelectedValue)
                            _queryFilter.Append(") ");
                        break;
                    case "SynapseReport.UserControls.reportText":
                        reportText _text = (reportText)ctrl;
                        Filter _flt3 = Filter.LoadByID((Int64)_text.Tag);

                        if (_text.textBox.Text.Trim() != "")
                        {
                            if (_flt3.ADD_TO_REPORTTITLE)
                            {
                                if (XtraTitle != "")
                                    XtraTitle += " - ";
                                XtraTitle += _flt3.LABEL.ToString() + ": " + _text.textBox.Text.Trim();
                            }

                            if (_queryFilter.ToString() != "")
                            {
                                _queryFilter.Append(" AND ");
                            }
                            _queryFilter.Append("UPPER( " + _flt3.CTRL_CUSTOM + ") LIKE '" + _text.textBox.Text.Trim().ToUpper() + "%'");

                            //if (_flt3.ADD_TO_REPORTTITLE)
                            //{
                            //    if (XtraTitle != "")
                            //        XtraTitle += " - ";
                            //    XtraTitle += _flt3.LABEL.ToString() + ": " + _text.textBox.Text.Trim();
                            //}
                        }
                        break;
                    case "SynapseReport.UserControls.reportDate":
                        reportDate _date = (reportDate)ctrl;
                        Filter _flt4 = Filter.LoadByID((Int64)_date.Tag);
                        string _compare="";

                        if (_date.ComboBox.SelectedValue.ToString() != "")
                        {
                            if (_flt4.ADD_TO_REPORTTITLE)
                            {
                                if (XtraTitle != "")
                                    XtraTitle += " - ";

                                if (_date.ComboBox.SelectedValue.ToString() == "BETWEEN")
                                    XtraTitle += _flt4.LABEL.ToString() + " " + _date.ComboBox.Text + ": " + _date.Date1.Value.Date.ToString("yyyy-MM-dd") + " " + _date.lbl2.Text + ": " + _date.Date2.Value.Date.ToString("yyyy-MM-dd");
                                else
                                    XtraTitle += _flt4.LABEL.ToString() + " " + _date.ComboBox.Text + ": " + _date.Date1.Value.Date.ToString("yyyy-MM-dd");
                            }

                            switch (_date.ComboBox.SelectedValue.ToString())
                            {
                                case "<":
                                case ">=":
                                    switch (GlobalVariables.selectedOrigin.DBTYPE)
                                    {
                                        case DatabaseType.Oracle:
                                            _compare = _flt4.CTRL_CUSTOM + " " + _date.ComboBox.SelectedValue.ToString() + " TO_DATE('" + _date.Date1.Value.Date + "', 'DD/MM/YYYY HH24:MI:SS')";
                                            break;
                                        default:
                                            _compare = _flt4.CTRL_CUSTOM + " " + _date.ComboBox.SelectedValue.ToString() + " CONVERT(DATETIME, '" + _date.Date1.Value.Date + "', 103)";
                                            break;
                                    }
                                    break;
                                case ">":
                                case "<=":
                                    switch (GlobalVariables.selectedOrigin.DBTYPE)
                                    {
                                        case DatabaseType.Oracle:
                                            _compare = _flt4.CTRL_CUSTOM + " " + _date.ComboBox.SelectedValue.ToString() + " TO_DATE('" + _date.Date1.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 'DD/MM/YYYY HH24:MI:SS')";
                                            break;
                                        default:
                                            _compare = _flt4.CTRL_CUSTOM + " " + _date.ComboBox.SelectedValue.ToString() + " CONVERT(DATETIME, '" + _date.Date1.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 103)";
                                            break;
                                    }
                                    break;
                                case "=":
                                    switch (GlobalVariables.selectedOrigin.DBTYPE)
                                    {
                                        case DatabaseType.Oracle:
                                            _compare = "(" + _flt4.CTRL_CUSTOM + ">= TO_DATE('" + _date.Date1.Value.Date + "', 'DD/MM/YYYY HH24:MI:SS') AND " + _flt4.CTRL_CUSTOM + "<= TO_DATE('" + _date.Date1.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 'DD/MM/YYYY HH24:MI:SS'))";
                                            break;
                                        default:
                                            _compare = "(" + _flt4.CTRL_CUSTOM + ">= CONVERT(DATETIME, '" + _date.Date1.Value.Date + "', 103) AND " + _flt4.CTRL_CUSTOM + "<= CONVERT(DATETIME, '" + _date.Date1.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 103))";
                                            break;
                                    }
                                    break;
                                case "BETWEEN":
                                    switch (GlobalVariables.selectedOrigin.DBTYPE)
                                    {
                                        case DatabaseType.Oracle:
                                            _compare = _flt4.CTRL_CUSTOM + " BETWEEN TO_DATE('" + _date.Date1.Value.Date + "', 'DD/MM/YYYY HH24:MI:SS') AND TO_DATE('" + _date.Date2.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 'DD/MM/YYYY HH24:MI:SS')";
                                            break;
                                        default:
                                            _compare = _flt4.CTRL_CUSTOM + " BETWEEN CONVERT(DATETIME, '" + _date.Date1.Value.Date + "', 103) AND CONVERT(DATETIME, '" + _date.Date2.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 103)";
                                            break;
                                    }
                                    break;
                            }
                            if(_date.ckNull.Checked)
                            {
                                if (_compare != "")
                                    _compare = "(" + _compare + " OR " + _flt4.CTRL_CUSTOM + " IS NULL) ";
                            }
                            else
                            {
                                if (_compare != "")
                                    _compare = "(" + _compare + " AND " + _flt4.CTRL_CUSTOM + " IS NOT NULL) ";
                                else
                                    _compare=_flt4.CTRL_CUSTOM + " IS NOT NULL ";
                            }
                        }
                        
                        if (_compare != "")
                        {
                            if (_queryFilter.ToString() != "")
                            {
                                _queryFilter.Append(" AND ");
                            }
                            _queryFilter.Append(_compare);
                        }
                        break;
                    case "SynapseReport.UserControls.reportPeriod":
                        reportPeriod _period = (reportPeriod)ctrl;
                        Filter _flt7 = Filter.LoadByID((Int64)_period.Tag);
                        string _comparePeriod="";

                        if (_period.ComboBox.SelectedValue.ToString() != "")
                        {
                            if (_flt7.ADD_TO_REPORTTITLE)
                            {
                                if (XtraTitle != "")
                                    XtraTitle += " - ";

                                if (_period.ComboBox.SelectedValue.ToString() == "BETWEEN")
                                    XtraTitle +=  _flt7.LABEL.ToString() + " " + _period.ComboBox.Text + ": " + _period.yearFrom.SelectedValue.ToString() + "-" + _period.monthFrom.SelectedValue.ToString() + " " + _period.lbl2.Text + ": " + _period.yearTo.SelectedValue.ToString() + "-" + _period.monthTo.SelectedValue.ToString();
                                else
                                    XtraTitle += _flt7.LABEL.ToString() + " " + _period.ComboBox.Text + ": " + _period.yearFrom.SelectedValue.ToString() + "-" + _period.monthFrom.SelectedValue.ToString();
                            }

                            switch (_period.ComboBox.SelectedValue.ToString())
                            {
                                case "<":
                                case ">":
                                case "<=":
                                case ">=":
                                case "=":
                                    DateTime dtFromFirst = new DateTime(int.Parse(_period.yearFrom.SelectedValue.ToString()), int.Parse(_period.monthFrom.SelectedValue.ToString()), 1);
                                    DateTime dtFromLast = new DateTime(int.Parse(_period.yearFrom.SelectedValue.ToString()), int.Parse(_period.monthFrom.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(_period.yearFrom.SelectedValue.ToString()), int.Parse(_period.monthFrom.SelectedValue.ToString())));
                                    switch (_period.ComboBox.SelectedValue.ToString())
                                    {
                                        case "<":
                                        case ">=":
                                            switch (GlobalVariables.selectedOrigin.DBTYPE)
                                            {
                                                case DatabaseType.Oracle:
                                                    _comparePeriod = _flt7.CTRL_CUSTOM + " " + _period.ComboBox.SelectedValue.ToString() + " TO_DATE('" + dtFromFirst.Date + "', 'DD/MM/YYYY HH24:MI:SS')";
                                                    break;
                                                default:
                                                    _comparePeriod = _flt7.CTRL_CUSTOM + " " + _period.ComboBox.SelectedValue.ToString() + " CONVERT(DATETIME, '" + dtFromFirst.Date + "', 103)";
                                                    break;
                                            }
                                            break;
                                        case ">":
                                        case "<=":
                                            switch (GlobalVariables.selectedOrigin.DBTYPE)
                                            {
                                                case DatabaseType.Oracle:
                                                    _comparePeriod = _flt7.CTRL_CUSTOM + " " + _period.ComboBox.SelectedValue.ToString() + " TO_DATE('" + dtFromLast.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 'DD/MM/YYYY HH24:MI:SS')";
                                                    break;
                                                default:
                                                    _comparePeriod = _flt7.CTRL_CUSTOM + " " + _period.ComboBox.SelectedValue.ToString() + " CONVERT(DATETIME, '" + dtFromLast.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 103)";
                                                    break;
                                            }
                                            break;
                                        case "=":
                                            switch (GlobalVariables.selectedOrigin.DBTYPE)
                                            {
                                                case DatabaseType.Oracle:
                                                    _comparePeriod = "(" + _flt7.CTRL_CUSTOM + ">= TO_DATE('" + dtFromFirst.Date + "', 'DD/MM/YYYY HH24:MI:SS') AND " + _flt7.CTRL_CUSTOM + "<= TO_DATE('" + dtFromLast.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 'DD/MM/YYYY HH24:MI:SS'))";
                                                    break;
                                                default:
                                                    _comparePeriod = "(" + _flt7.CTRL_CUSTOM + ">= CONVERT(DATETIME, '" + dtFromFirst.Date + "', 103) AND " + _flt7.CTRL_CUSTOM + "<= CONVERT(DATETIME, '" + dtFromLast.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 103))";
                                                    break;
                                            }
                                            break;
                                    }
                                    break;
                                case "BETWEEN":
                                    DateTime dtFrom = new DateTime(int.Parse(_period.yearFrom.SelectedValue.ToString()), int.Parse(_period.monthFrom.SelectedValue.ToString()), 1);
                                    DateTime dtTo = new DateTime(int.Parse(_period.yearTo.SelectedValue.ToString()), int.Parse(_period.monthTo.SelectedValue.ToString()), DateTime.DaysInMonth(int.Parse(_period.yearTo.SelectedValue.ToString()), int.Parse(_period.monthTo.SelectedValue.ToString())));
                                 
                                    switch (GlobalVariables.selectedOrigin.DBTYPE)
                                    {
                                        case DatabaseType.Oracle:
                                            _comparePeriod = _flt7.CTRL_CUSTOM + " BETWEEN TO_DATE('" + dtFrom.Date + "', 'DD/MM/YYYY HH24:MI:SS') AND TO_DATE('" + dtTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 'DD/MM/YYYY HH24:MI:SS')";
                                            break;
                                        default:
                                            _comparePeriod = _flt7.CTRL_CUSTOM + " BETWEEN CONVERT(DATETIME, '" + dtFrom.Date + "', 103) AND CONVERT(DATETIME, '" + dtTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59) + "', 103)";
                                            break;
                                    }
                                    break;
                            }
                        }

                        if (_comparePeriod != "")
                        {
                            if (_queryFilter.ToString() != "")
                            {
                                _queryFilter.Append(" AND ");
                            }
                            _queryFilter.Append(_comparePeriod);
                        }
                        break;
                    case "SynapseReport.UserControls.reportBool":
                        reportBool _bool = (reportBool)ctrl;
                        Filter _flt5 = Filter.LoadByID((Int64)_bool.Tag);

                        switch (_bool.ckBoolean.CheckState)
                        {
                            case CheckState.Checked:
                                if (_queryFilter.ToString() != "")
                                {
                                    _queryFilter.Append(" AND ");
                                }
                                _queryFilter.Append(_flt5.CTRL_CUSTOM + " = 'True'");
                                break;
                            case CheckState.Unchecked:
                                if (_queryFilter.ToString() != "")
                                {
                                    _queryFilter.Append(" AND ");
                                }
                                _queryFilter.Append(_flt5.CTRL_CUSTOM + " = 'False'");
                                break;
                        }
                        break;
                    case "SynapseReport.UserControls.reportNumeric":
                        reportNumeric _num = (reportNumeric)ctrl;
                        Filter _flt6 = Filter.LoadByID((Int64)_num.Tag);
                        string _compareNum = "";

                        if (_num.ComboBox1.SelectedValue.ToString() != "")
                        {
                            _compareNum = _flt6.CTRL_CUSTOM + " " + _num.ComboBox1.SelectedValue.ToString() + " " + _num.UpDown1.Value;

                            if (_num.ComboBox2.SelectedValue.ToString() != "")
                            {
                                _compareNum = "(" + _compareNum + " AND " + _flt6.CTRL_CUSTOM + " " + _num.ComboBox2.SelectedValue.ToString() + " " + _num.UpDown2.Value + ")";
                            }
                        }

                        if (_compareNum != "")
                        {
                            if (_queryFilter.ToString() != "")
                            {
                                _queryFilter.Append(" AND ");
                            }
                            _queryFilter.Append(_compareNum);
                        }
                        break;
                }
            }
        }

        private void generateQuery()
        {
            _query = new StringBuilder("SELECT ");

            foreach(Field fld in _fields)
            {
                _query.Append(fld.FIELDNAME + ",");
            }
            _query.Remove(_query.ToString().Length - 1, 1);
            _query.Append(Environment.NewLine);

            _query.Append(" FROM ");

            if (_report.QRY_JOIN != "")
            {
                _query.Append(_report.QRY_JOIN);
            }

            if (_report.QRY_CONDITION != "" || _queryFilter.ToString() != "")
            {
                _query.Append(Environment.NewLine);
                _query.Append(" WHERE ");
                _query.Append(_report.QRY_CONDITION);
                if (_queryFilter.ToString() != "")
                {
                    if (_report.QRY_CONDITION != "")
                    {
                        _query.Append(" AND ");
                        _query.Append(Environment.NewLine);
                    }
                    _query.Append(_queryFilter.ToString());
                }
            }

            if (_report.QRY_GROUP != "")
            {
                _query.Append(Environment.NewLine);
                _query.Append(" GROUP BY " + _report.QRY_GROUP);
            }

            if (_reportType.ISGRAPH)
            {
                _query.Append(Environment.NewLine);
                _query.Append(" ORDER BY 1");
            }
            else
            {
                string Orderby = "";
                foreach (Field fld in _fields.OrderBy(f => f.SORTING_ORDER).ThenBy(f =>f.POSITION))
                {
                    if (fld.SORTING != "")
                        Orderby += fld.FIELDNAME + " " + fld.SORTING + ",";
                }

                if (Orderby != "")
                {
                    _query.Append(Environment.NewLine);
                    _query.Append(" ORDER BY ");
                    _query.Append(Orderby);
                    _query.Remove(_query.ToString().Length - 1, 1);
                }
            }

            Query=GlobalFunctions.ReplaceXtraVariables(_query.ToString());

            OnQueryChanged(new QueryEventArgs(Query));
        }

        private void refreshResult()
        {
            string reportTitle = "";

            if (_report.ADDCATEGORY)
                reportTitle = _category.LABEL.ToString() + " - " + _report.LABEL.ToString();
            else
                reportTitle = _report.LABEL.ToString();
            if (XtraTitle != "")
                reportTitle += " - " + XtraTitle;

            lbName.Text = reportTitle;
            olvResult.AccessibleName = reportTitle.Replace(" - ", "\n").Replace(":", "");

            lbCount.Text = "";

            try
            {
                if (_reportType.ISGRAPH)
                {
                    zedGraphControl1.GraphPane.CurveList.Clear();

                    ctrlGraph.Generate(ref zedGraphControl1, Query, _report, _fields.ToList());
                    zedGraphControl1.GraphPane.AxisChange();
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Refresh();
                }
                else
                {
                    DataTable DT = new DataTable();
                    DT = SynapseCore.Database.DBFunction.GetTableFromQuery(Query, GlobalVariables.selectedOrigin.DBCONNECTION);

                    olvResult.Items.Clear();
                    olvResult.ShowGroups = false;

                    olvXtraLines.Items.Clear();
                    olvXtraLines.ShowGroups = false;

                    if (olvResult.AllColumns.Count == 0)
                    {
                        foreach (Field fld in _fields)
                        {
                            OLVColumn aNewColumn = new OLVColumn();
                            if (fld.WIDTH != 0)
                                aNewColumn.Width = fld.WIDTH;
                            else
                                aNewColumn.Width = 150;
                            aNewColumn.Text = fld.ALIAS.ToString();
                            aNewColumn.AspectToStringFormat = fld.FORMAT;

                            aNewColumn.AspectGetter = delegate(object x)
                            {
                                if (x is DataRow)
                                {
                                    if (olvResult.AllColumns.IndexOf(aNewColumn) < ((DataRow)x).Table.Columns.Count && olvResult.AllColumns.IndexOf(aNewColumn) > -1)
                                    {
                                        if (aNewColumn.Tag != "Rendered" && ((DataRow)x)[olvResult.AllColumns.IndexOf(aNewColumn)].GetType().ToString() == "System.Boolean")
                                        {
                                            aNewColumn.Renderer = new MappedImageRenderer(new Object[] {true, imageList.Images["True"], false, imageList.Images["False"]});
                                            aNewColumn.Tag = "Rendered";
                                            aNewColumn.TextAlign = HorizontalAlignment.Center;
                                        }
                                        if (olvResult.AllColumns.IndexOf(aNewColumn) > -1)
                                            return ((DataRow)x)[olvResult.AllColumns.IndexOf(aNewColumn)];
                                        else
                                            return string.Empty;
                                    }
                                    else
                                        return string.Empty;
                                }
                                else
                                {
                                    return string.Empty;
                                }
                            };
                            olvResult.AllColumns.Add(aNewColumn);


                            // Test of Xtra Lines at the end of the report => Dosiview Reports ?
                            if (ShowXtraLines)
                            {
                                OLVColumn XtraColumn = new OLVColumn();
                                if (fld.WIDTH != 0)
                                    XtraColumn.Width = fld.WIDTH;
                                else
                                    XtraColumn.Width = 150;
                                XtraColumn.Text = fld.ALIAS.ToString();
                                //XtraColumn.AspectToStringFormat = fld.FORMAT;

                                XtraColumn.AspectGetter = delegate(object x)
                                {
                                    if (x is DataRow)
                                    {
                                        if (olvXtraLines.AllColumns.IndexOf(XtraColumn) < ((DataRow)x).Table.Columns.Count && olvXtraLines.AllColumns.IndexOf(XtraColumn) > -1)
                                        {
                                            if (olvXtraLines.AllColumns.IndexOf(XtraColumn) > -1)
                                                return ((DataRow)x)[olvXtraLines.AllColumns.IndexOf(XtraColumn)];
                                            else
                                                return string.Empty;
                                        }
                                        else
                                            return string.Empty;
                                    }
                                    else
                                    {
                                        return string.Empty;
                                    }
                                };
                                olvXtraLines.AllColumns.Add(XtraColumn);
                            }
                        }
                        olvResult.RebuildColumns();

                        //if (ShowXtraLines)
                        //    olvXtraLines.RebuildColumns();
                    }
                    olvResult.SetObjects(DT.Rows);

                    if (ShowXtraLines)
                    {
                        olvXtraLines.RebuildColumns();

                        // Test of Xtra Lines at the end of the report => Dosiview Reports ?
                        DataTable XtraDT = new DataTable();

                        decimal tst;
                        decimal[] tot = new decimal[_fields.Count()];
                        decimal[] max = new decimal[_fields.Count()];
                        decimal[] min = new decimal[_fields.Count()];
                        decimal[] avg = new decimal[_fields.Count()];
                        Int64[] cnt = new Int64[_fields.Count()];
                        Int64[] cntnb = new Int64[_fields.Count()];

                        for (int x = 0; x < _fields.Count; x++)
                        {
                            tot[x] = 0;
                            max[x] = 0;
                            min[x] = decimal.MaxValue;
                            avg[x] = 0;
                            cnt[x] = 0;
                            cntnb[x] = 0;
                        }

                        foreach (DataColumn c in DT.Columns) 
                        {
                            XtraDT.Columns.Add(c.ColumnName);
                            foreach (DataRow r in DT.Rows)
                            {
                                if (r.Field<object>(DT.Columns.IndexOf(c)) != null && decimal.TryParse(r.Field<object>(DT.Columns.IndexOf(c)).ToString(), out tst))
                                    tot[DT.Columns.IndexOf(c)] += decimal.Parse(r.Field<object>(DT.Columns.IndexOf(c)).ToString());

                                if (r.Field<object>(DT.Columns.IndexOf(c)) != null && decimal.TryParse(r.Field<object>(DT.Columns.IndexOf(c)).ToString(), out tst))
                                    if (decimal.Parse(r.Field<object>(DT.Columns.IndexOf(c)).ToString()) > max[DT.Columns.IndexOf(c)])
                                        max[DT.Columns.IndexOf(c)] = decimal.Parse(r.Field<object>(DT.Columns.IndexOf(c)).ToString());

                                if (r.Field<object>(DT.Columns.IndexOf(c)) != null && decimal.TryParse(r.Field<object>(DT.Columns.IndexOf(c)).ToString(), out tst))
                                    if (decimal.Parse(r.Field<object>(DT.Columns.IndexOf(c)).ToString()) < min[DT.Columns.IndexOf(c)])
                                        min[DT.Columns.IndexOf(c)] = decimal.Parse(r.Field<object>(DT.Columns.IndexOf(c)).ToString());

                                if (r.Field<object>(DT.Columns.IndexOf(c)) != null && r.Field<object>(DT.Columns.IndexOf(c)).ToString() != string.Empty)
                                    cntnb[DT.Columns.IndexOf(c)] += 1;

                                cnt[DT.Columns.IndexOf(c)] += 1;
                            }

                            if (cntnb[DT.Columns.IndexOf(c)] !=0)
                                avg[DT.Columns.IndexOf(c)] = tot[DT.Columns.IndexOf(c)] / cntnb[DT.Columns.IndexOf(c)];
                        }

                        foreach (ExtraLine ext in _extralines)
                        {
                            ext.LINEFIELDS = ExtraLineField.Load("WHERE FK_EXTRALINE=" + ext.ID + " ORDER BY POSITION").ToList();
                            object[] obj = new object[ext.LINEFIELDS.Count];

                            foreach (ExtraLineField elf in ext.LINEFIELDS)
                            {
                                switch (elf.FUNCTIONCODE)
                                {
                                    case "LBL":
                                        obj[elf.POSITION-1] = ext.LABEL.ToString();
                                        break;
                                    case "SUM":
                                        obj[elf.POSITION - 1] = String.Format(elf.FORMAT, tot[elf.POSITION - 1]);
                                        break;
                                    case "MAX":
                                        obj[elf.POSITION - 1] = String.Format(elf.FORMAT, max[elf.POSITION - 1]);
                                        break;
                                    case "MIN":
                                        obj[elf.POSITION - 1] = String.Format(elf.FORMAT, min[elf.POSITION - 1]);
                                        break;
                                    case "AVG":
                                        obj[elf.POSITION - 1] = String.Format(elf.FORMAT, avg[elf.POSITION - 1]);
                                        break;
                                    case "CNT":
                                        obj[elf.POSITION - 1] = String.Format(elf.FORMAT, cnt[elf.POSITION - 1]);
                                        break;
                                    case "CNTNB":
                                        obj[elf.POSITION - 1] = String.Format(elf.FORMAT, cntnb[elf.POSITION - 1]);
                                        break;
                                }
                            }
                            XtraDT.Rows.Add(obj);
                        }
                        olvXtraLines.SetObjects(XtraDT.Rows);
                    }
                    lbCount.Text = DT.Rows.Count + " " + " Line(s)";
                }
            }
            catch (Exception ex)
            {
                if (IsForDesign)
                {
                    MessageBox.Show("Query Error: " + ex.Message, "Query Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            Load();
        }

        public void Reset_Filter(object sender, EventArgs e)
        {
            if (_reportType.ISGRAPH)
            {
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.GraphPane.AxisChange();
                zedGraphControl1.AxisChange();
                zedGraphControl1.Refresh();
            }
            else
            {
                olvResult.Items.Clear();
                olvXtraLines.Items.Clear();
            }

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                switch (ctrl.GetType().ToString())
                {
                    case "SynapseReport.UserControls.reportCombo":
                        reportCombo _combo = (reportCombo)ctrl;
                        _combo.comboBox.SelectedIndex = 0;
                        break;
                    case "SynapseReport.UserControls.reportList":
                        reportList _list = (reportList)ctrl;
                        _list.listBox.SelectedItems.Clear();
                        _list.listBox.SelectedIndex = 0;
                        break;
                    case "SynapseReport.UserControls.reportText":
                        reportText _text = (reportText)ctrl;
                        _text.textBox.Text = "";
                        break;
                    case "SynapseReport.UserControls.reportDate":
                        reportDate _date = (reportDate)ctrl;
                        _date.ComboBox.SelectedIndex = 0;
                        break;
                    case "SynapseReport.UserControls.reportPeriod":
                        reportPeriod _period = (reportPeriod)ctrl;
                        _period.ComboBox.SelectedIndex = 0;
                        break;
                    case "SynapseReport.UserControls.reportBool":
                        reportBool _bool = (reportBool)ctrl;
                        _bool.ckBoolean.CheckState = CheckState.Indeterminate;
                        break;
                    case "SynapseReport.UserControls.reportNumeric":
                        reportNumeric _num = (reportNumeric)ctrl;
                        _num.ComboBox1.SelectedIndex = 0;
                        _num.UpDown1.Value = 0;
                        _num.UpDown2.Value = 0;
                        break;
                }
            }
            lbCount.Text = "";
            if (IsForDesign)
            {
                _query = new StringBuilder("");
                OnQueryChanged(new QueryEventArgs(_query.ToString()));
            }

            gbFilter.Controls[0].Focus();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            ((frmReport)this.ParentForm).closeTab();
        }

        private void olvResult_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (ShowXtraLines)
                olvXtraLines.Columns[e.ColumnIndex].Width = e.NewWidth;
        }

        private void olvResult_ColumnReordered(object sender, ColumnReorderedEventArgs e)
        {
            if (ShowXtraLines)
            {
                Thread t = new Thread(delegate()
                {
                    System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                    RefreshFooterList();
                });
                t.Start();
            }
        }

        private void RefreshFooterList()
        {
            Thread.Sleep(200);

            var state = olvResult.SaveState();
            olvXtraLines.RestoreState(state);

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = true;
        }

        private void olvResult_FormatCell(object sender, FormatCellEventArgs e)
        {
            string valStr = string.Empty;

            foreach (Field fld in _fields)
            {
                if (fld.COLORWHAT == "CELL")
                {
                    if (e.ColumnIndex == _fields.IndexOf(fld))
                    {
                        valStr = ((System.Data.DataRow)e.Model).ItemArray[fld.POSITION - 1].ToString();

                        if (MustBeColored(valStr, fld))
                            e.SubItem.BackColor = Color.FromArgb(int.Parse(fld.COLORNAME));
                    }
                }
            }
        }

        private void olvResult_FormatRow(object sender, FormatRowEventArgs e)
        {
            string valStr = string.Empty;

            foreach (Field fld in _fields)
            {
                if (fld.COLORWHAT == "ROW")
                {
                    valStr = ((System.Data.DataRow)e.Model).ItemArray[fld.POSITION - 1].ToString();

                    if (MustBeColored(valStr, fld))
                        e.Item.BackColor = Color.FromArgb(int.Parse(fld.COLORNAME));
                }
            }
        }

        private bool MustBeColored(string valStr, Field fld)
        {
            try
            {
                decimal valDec = 0;
                bool valBool = false;
                DateTime valDate = DateTime.MinValue;

                switch (fld.COLORCONVERTION)
                {
                    case "BOOL":
                        if (bool.TryParse(valStr, out valBool))
                        {
                            bool valComp = bool.Parse(fld.COLORCONDITION);
                            return (valBool == valComp);
                        }
                        break;
                    case "DATE":
                        DateTime valCompDate = DateTime.MinValue;
                        if (DateTime.TryParse(valStr, out valDate))
                        {
                            switch (fld.COLORVALUE.Split('#')[0])
                            {
                                case "DAY":
                                    valCompDate = DateTime.Now.AddDays(double.Parse(fld.COLORVALUE.Split('#')[1]));
                                    break;
                                case "MONTH":
                                    valCompDate = DateTime.Now.AddMonths(int.Parse(fld.COLORVALUE.Split('#')[1]));
                                    break;
                                case "YEAR":
                                    valCompDate = DateTime.Now.AddYears(int.Parse(fld.COLORVALUE.Split('#')[1]));
                                    break;
                            }

                            switch (fld.COLORCONDITION)
                            {
                                case "<":
                                    return (valDate < valCompDate);
                                case ">":
                                    return (valDate > valCompDate);
                                case "<>":
                                    return (valDate != valCompDate);
                                case "=":
                                    return (valDate == valCompDate);
                            }
                        }
                        break;
                    case "NUM":
                        if (decimal.TryParse(valStr, out valDec))
                        {
                            decimal valComp = decimal.Parse(fld.COLORVALUE);
                            switch (fld.COLORCONDITION)
                            {
                                case "<":
                                    return (valDec < valComp);
                                case ">":
                                    return (valDec > valComp);
                                case "<>":
                                    return (valDec != valComp);
                                case "=":
                                    return (valDec == valComp);
                            }
                        }
                        break;
                    case "STR":
                        switch (fld.COLORCONDITION)
                        {
                            case "<>":
                                return (valStr != fld.COLORVALUE);
                            case "=":
                                return (valStr == fld.COLORVALUE);
                            case "LIKE":
                                return (valStr.ToUpper().Contains(fld.COLORVALUE.ToUpper()));
                        }
                        break;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }

    public class QueryEventArgs : EventArgs
    {
        private string newValue;
        public QueryEventArgs(string newValue)
        {
            this.newValue = newValue;
        }
        public string NewQuery
        {
            get
            {
                return newValue;
            }
        }
    }
}
