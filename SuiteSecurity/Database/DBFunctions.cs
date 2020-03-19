using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using SynapseCore.Controls;
using SynapseCore.Entities;

namespace SynapseCore.Database
{
    public static class DBFunction
    {
        public static string ConnectionName = "Default";
        public static Color FormBackColor = SystemColors.Control;
        private static ConnectionManager DBConn = new ConnectionManager();
        private const string SqlParameterNamePrefix = "@";
        private const int SqlStringParameterMinimumSize = 50;

        public static ConnectionManager ConnectionManager
        {
            get { return DBFunction.DBConn; }
            set { DBFunction.DBConn = value; }
        }

        public static string doubleQuote(string str)
        {
            return str.Replace("'", "''");
        }

        public static void setFieldValue(ref object Variable, string Field, System.Data.SqlClient.SqlDataReader Reader)
        {
            if (!Reader.IsDBNull(Reader.GetOrdinal(Field)))
            {
                Variable = Reader.GetValue(Reader.GetOrdinal(Field));
                if (Variable.GetType().Name == "String")
                {
                    Variable = Variable.ToString().Trim();
                }
                if (Variable.GetType().Name == "DateTime")
                {
                    Variable = Variable.ToString();
                }
            }
            else
            {
                if ((Variable != null))
                {
                    switch (Variable.GetType().Name)
                    {
                        case "Short":
                            Variable = 0;
                            break;
                        case "Double":
                            Variable = 0;
                            break;
                        case "Int64":
                            Variable = 0;
                            break;
                        case "Boolean":
                            Variable = false;
                            break;
                        case "String":
                            Variable = "";
                            break;
                        case "DateTime":
                            Variable = new System.DateTime(1, 1, 1);
                            break;
                    }
                }
                else
                {
                    Variable = "";
                }
            }
        }

        public static void StartTransaction(string ConnectionName = "Default")
        {
            DBConn.CheckConnection(ConnectionName);
            DBConn.startTransaction(ConnectionName);
        }

        public static void RollbackTransaction(string ConnectionName = "Default")
        {
            DBConn.CheckConnection(ConnectionName);
            DBConn.rollbackTransaction(ConnectionName);
        }

        public static void CommitTransaction(string ConnectionName = "Default")
        {
            DBConn.CheckConnection(ConnectionName);
            DBConn.commitTransaction(ConnectionName);
        }

