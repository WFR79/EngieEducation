namespace SynapseCore.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Reflection;
    using SynapseCore.Controls;
    using SynapseCore.Database;
    using SynapseCore.Entities;
    using SynapseAdvancedControls;

    public partial class SynapseTracability : UserControl
    {
        private string logEntryTableName;
        private string logValueTableName;

        #region Custom Properties

        private bool _UseBuiltinFilters = true;
        [Category("Custom Properties"), Description("Use the Builtin Filters")]
        public bool UseBuiltinFilters
        {
            get { return _UseBuiltinFilters; }
            set
            {
                _UseBuiltinFilters = value;

                gbTracability.Left = 0;
                gbTracability.Width = this.Width;

                if (_UseBuiltinFilters)
                {
                    gbFilter.Visible = true;

                    gbTracability.Top = gbFilter.Height + 7;
                    gbTracability.Height = this.Height - (gbFilter.Height + 7);
                }
                else
                {
                    gbFilter.Visible = false;

                    gbTracability.Top = 0;
                    gbTracability.Height = this.Height;
                }

                gbFilter.Dock = DockStyle.Top;
                gbTracability.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            }
        }

        private string _LabelOfFilters = "Filters";
        [Category("Custom Properties"), Description("Label of the Filters Groupbox")]
        public string LabelOfFilters
        {
            get { return _LabelOfFilters; }
            set
            {
                _LabelOfFilters = value;

                if (_LabelOfFilters != "")
                    gbFilter.Text = _LabelOfFilters;
                else
                    gbFilter.Text = "Filters";
            }
        }

        private string _LabelOfDateFrom = "Date From";
        [Category("Custom Properties"), Description("Label of the DateFrom Label")]
        public string LabelOfDateFrom
        {
            get { return _LabelOfDateFrom; }
            set
            {
                _LabelOfDateFrom = value;

                if (_LabelOfDateFrom != "")
                    lbDateFrom.Text = _LabelOfDateFrom;
                else
                    lbDateFrom.Text = "Date From";
            }
        }

        private string _LabelOfDateTo = "Date To";
        [Category("Custom Properties"), Description("Label of the DateTo Label")]
        public string LabelOfDateTo
        {
            get { return _LabelOfDateTo; }
            set
            {
                _LabelOfDateTo = value;

                if (_LabelOfDateTo != "")
                    lbDateTo.Text = _LabelOfDateTo;
                else
                    lbDateTo.Text = "Date To";
            }
        }

        private string _LabelOfFreeText = "Free Text";
        [Category("Custom Properties"), Description("Label of the FreeText Label")]
        public string LabelOfFreeText
        {
            get { return _LabelOfFreeText; }
            set
            {
                _LabelOfFreeText = value;

                if (_LabelOfFreeText != "")
                    lbFreeText.Text = _LabelOfFreeText;
                else
                    lbFreeText.Text = "Free Text";
            }
        }

        private string _LabelOfApplyButton = "Apply";
        [Category("Custom Properties"), Description("Label of the Apply Button")]
        public string LabelOfApplyButton
        {
            get { return _LabelOfApplyButton; }
            set
            {
                _LabelOfApplyButton = value;

                if (_LabelOfApplyButton != "")
                    btApply.Text = _LabelOfApplyButton;
                else
                    btApply.Text = "Apply";
            }
        }

        private string _LabelOfResetButton = "Reset";
        [Category("Custom Properties"), Description("Label of the Reset Button")]
        public string LabelOfResetButton
        {
            get { return _LabelOfResetButton; }
            set
            {
                _LabelOfResetButton = value;

                if (_LabelOfResetButton != "")
                    btReset.Text = _LabelOfResetButton;
                else
                    btReset.Text = "Reset";
            }
        }

        private string _LabelOfTraceList = "Trace List";
        [Category("Custom Properties"), Description("Label of the Trace List Groupbox")]
        public string LabelOfTraceList
        {
            get { return _LabelOfTraceList; }
            set
            {
                _LabelOfTraceList = value;

                if (_LabelOfTraceList != "")
                    gbTracability.Text = _LabelOfTraceList;
                else
                    gbTracability.Text = "Trace List";
            }
        }

        private string _LabelOfObjectName = "Object Name";
        [Category("Custom Properties"), Description("Label of the Object Name Column")]
        public string LabelOfObjectName
        {
            get { return _LabelOfObjectName; }
            set
            {
                _LabelOfObjectName = value;

                if (_LabelOfObjectName != "")
                {
                    lbObject.Text = _LabelOfObjectName;
                    treeLog.Columns[0].Text = _LabelOfObjectName;
                }
                else
                {
                    lbObject.Text = "Object Name";
                    treeLog.Columns[0].Text = "Object Name";
                }
            }
        }

        private string _LabelOfObjectValue = "Object Value";
        [Category("Custom Properties"), Description("Label of the Object Value Column")]
        public string LabelOfObjectValue
        {
            get { return _LabelOfObjectValue; }
            set
            {
                _LabelOfObjectValue = value;

                if (_LabelOfObjectValue != "")
                {
                    lbValue.Text = _LabelOfObjectValue;
                    treeLog.Columns[1].Text = _LabelOfObjectValue;
                }
                else
                {
                    lbValue.Text = "Object Value";
                    treeLog.Columns[1].Text = "Object Value";
                }
            }
        }

        private string _LabelOfAction = "Action";
        [Category("Custom Properties"), Description("Label of the Action Column")]
        public string LabelOfAction
        {
            get { return _LabelOfAction; }
            set
            {
                _LabelOfAction = value;

                if (_LabelOfAction != "")
                    treeLog.Columns[2].Text = _LabelOfAction;
                else
                    treeLog.Columns[2].Text = "Action";
            }
        }

        private string _LabelOfWho = "Who";
        [Category("Custom Properties"), Description("Label of the Who Column")]
        public string LabelOfWho
        {
            get { return _LabelOfWho; }
            set
            {
                _LabelOfWho = value;

                if (_LabelOfWho != "")
                    treeLog.Columns[3].Text = _LabelOfWho;
                else
                    treeLog.Columns[3].Text = "Who";
            }
        }

        private string _LabelOfWhen = "When";
        [Category("Custom Properties"), Description("Label of the When Column")]
        public string LabelOfWhen
        {
            get { return _LabelOfWhen; }
            set
            {
                _LabelOfWhen = value;

                if (_LabelOfWhen != "")
                    treeLog.Columns[4].Text = _LabelOfWhen;
                else
                    treeLog.Columns[4].Text = "When";
            }
        }

        private string _LabelOfOldValue = "Old Value";
        [Category("Custom Properties"), Description("Label of the Old Value Column")]
        public string LabelOfOldValue
        {
            get { return _LabelOfOldValue; }
            set
            {
                _LabelOfOldValue = value;

                if (_LabelOfOldValue != "")
                    treeLog.Columns[5].Text = _LabelOfOldValue;
                else
                    treeLog.Columns[5].Text = "Old Value";
            }
        }

        private string _LabelOfNewValue = "New Value";
        [Category("Custom Properties"), Description("Label of the New Value Column")]
        public string LabelOfNewValue
        {
            get { return _LabelOfNewValue; }
            set
            {
                _LabelOfNewValue = value;

                if (_LabelOfNewValue != "")
                    treeLog.Columns[6].Text = _LabelOfNewValue;
                else
                    treeLog.Columns[6].Text = "New Value";
            }
        }

        private string _LabelOfExpand = "Expand All";
        [Category("Custom Properties"), Description("Label of the Expand Button")]
        public string LabelOfExpand
        {
            get { return _LabelOfExpand; }
            set
            {
                _LabelOfExpand = value;

                if (_LabelOfExpand != "")
                    tsbExpand.Text = _LabelOfExpand;
                else
                    tsbExpand.Text = "Expand All";
            }
        }

        private string _LabelOfCollapse = "Collapse All";
        [Category("Custom Properties"), Description("Label of the Collapse Button")]
        public string LabelOfCollapse
        {
            get { return _LabelOfCollapse; }
            set
            {
                _LabelOfCollapse = value;

                if (_LabelOfCollapse != "")
                    tsbCollapse.Text = _LabelOfCollapse;
                else
                    tsbCollapse.Text = "Collapse All";
            }
        }

        private string _LabelOfPrint = "Print";
        [Category("Custom Properties"), Description("Label of the Print Button")]
        public string LabelOfPrint
        {
            get { return _LabelOfPrint; }
            set
            {
                _LabelOfPrint = value;

                if (_LabelOfPrint != "")
                    tsbPrint.Text = _LabelOfPrint;
                else
                    tsbPrint.Text = "Print";
            }
        }

        private string _EmptyMessage = "";
        [Category("Custom Properties"), Description("Empty Message")]
        public string EmptyMessage
        {
            get { return _EmptyMessage; }
            set { _EmptyMessage = value; }
        }

        [Browsable(false)]
        private string _AssemblyName = "";
        [Category("Custom Properties"), Description("Name of the Assembly (default is Current Assembly)")]
        public string AssemblyName
        {
            get { return _AssemblyName; }
            set { _AssemblyName = value; }
        }
        #endregion

        public SynapseTracability()
        {
            InitializeComponent();

            gbTracability.Left = 0;
            gbTracability.Width = this.Width;

            if (_UseBuiltinFilters)
            {
                gbFilter.Visible = true;

                gbTracability.Top = gbFilter.Height + 7;
                gbTracability.Height = this.Height - (gbFilter.Height + 7);
            }
            else
            {
                gbFilter.Visible = false;

                gbTracability.Top = 0;
                gbTracability.Height = this.Height;
            }

            gbFilter.Dock = DockStyle.Top;
            gbTracability.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            gbFilter.Text = _LabelOfFilters;
            lbDateFrom.Text = _LabelOfDateFrom;
            lbDateTo.Text = _LabelOfDateTo;
            lbFreeText.Text = _LabelOfFreeText;
            lbObject.Text = _LabelOfObjectName;
            lbValue.Text = _LabelOfObjectValue;
            btApply.Text = _LabelOfApplyButton;
            btReset.Text = _LabelOfResetButton;
            gbTracability.Text = _LabelOfTraceList;
            treeLog.Columns[0].Text = _LabelOfObjectName;
            treeLog.Columns[1].Text = _LabelOfObjectValue;
            treeLog.Columns[2].Text = _LabelOfAction;
            treeLog.Columns[3].Text = _LabelOfWho;
            treeLog.Columns[4].Text = _LabelOfWhen;
            treeLog.Columns[5].Text = _LabelOfOldValue;
            treeLog.Columns[6].Text = _LabelOfNewValue;
            tsbExpand.Text = _LabelOfExpand;
            tsbCollapse.Text = _LabelOfCollapse;
            tsbPrint.Text = _LabelOfPrint;

            treeLog.EmptyListMsg = "";

            #region Aspect Getters
            colAction.AspectToStringConverter = delegate(object x)
            {
                if (x is string && !x.ToString().Contains("is not a parameter-less method, property or field"))
                    switch ((String)x)
                    {
                        case "INSERT":
                            return SynapseForm.GetLabel("global.Create");
                        case "MODIFY":
                            return SynapseForm.GetLabel("global.Edit");
                        case "DELETE":
                            return SynapseForm.GetLabel("global.Delete");
                        default:
                            return (String)x;
                    }
                else
                    return string.Empty;
            };

            colWho.AspectToStringConverter = delegate(object x)
            {
                if (x is string && !x.ToString().Contains("is not a parameter-less method, property or field"))
                    return x.ToString();
                else
                    return string.Empty;
            };

            colWhen.AspectToStringConverter = delegate(object x)
            {
                if (x is string && !x.ToString().Contains("is not a parameter-less method, property or field"))
                    if (x is DateTime)
                        return ((DateTime)x).ToString("dd/MM/yyyy HH:mm:ss");
                    else
                        return string.Empty;
                else
                    if (x is DateTime)
                        return ((DateTime)x).ToString("dd/MM/yyyy HH:mm:ss");
                    else
                        return string.Empty;
            };

            colObjectName.ImageGetter = delegate(object x)
            {
                if (x is LogEntry)
                {
                    LogEntry _logEntry = (LogEntry)x;
                    switch (_logEntry.ACTION_CODE)
                    {
                        case "INSERT":
                            return "new";
                        case "MODIFY":
                            return "edit";
                        case "DELETE":
                            return "delete";
                    }
                    return "";
                }

                return "";
            };

            colObjectName.AspectToStringConverter = delegate(object x)
            {
                if (x is string && !x.ToString().Contains("is not a parameter-less method, property or field"))
                    return SynapseForm.GetLabel(((SynapseModule)SynapseForm.FormUser.Modules.Where(m => m.ID == SynapseForm.FormUser.CurrentModuleID).FirstOrDefault()).TECHNICALNAME + "_" + x.ToString());
                else
                    return string.Empty;
            };

            colObjectValue.AspectToStringConverter = delegate(object x)
            {
                if (x is string && !x.ToString().Contains("is not a parameter-less method, property or field"))
                    return x.ToString();
                else
                    return string.Empty;
            };


            colOld.AspectToStringConverter = delegate(object x)
            {
                if (x is string && !x.ToString().Contains("is not a parameter-less method, property or field"))
                    return x.ToString();
                else
                    return string.Empty;
            };

            colNew.AspectToStringConverter = delegate(object x)
            {
                if (x is string && !x.ToString().Contains("is not a parameter-less method, property or field"))
                    return x.ToString();
                else
                    return string.Empty;
            };

            treeLog.CanExpandGetter = delegate(object x)
            {
                if (x is LogEntry)
                {
                    return true;
                }
                else
                    return false;
            };

            treeLog.ChildrenGetter = delegate(object x)
            {
                LogEntry _logEntry = (LogEntry)x;
                IList<LogValue> _logValue = LogValue.LoadFromQuery("SELECT * FROM " + logValueTableName + " WHERE " + logValueTableName + ".FK_LOGENTRY=" + _logEntry.ID + " ORDER BY ID");

                return _logValue;
            };
            #endregion
        }

        private void SynapseTracability_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                _AssemblyName = Assembly.GetEntryAssembly().GetName().Name;

                logEntryTableName = "LOGENTRY_" + _AssemblyName;
                logValueTableName = "LOGVALUE_" + _AssemblyName;

                if (_UseBuiltinFilters)
                {
                    IList<LogEntry> _objects = LogEntry.LoadFromQuery("SELECT DISTINCT OBJECT_NAME FROM " + logEntryTableName);
                    cbObject.Items.Add(new logObject("", ""));
                    foreach (LogEntry _le in _objects)
                    {
                        cbObject.Items.Add((new logObject(SynapseForm.GetLabel(((SynapseModule)SynapseForm.FormUser.Modules.Where(m => m.ID == SynapseForm.FormUser.CurrentModuleID).FirstOrDefault()).TECHNICALNAME + "_" + _le.OBJECT_NAME), _le.OBJECT_NAME)));
                    }

                    resetFilters();
                }
            }
        }

        public void showTrace(string _where = "")
        {
            treeLog.EmptyListMsg = _EmptyMessage;

            string _query = "SELECT DISTINCT " + logEntryTableName + ".* FROM " + logEntryTableName + " INNER JOIN " + logValueTableName + " ON " + logValueTableName + ".FK_LOGENTRY=" + logEntryTableName + ".ID";
            if (_where != "")
                _where = " WHERE " + _where;

            IList<LogEntry> _logEntries = LogEntry.LoadFromQuery(_query + _where + " ORDER BY " + logEntryTableName + ".ID");
            treeLog.SetObjects(_logEntries);
        }

        public void resetTrace()
        {
            treeLog.EmptyListMsg = "";
            treeLog.SetObjects(null);
        }

        private void tsbExpand_Click(object sender, EventArgs e)
        {
            treeLog.ExpandAll();
        }

        private void tsbCollapse_Click(object sender, EventArgs e)
        {
            treeLog.CollapseAll();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            ListViewPrinter lvp = new ListViewPrinter();
            lvp.ListView = treeLog;
            lvp.Header = treeLog.AccessibleName;
            lvp.Footer = "By Synapse a generation suite";

            lvp.IsShrinkToFit = true;

            lvp.PrintWithDialog();
        }

        private void treeLog_DoubleClick(object sender, EventArgs e)
        {
            if (treeLog.SelectedObject is LogEntry)
                if (treeLog.IsExpanded(treeLog.SelectedObject))
                    treeLog.Collapse(treeLog.SelectedObject);
                else
                    treeLog.Expand(treeLog.SelectedObject);
        }

        private void resetFilters()
        {
            treeLog.EmptyListMsg = "";

            dtFrom.MaxDate = DateTime.Now.Date;
            dtFrom.Value = DateTime.Now.AddMonths(-1).Date;
            dtFrom.CustomFormat = " ";

            dtTo.MaxDate = DateTime.Now.Date;
            dtTo.Value = DateTime.Now.Date;
            dtTo.CustomFormat = " ";

            if (cbObject.Items.Count > 0)
                cbObject.SelectedIndex = 0;

            cbValue.Items.Clear();

            txFreeText.Text = "";
        }

        private void fillTrace()
        {
            treeLog.EmptyListMsg = _EmptyMessage;

            string _query = "SELECT DISTINCT " + logEntryTableName + ".* FROM " + logEntryTableName + " INNER JOIN " + logValueTableName + " ON " + logValueTableName + ".FK_LOGENTRY=" + logEntryTableName + ".ID";
            string _where = "";

            if (dtFrom.CustomFormat != " ")
            {
                if (_where != "")
                    _where += " AND ";

                _where += "TIMESTAMP >= CONVERT(DATETIME, '" + dtFrom.Value.Date + "', 103)";
            }

            if (dtTo.CustomFormat != " ")
            {
                if (_where != "")
                    _where += " AND ";

                _where += "TIMESTAMP < CONVERT(DATETIME, '" + dtTo.Value.Date.AddDays(1) + "', 103) ";
            }

            if (cbObject.SelectedIndex > 0)
            {
                if (_where != "")
                    _where += " AND ";

                _where += "OBJECT_NAME='" + ((logObject)cbObject.SelectedItem).Value + "'";
            }

            if (cbValue.SelectedIndex > 0)
            {
                if (_where != "")
                    _where += " AND ";

                _where += "OBJECT_VALUE='" + ((logObject)cbValue.SelectedItem).Value + "'";
            }

            if (txFreeText.Text != "")
            {
                if (_where != "")
                    _where += " AND ";

                _where += "(OBJECT_VALUE LIKE '%" + txFreeText.Text + "%' OR OLD_VALUE LIKE '%" + txFreeText.Text + "%' OR NEW_VALUE LIKE '%" + txFreeText.Text + "%')";
            }

            showTrace(_where);
        }

        private void Date_Format(object sender, EventArgs e)
        {
            DateTimePicker dt = (DateTimePicker)sender;

            if (dt.CustomFormat == " ")
            {
                dt.CustomFormat = "dd/MM/yyyy";
                if (dt.Name == "dtFrom")
                    dtTo.CustomFormat = "dd/MM/yyyy";
            }
        }

        private void Date_KeyDown(object sender, KeyEventArgs e)
        {
            DateTimePicker dt = (DateTimePicker)sender;

            if (e.KeyCode != Keys.Delete)
            {
                if (dt.CustomFormat == " ")
                {
                    dt.CustomFormat = "dd/MM/yyyy";
                    if (dt.Name == "dtFrom")
                        dtTo.CustomFormat = "dd/MM/yyyy";
                }
            }
            else
            {
                dt.CustomFormat = " ";
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            resetFilters();
            resetTrace();
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            fillTrace();
        }

        private void cbObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbObject.SelectedIndex > 0)
            {
                cbValue.Items.Clear();
                cbValue.Items.Add(new logObject("", ""));

                IList<LogEntry> _values = LogEntry.LoadFromQuery("SELECT DISTINCT OBJECT_VALUE FROM " + logEntryTableName + " WHERE OBJECT_NAME='" + ((logObject)cbObject.SelectedItem).Value + "'");
                foreach (LogEntry _le in _values)
                {
                    cbValue.Items.Add((new logObject(_le.OBJECT_VALUE, _le.OBJECT_VALUE)));
                }
            }
            else
                cbValue.Items.Clear();
        }

        private void SynapseTracability_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillTrace();
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                resetFilters();
                resetTrace();
                return;
            }
        }

        private class logObject
        {
            private string _value;
            private string _name;

            public string Value
            {
                get { return _value; }
                set { _value = value; }
            }
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public logObject(string name, string value)
            {
                _name = name;
                _value = value;
            }
            public override string ToString()
            {
                return _name;
            }
        }
    }
}
