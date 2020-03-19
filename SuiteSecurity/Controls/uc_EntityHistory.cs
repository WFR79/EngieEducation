namespace SynapseCore.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using SynapseCore.Entities;

    public partial class uc_EntityHistory : UserControl
    {
        IList<LogEntry> Entries;
        public uc_EntityHistory()
        {
            InitializeComponent();
        }

        private void uc_EntityHistory_Load(object sender, EventArgs e)
        {
            col_object.AspectGetter = delegate(object x)
            {
                if (x is HistoryTreeviewL2)
                    return ((HistoryTreeviewL2)x).ObjectString;
                if (x is string)
                    return x.ToString();
                else return "";
            };
            col_Field.AspectGetter = delegate(object x)
            {
                if (!(x is LogValue))
                {
                    return "";
                }
                else return ((LogValue)x).FIELD;
            };
            col_OldValue.AspectGetter = delegate(object x)
            {
                if (!(x is LogValue))
                {
                    return "";
                }
                else return ((LogValue)x).OLD_VALUE;
            };
            col_NewValue.AspectGetter = delegate(object x)
            {
                if (!(x is LogValue))
                {
                    return "";
                }
                else return ((LogValue)x).NEW_VALUE;
            };
            treeListView1.CanExpandGetter = delegate(object x)
            {
                if (x is HistoryTreeviewL2)
                    return true;
                if (x is string)
                    return true;
                else
                    return false;
            };
            treeListView1.ChildrenGetter = delegate(object x)
            {
                if (x is HistoryTreeviewL2)
                    return LogValue.Load("where FK_LOGENTRY = " + ((HistoryTreeviewL2)x).ID);
                if (x is string)
                    return from E in Entries where E.OBJECT_NAME == x.ToString() select new HistoryTreeviewL2(E);
                else
                    return null;
            };

            LogEntry.TableName = "LogEntry_" + Assembly.GetEntryAssembly().GetName().Name;
            LogValue.TableName = "LogValue_" + Assembly.GetEntryAssembly().GetName().Name;

            Entries = LogEntry.Load();

            treeListView1.SetObjects((from E in Entries select E.OBJECT_NAME).Distinct());
        }

        private class HistoryTreeviewL2
        {
            private LogEntry _Entry;
            public HistoryTreeviewL2(LogEntry Entry)
            {
                _Entry = Entry;
            }
            public string ObjectString
            {
                get { return _Entry.TIMESTAMP.ToShortDateString() + " - " + _Entry.USERID + " - " + _Entry.OBJECT_VALUE; }
            }
            public Int64 ID
            {
                get { return _Entry.ID; }
            }
        }
    }
}