        public static DataTable GetTableFromQuery(string query, string ConnectionName = "Default")
        {
            DBConn.CheckConnection(ConnectionName);
            using (DataSet DS = new DataSet())
            {
                SynapseForm.SynapseLogger.Debug(query);
                switch (((DBConnection)DBConn.Connections[ConnectionName]).Type)
                {
                    case ConnectionType.MsSql:
                        using (SqlDataAdapter SqlDA = new SqlDataAdapter(query, (SqlConnection)((DBConnection)DBConn.Connections[ConnectionName]).Connection))
                        {
                            if (((DBConnection)DBConn.Connections[ConnectionName]).Transaction != null && ((DBConnection)DBConn.Connections[ConnectionName]).Transaction.Connection != null)
                                SqlDA.SelectCommand.Transaction = (SqlTransaction)((DBConnection)DBConn.Connections[ConnectionName]).Transaction;
                            SqlDA.Fill(DS, "table");
                        }
                        break;
                    case ConnectionType.OleDB:
                        using (OleDbDataAdapter SqlDA = new OleDbDataAdapter(query, (OleDbConnection)((DBConnection)DBConn.Connections[ConnectionName]).Connection))
                        {
                            if (((DBConnection)DBConn.Connections[ConnectionName]).Transaction != null && ((DBConnection)DBConn.Connections[ConnectionName]).Transaction.Connection != null)
                                SqlDA.SelectCommand.Transaction = (OleDbTransaction)((DBConnection)DBConn.Connections[ConnectionName]).Transaction;
                            SqlDA.Fill(DS, "table");
                        }
                        break;
                }

                return DS.Tables["table"];
            }
        }
        /// <summary>
        /// Return a DataTable from the select statement provided.
        /// The statement includes parameters of which the values and types are provided in the additional parameters.
        /// </summary>
        /// <param name="parameterizedQuery"></param>
        /// <param name="ConnectionName"></param>
        /// <param name="orderedParameterTypes"></param>
        /// <param name="parameterValues"></param>
        /// <returns>DataTable</returns>
        /// <remarks>If the underlying connection type is OleDb then the order of parameters in the query *must* match the index numbers. It is not needed for MsSql.</remarks>
        /// <see cref="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.prepare(v=vs.110).aspx"/>
        /// <see cref="http://msdn.microsoft.com/en-us/library/system.data.oledb.oledbcommand.prepare(v=vs.110).aspx"/>
        public static DataTable GetTableFromParameterizedQuery(string parameterizedQuery, string ConnectionName, string[] orderedParameterTypes, object[] parameterValues)
        {
            // Validate method arguments
            if (string.IsNullOrEmpty(parameterizedQuery))
            {
                throw new ArgumentNullException("parameterizedQuery");
            }
            if (orderedParameterTypes == null || orderedParameterTypes.Length == 0)
            {
                throw new ArgumentNullException("orderedParameterTypes");
            }
            if (parameterValues == null || parameterValues.Length == 0)
            {
                throw new ArgumentNullException("parameterValues");
            }
            if (orderedParameterTypes.Length != parameterValues.Length)
            {
                throw new ArgumentException("orderedParameterTypes.Length != parameterValues.Length");
            }

            // Old Code
            DBConn.CheckConnection(ConnectionName);
            using (DataSet DS = new DataSet())
            {
                SynapseForm.SynapseLogger.Debug(parameterizedQuery);
                switch (((DBConnection)DBConn.Connections[ConnectionName]).Type)
                {
                    case ConnectionType.MsSql:
                        using (SqlDataAdapter SqlDA = new SqlDataAdapter(parameterizedQuery, (SqlConnection)((DBConnection)DBConn.Connections[ConnectionName]).Connection))
                        {
                            // Add parameter types & values
                            bool prefixParameterName = true;
                            SqlDA.SelectCommand.Parameters.AddQueryParameters<SqlParameter>(orderedParameterTypes, parameterValues, prefixParameterName);

                            SqlDA.SelectCommand.Prepare();

                            if (((DBConnection)DBConn.Connections[ConnectionName]).Transaction != null && ((DBConnection)DBConn.Connections[ConnectionName]).Transaction.Connection != null)
                                SqlDA.SelectCommand.Transaction = (SqlTransaction)((DBConnection)DBConn.Connections[ConnectionName]).Transaction;
                            SqlDA.Fill(DS, "table");
                        }
                        break;
                    case ConnectionType.OleDB:

                        bool doNotPrefixParameterName = false;
                        parameterizedQuery = parameterizedQuery.ReplaceParametersByQuestionMarks(orderedParameterTypes);

                        using (OleDbDataAdapter SqlDA = new OleDbDataAdapter(parameterizedQuery, (OleDbConnection)((DBConnection)DBConn.Connections[ConnectionName]).Connection))
                        {
                            SqlDA.SelectCommand.Parameters.AddQueryParameters<OleDbParameter>(orderedParameterTypes, parameterValues, doNotPrefixParameterName);

                            SqlDA.SelectCommand.Prepare();

                            if (((DBConnection)DBConn.Connections[ConnectionName]).Transaction != null && ((DBConnection)DBConn.Connections[ConnectionName]).Transaction.Connection != null)
                                SqlDA.SelectCommand.Transaction = (OleDbTransaction)((DBConnection)DBConn.Connections[ConnectionName]).Transaction;
                            SqlDA.Fill(DS, "table");
                        }
                        break;
                }
                return DS.Tables["table"];
            }
        }

        internal static string ReplaceParametersByQuestionMarks(this string parameterizedQuery, string[] orderedParameterTypes)
        {
            string result = parameterizedQuery;
            for (int index = 0; index < orderedParameterTypes.Length; index++)
            {
                result = result.Replace(string.Format("{0}{1}{2:0}", SqlParameterNamePrefix, orderedParameterTypes[index], index), "?");
            }
            return result;
        }

