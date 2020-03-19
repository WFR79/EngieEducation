using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using SynapseCore.Controls;

namespace SynapseStatistics
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            olvColumn1.AspectToStringConverter = delegate(object x)
            {
                return ((string)x).Replace("StatReport_", "");
            };

            Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "SynapseStatistics");
            for (int i = 0; i < typelist.Length; i++)
            {
                //treeListView1.Items.Add(new ListViewItem(typelist[i].Name));
                if (typelist[i].Name.StartsWith("StatReport"))
                    treeListView1.AddObject(typelist[i]);
            }
        }
        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        private void treeListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (treeListView1.SelectedObject is Type)
            {
                zedGraphControl1.GraphPane.CurveList.Clear();
                Assembly assembly = Assembly.Load(Assembly.GetExecutingAssembly().FullName);
                Type t = assembly.GetType(((Type)treeListView1.SelectedObject).FullName);
                IReport frmConta = (IReport)Activator.CreateInstance(t);
                frmConta.Generate(ref this.zedGraphControl1);
                //IReport myreport = (IReport)Activator.CreateInstance(Assembly.GetExecutingAssembly().FullName, ((Type)treeListView1.SelectedObject).FullName);
                zedGraphControl1.GraphPane.AxisChange();
                zedGraphControl1.AxisChange();
                zedGraphControl1.Refresh();
            }
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
