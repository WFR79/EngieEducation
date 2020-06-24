namespace SynapseCore.Database
{
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Linq;
    using System.IO;

    public sealed class ConnectionManager
    {
        private System.Timers.Timer flushTimer;
        private static Hashtable ConnectionCollection = new Hashtable();
        private static Hashtable TransactionCollection = new Hashtable();
        private string sErrorMsg;
        private const string SynapseApplicationRoleName = "SynapseMain";

        public ConnectionManager()
        {
            flushTimer = new System.Timers.Timer(200000);
            flushTimer.Elapsed += new System.Timers.ElapsedEventHandler(FlushTimer_Elapsed);
            flushTimer.Enabled = true;
        }

        void FlushTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (DBConnection conn in this.Connections.Values)
            {
                if ((DateTime.Now - conn.LastCheck).TotalMinutes > 5)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Check the Connection
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <returns>true when the Connection is open or opened after the call</returns>
        /// <remarks>This is where the Application Role is associated to the connection.</remarks>
        public bool CheckConnection(string ConnectionName = "Default")
        {
            if (!ConnectionCollection.ContainsKey(ConnectionName))
            {
                DBConnection NewConnection;

                if (ConnectionName == "Default")
                {
                    Config clConfig = new Config(SynapseCore.Database.DBFunction.ConnectionName);
                    NewConnection = new DBConnection(0, ConnectionName);
                    //NewConnection.ConnectionString = "server=localhost\\SQLEXPRESS; database=SYNAPSE;integrated security=True;Pooling=false;MultipleActiveResultSets=True;";
                    NewConnection.ConnectionString = "server=" + clConfig.ServerName + ";database=" + clConfig.DatabaseName + ";integrated security=True;Pooling=false;MultipleActiveResultSets=True;"; //Persist Security Info=false;Integrated Security=SSPI;
                }
                else
                {
                    SynapseCore.Entities.SynapseInterface Interface = SynapseCore.Entities.SynapseInterface.Load("WHERE TECHNICALNAME ='" + ConnectionName + "'").FirstOrDefault();
                    NewConnection = new DBConnection((ConnectionType)Interface.TYPE, ConnectionName);
                    NewConnection.ConnectionString = Interface.CONNECTIONSTRING;
                    if (Interface.ORACLE_HOME != string.Empty && Interface.ORACLE_HOME != null)
                        setEnvironmentVariables(Interface.ORACLE_HOME);
                }
                ConnectionCollection.Add(ConnectionName, NewConnection);
            }

            DBConnection connectionToCheck = (DBConnection)ConnectionCollection[ConnectionName];
            connectionToCheck.LastCheck = DateTime.Now;
            if (connectionToCheck.State != ConnectionState.Open)
            {
                try
                {
                    connectionToCheck.Open();
                }
                catch (InvalidOperationException ioex)
                {
                    sErrorMsg = "Invalid operation exception:" + ioex.Message;
                    return false;
                }
                catch (SqlException sex)
                {
                    sErrorMsg = "SQL exception: " + sex.Message;
                    return false;
                }
                catch (OleDbException odex)
                {
                    sErrorMsg = "OLE DB exception: " + odex.Message;
                    return false;
                }
                catch (ConfigurationErrorsException ceex)
                {
                    sErrorMsg = "Configuration errors exception: " + ceex.Message;
                    return false;
                }

                // Switch to Application Role just after "Open" IF Connection Name == "Default"
                if (ConnectionName == "Default")
                {
                    try
                    {
                        // TODO: Uncomment following line to implement Application Role switching
                        ((System.Data.SqlClient.SqlConnection)((DBConnection)ConnectionCollection["Default"]).Connection).SwitchToApplicationRole(SynapseApplicationRoleName);
                    }
                    catch (SynapseCoreException scex)
                    {
                        sErrorMsg = scex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        sErrorMsg = ex.Message;
                        return false;
                    
                    }
                }
            }
            if (connectionToCheck.State != ConnectionState.Open)
                return false;
            else
                return true;
        }

        private void setEnvironmentVariables(string orapath)
        {
            string[] OraclePath = orapath.Split(';');

            foreach (string path in OraclePath)
            {
                if (Directory.Exists(path))
                {
                    Environment.SetEnvironmentVariable("ORACLE_HOME", path);
                    Environment.SetEnvironmentVariable("PATH", path + "\\bin;" + Environment.GetEnvironmentVariable("PATH"));
                    return;
                }
            }
        }

        //-----------------------------------------------
        // return the Connection
        //-----------------------------------------------
        public Hashtable Connections
        {
            get { return ConnectionManager.ConnectionCollection; }
        }
        public int ActiveConnections
        {
            get { return (from c in Connections.Values.Cast<DBConnection>() where c.State == ConnectionState.Open select c).Count(); }
        }
        //----------------------------
        // Error of Connection
        //----------------------------
        public string errorMsg
        {
            get { return sErrorMsg; }
        }
        //----------------------------
        // Start a transaction
        //----------------------------
        public void startTransaction(string ConnectionName = "Default")
        {
            if (ConnectionCollection.ContainsKey(ConnectionName))
                ((DBConnection)ConnectionCollection[ConnectionName]).BeginTransaction();
        }
        //-------------------------
        // Commit of a transaction
        //-------------------------
        public void commitTransaction(string ConnectionName = "Default")
        {
            if (ConnectionCollection.ContainsKey(ConnectionName))
                ((DBConnection)ConnectionCollection[ConnectionName]).Transaction.Commit();
        }
        //---------------------------
        // Rollback of a transaction
        //---------------------------
        public void rollbackTransaction(string ConnectionName = "Default")
        {
            if (ConnectionCollection.ContainsKey(ConnectionName))
                ((DBConnection)ConnectionCollection[ConnectionName]).Transaction.Rollback();
        }
    }
}