        /// <summary>
        /// Creates the DB Parameters in the collection based on the provided types and values. 
        /// The name of the parameter is implicit: concatenation of "type" + "index" (one digit)
        /// </summary>
        /// <param name="commandParameters"></param>
        /// <param name="orderedParameterTypes"></param>
        /// <param name="parameterValues"></param>
        /// <see cref="http://technet.microsoft.com/en-us/library/ms131092.aspx"/>
        /// <remarks>Marked as "internal" in order to make testable. Should actually be factored out but this is a helper class already...</remarks>
        internal static void AddQueryParameters<TDbParameter>(this DbParameterCollection commandParameters, string[] orderedParameterTypes, object[] parameterValues, bool prefixParameterName) where TDbParameter : DbParameter, new()
        {
            string parameterNamePrefix = prefixParameterName ? SqlParameterNamePrefix : string.Empty;

            // validate type of arguments while constructing parameters
            for (int parameterIndex = 0; parameterIndex < parameterValues.Length; parameterIndex++)
            {
                string parameterName = string.Format("{0}{1}{2:0}", parameterNamePrefix, orderedParameterTypes[parameterIndex], parameterIndex);
                string parameterType = orderedParameterTypes[parameterIndex];
                object parameterValue = parameterValues[parameterIndex];

                switch (parameterType)
                {
                    case "int":
                        Int32 intParameterValue;
                        try
                        {
                            intParameterValue = (Int32)parameterValue;
                        }
                        catch
                        {
                            throw new ArgumentException(string.Format("Expected parameter type was 'int'(Int32) and value was of type '{0}'", parameterValue.GetType()));
                        }
                        DbParameter intDbParam = (DbParameter)new TDbParameter() { DbType = DbType.Int32, Direction = ParameterDirection.Input, Size = 4 };
                        intDbParam.Value = intParameterValue;
                        intDbParam.ParameterName = parameterName;
                        commandParameters.Add(intDbParam);
                        break;

                    case "bigint":
                        Int64 bigintParameterValue;
                        try
                        {
                            bigintParameterValue = (Int64)parameterValue;
                        }
                        catch
                        {
                            throw new ArgumentException(string.Format("Expected parameter type was 'bigint'(Int64) and value was of type '{0}'", parameterValue.GetType()));
                        }
                        DbParameter bigintDbParam = (DbParameter)new TDbParameter() { DbType = DbType.Int64, Direction = ParameterDirection.Input, Size = 8 };
                        bigintDbParam.Value = bigintParameterValue;
                        bigintDbParam.ParameterName = parameterName;
                        commandParameters.Add(bigintDbParam);
                        break;

                    case "char":
                        string charArrrayParameterValue;
                        try
                        {
                            charArrrayParameterValue = (string)parameterValue;
                        }
                        catch
                        {
                            throw new ArgumentException(string.Format("Expected parameter type was 'char'(string) and value was of type '{0}'", parameterValue.GetType()));
                        }
                        DbParameter charDbParam = (DbParameter)new TDbParameter() { DbType = DbType.StringFixedLength, Direction = ParameterDirection.Input, Size = Math.Max(SqlStringParameterMinimumSize, charArrrayParameterValue.Length) };
                        charDbParam.Value = charArrrayParameterValue;
                        charDbParam.ParameterName = parameterName;
                        commandParameters.Add(charDbParam);
                        break;

                    case "nvarchar":
                        string stringParameterValue;
                        try
                        {
                            stringParameterValue = (string)parameterValue;
                        }
                        catch
                        {
                            throw new ArgumentException(string.Format("Expected parameter type was 'nvarchar'(string) and value was of type '{0}'", parameterValue.GetType()));
                        }
                        DbParameter stringDbParam = (DbParameter)new TDbParameter() { DbType = DbType.String, Direction = ParameterDirection.Input, Size = Math.Max(SqlStringParameterMinimumSize, stringParameterValue.Length) };
                        stringDbParam.Value = stringParameterValue;
                        stringDbParam.ParameterName = parameterName;
                        commandParameters.Add(stringDbParam);
                        break;

                    default:
                        throw new ArgumentException(string.Format("Unsupported parameter type '{0}'", parameterType));
                }
            }
        }

