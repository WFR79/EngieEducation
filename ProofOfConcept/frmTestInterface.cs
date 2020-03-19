using System;
using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseCore.Entities;
using SynapseCore.Database;
using SynapseAdvancedControls;
using System.Diagnostics;
namespace ProofOfConcept
{
    public partial class frmTestInterface : SynapseCore.Controls.SynapseForm
    {
        SynapseInterface selectedInterface = new SynapseInterface();
        RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"CLSID\\{3F63C36E-51A3-11D2-BB7D-00C04FA30080}\InprocServer32");
        RegistryKey key2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\CLSID\{3F63C36E-51A3-11D2-BB7D-00C04FA30080}\InprocServer32");

        public frmTestInterface()
        {
            InitializeComponent();
        }

        public override void initForm(SynapseCore.Security.Tools.SecureAndTranslateMode Mode)
        {
            base.initForm(SynapseCore.Security.Tools.SecureAndTranslateMode.Secure);

           

            var Interfaces = SynapseInterface.Load();
            cbInterface.Items.Clear();

            foreach (SynapseInterface Interf in Interfaces.OrderBy(x => x.FriendlyName.ToString()).ToList())
            {
                cbInterface.Items.Add(Interf);
            }

            cbInterface.DisplayMember = "FriendlyName";
            //cb_Module.DisplayMember = "TECHNICALNAME";
            cbInterface.ValueMember = "ID";
            cbInterface.SelectedItem = cbInterface.Items[0];

            txOracleHome.Text = Environment.GetEnvironmentVariable("ORACLE_HOME");
            txPath.Text = Environment.GetEnvironmentVariable("PATH");
            txRegistry.Text = key.GetValue("").ToString();

            //string val = key.GetValue("").ToString();
        }

        private void cbInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbInterface.SelectedItem.GetType() == typeof(SynapseInterface))
            {
                if (SynapseCore.Database.DBFunction.ConnectionManager.ActiveConnections > 0)
                {
                    Hashtable connToRemove= new Hashtable();
                    foreach (DBConnection conn in SynapseCore.Database.DBFunction.ConnectionManager.Connections.Values)
                    {
                        if (conn.Name != "Default")
                        {
                            conn.Close();
                            connToRemove.Add(conn.Name, conn.Connection);
                        }
                    }
                    foreach (string conn in connToRemove.Keys)
                    {
                        SynapseCore.Database.DBFunction.ConnectionManager.Connections.Remove(conn);
                    }
                }

                selectedInterface = (SynapseInterface)cbInterface.SelectedItem;
                txType.Text = selectedInterface.DBTYPE;
                txConnectionString.Text = selectedInterface.CONNECTIONSTRING;
                txQuery.Text = selectedInterface.TABLESQUERY;

                txMessage.Text = "";
            }
        }

        private void btExec_Click(object sender, EventArgs e)
        {
            try
            {
                txMessage.Text = "";

                olvResult.AllColumns.RemoveAll(x => x.Text.Length > 0);
                olvResult.Columns.Clear();
                olvResult.Items.Clear();
                olvResult.ShowGroups = false;

                DataTable DT = new DataTable();
                DT = SynapseCore.Database.DBFunction.GetTableFromQuery(txQuery.Text, selectedInterface.TECHNICALNAME);

                foreach (DataColumn col in DT.Columns)
                {
                    OLVColumn aNewColumn = new OLVColumn();
                    aNewColumn.Text = col.ColumnName;
                    aNewColumn.Width = 150;
                    aNewColumn.AspectGetter = delegate(object x)
                    {
                        if (x is DataRow)
                        {
                            if (olvResult.AllColumns.IndexOf(aNewColumn) < ((DataRow)x).Table.Columns.Count && olvResult.AllColumns.IndexOf(aNewColumn) > -1)
                            {
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
                }
                olvResult.RebuildColumns();
                olvResult.SetObjects(DT.Rows);

                txMessage.Text = DateTime.Now.ToString("HH:mm:ss") + " - Ok";

            }
            catch (Exception ex)
            {
                txMessage.Text = DateTime.Now.ToString("HH:mm:ss") + " - " + ex.Message;
            }
            finally
            {
                string p = "";
                foreach (ProcessModule mod in Process.GetCurrentProcess().Modules)
                {
                    if (mod.ModuleName.ToLower().Contains("ora"))
                    {
                        p += mod.ModuleName + Environment.NewLine;
                        mod.Dispose();
                    }
                }
                txProcesses.Text=p;
            }
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("ORACLE_HOME", txOracleHome.Text, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("PATH", txOracleHome.Text + "\\bin;" + Environment.GetEnvironmentVariable("PATH"), EnvironmentVariableTarget.Process);
            txPath.Text = Environment.GetEnvironmentVariable("PATH");
        }

        private void btGet_Click(object sender, EventArgs e)
        {
            txOracleHome.Text = Environment.GetEnvironmentVariable("ORACLE_HOME");
            txPath.Text = Environment.GetEnvironmentVariable("PATH");
        }

        private void btSetReg_Click(object sender, EventArgs e)
        {
            Registry.SetValue(key2.Name, "", txRegistry.Text, RegistryValueKind.String);
        }

        private void btGetReg_Click(object sender, EventArgs e)
        {
            txRegistry.Text = key2.GetValue("").ToString();
        }
    }
}