        public static void ExecuteNonQuery(string query, string ConnectionName = "Default")
        {
            DBConn.CheckConnection(ConnectionName);
            System.Data.Common.DbCommand SqlComm = null;
            switch (((DBConnection)DBConn.Connections[ConnectionName]).Type)
            {
                case ConnectionType.MsSql:
                    SqlComm = new SqlCommand(query, (SqlConnection)((DBConnection)DBConn.Connections[ConnectionName]).Connection);
                    if (((DBConnection)DBConn.Connections[ConnectionName]).Transaction != null && ((DBConnection)DBConn.Connections[ConnectionName]).Transaction.Connection != null)
                        SqlComm.Transaction = (SqlTransaction)((DBConnection)DBConn.Connections[ConnectionName]).Transaction;

                    break;
                case ConnectionType.OleDB:
                    SqlComm = new OleDbCommand(query, (OleDbConnection)((DBConnection)DBConn.Connections[ConnectionName]).Connection);
                    if (((DBConnection)DBConn.Connections[ConnectionName]).Transaction != null && ((DBConnection)DBConn.Connections[ConnectionName]).Transaction.Connection != null)
                        SqlComm.Transaction = (OleDbTransaction)((DBConnection)DBConn.Connections[ConnectionName]).Transaction;

                    break;
            }
            SynapseForm.SynapseLogger.Debug(query);
            SqlComm.ExecuteNonQuery();
        }

        public static object ExecuteScalarQuery(string query, string ConnectionName = "Default")
        {
            DBConn.CheckConnection(ConnectionName);

            System.Data.Common.DbCommand SqlComm = null;
            switch (((DBConnection)DBConn.Connections[ConnectionName]).Type)
            {
                case ConnectionType.MsSql:
                    SqlComm = new SqlCommand(query, (SqlConnection)((DBConnection)DBConn.Connections[ConnectionName]).Connection);
                    if (((DBConnection)DBConn.Connections[ConnectionName]).Transaction != null && ((DBConnection)DBConn.Connections[ConnectionName]).Transaction.Connection != null)
                        SqlComm.Transaction = (SqlTransaction)((DBConnection)DBConn.Connections[ConnectionName]).Transaction;

                    break;
                case ConnectionType.OleDB:
                    SqlComm = new OleDbCommand(query, (OleDbConnection)((DBConnection)DBConn.Connections[ConnectionName]).Connection);
                    if (((DBConnection)DBConn.Connections[ConnectionName]).Transaction != null && ((DBConnection)DBConn.Connections[ConnectionName]).Transaction.Connection != null)
                        SqlComm.Transaction = (OleDbTransaction)((DBConnection)DBConn.Connections[ConnectionName]).Transaction;

                    break;
            }
            SynapseForm.SynapseLogger.Debug(query);
            object oReturn = SqlComm.ExecuteScalar();

            return oReturn;
        }

        public static Int64 SaveEntityToDBOld(object entity, string tableName, string IDproperty, string exclusions)
        {
            IList<PropertyInfo> properties = (entity.GetType()).GetProperties();
            string fields = string.Empty;
            string values = string.Empty;
            string updates = string.Empty;
            bool update = false;
            string query = string.Empty;
            Int64 id = 0;

            foreach (PropertyInfo p in properties)
            {
                if ((p.Name != IDproperty) && (!exclusions.Contains(p.Name)))
                {
                    fields += p.Name + ",";
                    switch (p.PropertyType.ToString())
                    {
                        case "System.DateTime":
                            DateTime date = (DateTime)p.GetValue(entity, null);
                            if (date < DateTime.Parse("01/01/1753 00:00:00"))
                            {
                                values += "Null,";
                                updates += p.Name + "=Null,";
                            }
                            else
                            {
                                values += "'" + date.ToString("MM/dd/yyyy HH:mm:ss") + "',";
                                updates += p.Name + "='" + date.ToString("MM/dd/yyyy HH:mm:ss") + "',";
                            }
                            break;

                        case "System.TimeSpan":
                            TimeSpan time = (TimeSpan)p.GetValue(entity, null);
                            values += "'" + time + "',";
                            updates += p.Name + "='" + time + "',";
                            break;

                        case "System.Decimal":
                            values += p.GetValue(entity, null).ToString().Replace(',', '.') + ",";
                            updates += p.Name + "=" + p.GetValue(entity, null).ToString().Replace(',', '.') + ",";
                            break;

                        case "System.String":
                            string value = string.Empty;
                            if (p.GetValue(entity, null) != null)
                                value = doubleQuote(p.GetValue(entity, null).ToString());
                            values += "'" + value + "',";
                            updates += p.Name + "='" + value + "',";
                            break;

                        case "System.Boolean":
                            values += (((bool)p.GetValue(entity, null)) ? 1 : 0).ToString() + ",";
                            updates += p.Name + "=" + (((bool)p.GetValue(entity, null)) ? 1 : 0).ToString() + ",";
                            break;

                        case "SynapseCore.Database.LabelBag":
                            break;

                        default:
                            values += p.GetValue(entity, null) + ",";
                            updates += p.Name + "=" + p.GetValue(entity, null) + ",";
                            break;
                    }
                }
                else
                    if (p.Name == IDproperty && (Int64)p.GetValue(entity, null) != 0)
                    {
                        id = (Int64)p.GetValue(entity, null);
                        update = true;
                    }
            }
            if (update)
            {
                query = "UPDATE " + tableName + " SET " + updates.TrimEnd(',') + " WHERE " + IDproperty + "=" + id.ToString();
                DBFunction.ExecuteNonQuery(query);
                return id;
            }
            else
            {
                query = "INSERT INTO " + tableName + "(" + fields.TrimEnd(',') + ") VALUES (" + values.TrimEnd(',') + ");SELECT cast(SCOPE_IDENTITY() as bigint);";
                return (Int64)DBFunction.ExecuteScalarQuery(query);
            }
        }

        public static object SaveEntityToDB(object entity, string tableName, string IDproperty, string exclusions, string ConnectionName = "Default")
        {
            DBConn.CheckConnection(ConnectionName);
            System.Data.Common.DbCommand SqlComm = null;
            switch (((DBConnection)DBConn.Connections[ConnectionName]).Type)
            {
                case ConnectionType.MsSql:
                    SqlComm = new SqlCommand();
                    SqlComm.Connection = (SqlConnection)((DBConnection)DBConn.Connections[ConnectionName]).Connection;

                    if (((DBConnection)DBConn.Connections[ConnectionName]).Transaction != null && ((DBConnection)DBConn.Connections[ConnectionName]).Transaction.Connection != null)
                        SqlComm.Transaction = (SqlTransaction)((DBConnection)DBConn.Connections[ConnectionName]).Transaction;

                    break;
                case ConnectionType.OleDB:
                    SqlComm = new OleDbCommand();
                    SqlComm.Connection = (OleDbConnection)((DBConnection)DBConn.Connections[ConnectionName]).Connection;

                    if (((DBConnection)DBConn.Connections[ConnectionName]).Transaction != null && ((DBConnection)DBConn.Connections[ConnectionName]).Transaction.Connection != null)
                        SqlComm.Transaction = (OleDbTransaction)((DBConnection)DBConn.Connections[ConnectionName]).Transaction;

                    break;
            }
            
            IList<PropertyInfo> properties = (entity.GetType()).GetProperties();
            string fields = string.Empty;
            string ValuesParameters = string.Empty;
            string UpdatesParameters = string.Empty;
            bool update = false;
            string query = string.Empty;
            Int64 id = 0;

            foreach (PropertyInfo p in properties)
            {
                if ((p.Name != IDproperty) && (!mustBeExcluded(exclusions, p.Name)))
                {
                    fields += p.Name + ",";
                    switch (p.PropertyType.ToString())
                    {
                        case "System.DateTime":
                            DateTime date = (DateTime)p.GetValue(entity, null);
                            if (date < DateTime.Parse("01/01/1753 00:00:00"))
                            {
                                ValuesParameters += "Null,";
                                UpdatesParameters += p.Name + "=Null,";
                            }
                            else
                            {
                                switch (((DBConnection)DBConn.Connections[ConnectionName]).Type)
                                {
                                    case ConnectionType.MsSql:
                                        ValuesParameters += "@" + p.Name + ",";
                                        UpdatesParameters += p.Name + "=@" + p.Name + ",";
                                        ((SqlCommand)SqlComm).Parameters.AddWithValue("@" + p.Name, p.GetValue(entity, null));
                                        break;

                                    case ConnectionType.OleDB:
                                        ValuesParameters += "?,";
                                        UpdatesParameters += p.Name + "= ?,";
                                        ((OleDbCommand)SqlComm).Parameters.AddWithValue("@" + p.Name, p.GetValue(entity, null));
                                        break;
                                }
                            }
                            break;

                        case "SynapseCore.Database.LabelBag":
                            break;

                        default:
                            switch (((DBConnection)DBConn.Connections[ConnectionName]).Type)
                            {
                                case ConnectionType.MsSql:
                                    ValuesParameters += "@" + p.Name + ",";
                                    UpdatesParameters += p.Name + "=@" + p.Name + ",";
                                    if (p.GetValue(entity, null) != null)
                                        ((SqlCommand)SqlComm).Parameters.AddWithValue("@" + p.Name, p.GetValue(entity, null));
                                    else
                                        ((SqlCommand)SqlComm).Parameters.AddWithValue("@" + p.Name, DBNull.Value);
                                    break;
                                case ConnectionType.OleDB:
                                    ValuesParameters += "?,";
                                    UpdatesParameters += p.Name + "= ?,";
                                    if (p.GetValue(entity, null) != null)
                                        ((OleDbCommand)SqlComm).Parameters.AddWithValue("@" + p.Name, p.GetValue(entity, null));
                                    else
                                        ((OleDbCommand)SqlComm).Parameters.AddWithValue("@" + p.Name, DBNull.Value);
                                    break;
                            }
                            break;
                    }
                }
                else
                    if (p.Name == IDproperty)
                    {
                        switch (p.PropertyType.FullName)
                        {
                            case "System.Decimal":
                                if ((Decimal)p.GetValue(entity, null) != 0)
                                {
                                    id = Convert.ToInt64(p.GetValue(entity, null));
                                    update = true;
                                }
                                break;
                            case "System.Int64":
                                if ((Int64)p.GetValue(entity, null) != 0)
                                {
                                    id = (Int64)p.GetValue(entity, null);
                                    update = true;
                                }
                                break;
                        }
                    }
            }

            if (update)
            {
                query = "UPDATE " + tableName + " SET " + UpdatesParameters.TrimEnd(',') + " WHERE " + IDproperty + "=" + id.ToString();
                SqlComm.CommandText = query;
                SynapseForm.SynapseLogger.Debug(query);

                SqlComm.ExecuteNonQuery();
                return id;
            }
            else
            {
                switch (((DBConnection)DBConn.Connections[ConnectionName]).Type)
                {
                    case ConnectionType.MsSql:
                        query = "INSERT INTO " + tableName + "(" + fields.TrimEnd(',') + ") VALUES (" + ValuesParameters.TrimEnd(',') + ");SELECT cast(SCOPE_IDENTITY() as bigint);";
                        SqlComm.CommandText = query;
                        SynapseForm.SynapseLogger.Debug(query);
                        return SqlComm.ExecuteScalar();
                        break;

                    case ConnectionType.OleDB:
                        query = "INSERT INTO " + tableName + "(" + fields.TrimEnd(',') + ") VALUES (" + ValuesParameters.TrimEnd(',') + ")";
                        SqlComm.CommandText = query;
                        SynapseForm.SynapseLogger.Debug(query);
                        SqlComm.ExecuteNonQuery();
                        query = "SELECT MAX(" + IDproperty + ") FROM " + tableName + " WHERE " + fields.Replace(",", "=?,").TrimEnd(',').Replace(",", " AND ");
                        SqlComm.CommandText = query;
                        object returnedid = SqlComm.ExecuteScalar();
                        return returnedid;
                        break;

                    default:
                        return 0;
                        break;
                }
            }
        }

        public static bool mustBeExcluded(string exclusions, string name)
        {
            string[] toexclude = exclusions.Replace("||", "|").Split('|');
            foreach (string exp in toexclude)
            {
                if (name == exp)
                    return true;
            }
            return false;
        }

        public static void DeleteEntityFromDB(string tableName, string IDproperty, object entity, string ConnectionName = "Default")
        {
            PropertyInfo pi = entity.GetType().GetProperty(IDproperty);
            if (pi != null)
            {
                string query = "DELETE FROM " + tableName + " WHERE " + IDproperty + "=" + pi.GetValue(entity, null).ToString();
                DBFunction.ExecuteNonQuery(query, ConnectionName);
                SynapseForm.SynapseLogger.Debug(string.Format("Deleting from {0} with id {1}", tableName, pi.GetValue(entity, null).ToString()));
           
            }
        }
    }
}