/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 23-05-2012
 * Time: 09:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using SynapseCore.Controls;
using SynapseCore.Database;

namespace SynapseCore.Entities
{
    /// <summary>
    /// Description of SynapseEntity.
    /// </summary>
    [Serializable]
    public abstract class SynapseEntity<T> where T : new()
    {
        private enum LogCommand
        {
            Save,
            Delete,
            Insert,
            Modify
        };

        public static string Zquery;
        public static string ZtableName;
        public static string ZIDproperty;
        public static string ZEcludeForSave;
        private string _Hash;
        private T _initial;
        private string _LogEntryKey;
        private string _LogEntryValue;

        public string LogEntryKey
        {
            get { return _LogEntryKey; }
            set { _LogEntryKey = value; }
        }
        public string LogEntryValue
        {
            get { return _LogEntryValue; }
            set { _LogEntryValue = value; }
        }

        public void ComputeHash()
        {
            _Hash = this.GetHashPerso();
        }
        public bool IsDirty
        {
            get { return _Hash != this.GetHashPerso(); }
        }
        /// <summary>
        /// Initial entity value (you must call dump before)
        /// </summary>
        public T InitialValue
        {
            get { return _initial; }
        }

        public static T LoadByID(Int64 ID)
        {
            String ConnectionName = "Default";
            Type objectType = typeof(T);
            object[] connections = objectType.GetCustomAttributes(typeof(DBConnectionAttribute), true);

            if (connections.Length > 0)
                ConnectionName = ((DBConnectionAttribute)connections[0]).ConnectionName;

            FieldInfo query = objectType.GetField("_query", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            FieldInfo IDproperty = objectType.GetField("_IDproperty", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            return DBFunction.GetTableFromQuery(query.GetValue(null).ToString() + " WHERE " + IDproperty.GetValue(null).ToString() + " = " + ID.ToString(), ConnectionName).ToEntity<T>();
        }

        public static IList<T> Load()
        {
            return Load(string.Empty);
        }

        public static IList<T> Load(string filter)
        {
            Type objectType = typeof(T);
            FieldInfo query = objectType.GetField("_query", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            string sql = query.GetValue(null).ToString();
            if (filter != string.Empty)
                sql += " " + filter;
            return LoadFromQuery(sql);
        }

        public static IList<T> LoadFromQuery(string query, string ConnectionName = "Default")
        {
            Type objectType = typeof(T);
            object[] connections = objectType.GetCustomAttributes(typeof(DBConnectionAttribute), true);

            if (connections.Length > 0)
                ConnectionName = ((DBConnectionAttribute)connections[0]).ConnectionName;

            if (SynapseForm.SynapseLogger.IsDebugEnabled)
            {
                Stopwatch myStopWatch = new Stopwatch();
                myStopWatch.Reset();
                myStopWatch.Start();
                IList<T> ReturnList;
                ReturnList = DBFunction.GetTableFromQuery(query, ConnectionName).ToListOfEntities<T>();
                myStopWatch.Stop();
                SynapseForm.SynapseLogger.Debug(string.Format("Retreiving {0} object<{2}> in {1} milliseconds", ReturnList.Count, myStopWatch.ElapsedMilliseconds.ToString(), objectType.Name));
                return ReturnList;
            }
            else
            {
                return DBFunction.GetTableFromQuery(query, ConnectionName).ToListOfEntities<T>();
            }
        }

        private static Regex MatchParameters = new Regex("@([a-z]+)([0-9]{1})", RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// Returns a list of entities from the database.
        /// The provided query is executed. The query must include parameters in the form of "@[paramType][index]"
        /// Where:
        ///     "paramType" can be one of: "int", "bigint", "nvarchar"
        ///     "index" is a single digit integer index starting at "0"
        /// </summary>
        /// <param name="parameterizedQuery">The query including the parameters in format described in summary</param>
        /// <param name="ConnectionName">The name of the connection</param>
        /// <param name="queryParameters">The values of the parameters</param>
        /// <returns></returns>
        public static IList<T> LoadFromPreparedQuery(string parameterizedQuery, string ConnectionName, params object[] queryParameters)
        {
            // validate arguments
            if (string.IsNullOrEmpty(parameterizedQuery))
            {
                throw new ArgumentNullException("parameterizedQuery");
            }

            if (string.IsNullOrEmpty(ConnectionName))
            {
                throw new ArgumentNullException("ConnectionName");
            }

            if (queryParameters == null || queryParameters.Length == 0)
            {
                throw new ArgumentNullException("queryParameters");
            }
            foreach (var item in queryParameters)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("queryParameters");
                }
                else if (item is string && string.IsNullOrEmpty(item as string))
                {
                    throw new ArgumentNullException("queryParameters");
                }
            }

            // parse query Text
            MatchCollection matchedParameters = MatchParameters.Matches(parameterizedQuery);

            // validate number of arguments
            if (matchedParameters.Count != queryParameters.Length)
            {
                throw new ArgumentException("Number of parameters provided does not match number of parameters in query string", "queryParameters");
            }

            // Capture parameter types in the order that they are provided in queryParameters 
            string[] orderedQueryParameterTypes = new string[matchedParameters.Count];

            foreach (Match matchedParameter in matchedParameters)
            {
                string parameterType = matchedParameter.Groups[1].Value;
                int parameterIndex = int.Parse(matchedParameter.Groups[2].Value, CultureInfo.InvariantCulture);

                if (!string.IsNullOrEmpty(orderedQueryParameterTypes[parameterIndex]))
                {
                    throw new ArgumentException("The same parameter index is used multiple times. Please use a distinct index for all parameters.", "parameterizedQuery");
                }

                orderedQueryParameterTypes[parameterIndex] = parameterType.ToLower(CultureInfo.InvariantCulture);
            }

            // "Old" code
            Type objectType = typeof(T);
            object[] connections = objectType.GetCustomAttributes(typeof(DBConnectionAttribute), true);

            if (connections.Length > 0)
                ConnectionName = ((DBConnectionAttribute)connections[0]).ConnectionName;

            if (SynapseForm.SynapseLogger.IsDebugEnabled)
            {
                Stopwatch myStopWatch = new Stopwatch();
                myStopWatch.Reset();
                myStopWatch.Start();
                IList<T> ReturnList;
                ReturnList = DBFunction.GetTableFromParameterizedQuery(parameterizedQuery, ConnectionName, orderedQueryParameterTypes, queryParameters).ToListOfEntities<T>();
                myStopWatch.Stop();
                SynapseForm.SynapseLogger.Debug(string.Format("Retreiving {0} object<{2}> in {1} milliseconds", ReturnList.Count, myStopWatch.ElapsedMilliseconds.ToString(), objectType.Name));
                return ReturnList;
            }
            else
                return DBFunction.GetTableFromParameterizedQuery(parameterizedQuery, ConnectionName, orderedQueryParameterTypes, queryParameters).ToListOfEntities<T>();
        }

        public virtual void save()
        {
            save(true);
        }

        public virtual void save(bool LogMe = true)
        {
            String ConnectionName = "Default";
            Type objectType = typeof(T);
            object[] connections = objectType.GetCustomAttributes(typeof(DBConnectionAttribute), true);
            DBLoggingAttribute logging = objectType.GetCustomAttributes(typeof(DBLoggingAttribute), true).Cast<DBLoggingAttribute>().SingleOrDefault();

            if (connections.Length > 0)
                ConnectionName = ((DBConnectionAttribute)connections[0]).ConnectionName;

            FieldInfo tableName = objectType.GetField("_tableName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            FieldInfo IDproperty = objectType.GetField("_IDproperty", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            FieldInfo EcludeForSave = objectType.GetField("_EcludeForSave", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            object SavedID = DBFunction.SaveEntityToDB(this, tableName.GetValue(null).ToString(), IDproperty.GetValue(null).ToString(), EcludeForSave.GetValue(null).ToString() + "||IsDirty||LogEntryKey||LogEntryValue||InitialValue||", ConnectionName);
            PropertyInfo IDField = objectType.GetProperty(IDproperty.GetValue(null).ToString());
            if (Convert.ToInt64(IDField.GetValue(this, null)) != Convert.ToInt64(SavedID))
                IDField.SetValue(this, SavedID, null);
            if (logging != null && LogMe)
                LogModifications(logging, LogCommand.Save);
            SynapseForm.SynapseLogger.Debug(string.Format("Saving object<{0}> with id {1}",  objectType.Name,SavedID.ToString()));
                
            this.ComputeHash();
        }

        public virtual void delete()
        { 
            delete(true); 
        }

        public virtual void delete(bool LogMe = true)
        {
            String ConnectionName = "Default";
            Type objectType = typeof(T);
            object[] connections = objectType.GetCustomAttributes(typeof(DBConnectionAttribute), true);
            DBLoggingAttribute logging = objectType.GetCustomAttributes(typeof(DBLoggingAttribute), true).Cast<DBLoggingAttribute>().SingleOrDefault();

            if (connections.Length > 0)
                ConnectionName = ((DBConnectionAttribute)connections[0]).ConnectionName;

            FieldInfo tableName = objectType.GetField("_tableName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            FieldInfo IDproperty = objectType.GetField("_IDproperty", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            DBFunction.DeleteEntityFromDB(tableName.GetValue(null).ToString(), IDproperty.GetValue(null).ToString(), this, ConnectionName);
            if (logging != null && LogMe)
                LogModifications(logging, LogCommand.Delete);
            SynapseForm.SynapseLogger.Debug(string.Format("Deleting object<{0}>", objectType.Name));
           
        }

        private void LogModifications(DBLoggingAttribute LogAttribute, LogCommand Command)
        {
            Type objectType = typeof(T);
            FieldInfo IDproperty = objectType.GetField("_IDproperty", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            PropertyInfo IDField = objectType.GetProperty(IDproperty.GetValue(null).ToString());
            List<LogValue> _LogValues = new List<LogValue>();

            if (Command == LogCommand.Save)
            {
                if (_initial == null)
                    Command = LogCommand.Insert;
                else
                    if (Convert.ToInt64(IDField.GetValue(_initial, null)) == 0)
                        Command = LogCommand.Insert;
                    else
                        Command = LogCommand.Modify;
            }

            LogEntry.TableName = "LogEntry_" + Assembly.GetEntryAssembly().GetName().Name;
            LogValue.TableName = "LogValue_" + Assembly.GetEntryAssembly().GetName().Name;

            foreach (PropertyInfo p in objectType.GetProperties())
            {
                bool _LogProperty = false;
                IList<BaseLogAttribute> CustomLogAttributes = p.GetCustomAttributes(typeof(BaseLogAttribute), true).Cast<BaseLogAttribute>().ToList();

                string OldValue = string.Empty;
                string NewValue = string.Empty;
                if (Command == LogCommand.Modify || Command == LogCommand.Delete)
                {
                    if (p.GetValue(_initial, null) != null)
                    {
                        switch (p.PropertyType.ToString())
                        {
                            case "System.DateTime":
                                if ((DateTime)p.GetValue(_initial, null) != DateTime.MinValue)
                                { OldValue = ((DateTime)p.GetValue(_initial, null)).ToString("dd/MM/yyyy"); }
                                break;
                            case "System.TimeSpan":
                                OldValue = ((TimeSpan)p.GetValue(_initial, null)).Hours.ToString("00") + "h" + ((TimeSpan)p.GetValue(_initial, null)).Minutes.ToString("00");
                                break;
                            case "System.Decimal":
                                OldValue = ((decimal)p.GetValue(_initial, null)).ToString("0.00");
                                break;
                            case "System.Boolean":
                                if ((bool)p.GetValue(_initial, null))
                                { OldValue = "X"; }
                                break;
                            default:
                                OldValue = p.GetValue(_initial, null).ToString();
                                break;
                        }
                    }
                }

                if (Command == LogCommand.Modify || Command == LogCommand.Insert)
                {
                    if (p.GetValue(this, null) != null)
                    {
                        switch (p.PropertyType.ToString())
                        {
                            case "System.DateTime":
                                if ((DateTime)p.GetValue(this, null) != DateTime.MinValue)
                                { NewValue = ((DateTime)p.GetValue(this, null)).ToString("dd/MM/yyyy"); }
                                break;
                            case "System.TimeSpan":
                                NewValue = ((TimeSpan)p.GetValue(this, null)).Hours.ToString("00") + "h" + ((TimeSpan)p.GetValue(this, null)).Minutes.ToString("00");
                                break;
                            case "System.Decimal":
                                NewValue = ((decimal)p.GetValue(this, null)).ToString("0.00");
                                break;
                            case "System.Boolean":
                                if ((bool)p.GetValue(this, null))
                                { NewValue = "X"; }
                                break;
                            default:
                                NewValue = p.GetValue(this, null).ToString();
                                break;
                        }
                    }
                }

                if (CustomLogAttributes.Count != 0)
                {
                    foreach (BaseLogAttribute CLA in CustomLogAttributes)
                    {
                        if (CLA is LogAttributes)
                        {
                            if (((LogAttributes)CLA).LogMe)
                            {
                                if (Command == LogCommand.Delete && ((LogAttributes)CLA).OnDelete)
                                    _LogProperty = true;
                                if (Command == LogCommand.Insert && ((LogAttributes)CLA).OnNew)
                                    _LogProperty = true;
                                if (Command == LogCommand.Modify && ((LogAttributes)CLA).OnEdit)
                                    _LogProperty = true;

                                if (((LogAttributes)CLA).QueryValue != "")
                                {
                                    if (OldValue != null && OldValue != "")
                                        OldValue = (String)SynapseCore.Database.DBFunction.ExecuteScalarQuery(((LogAttributes)CLA).QueryValue + OldValue);
                                    if (NewValue != null && NewValue != "")
                                        NewValue = (String)SynapseCore.Database.DBFunction.ExecuteScalarQuery(((LogAttributes)CLA).QueryValue + NewValue);
                                    if (OldValue == null)
                                        OldValue = "";
                                    if (NewValue == null)
                                        NewValue = "";
                                }
                            }
                        }
                        if (CLA is LogEntryAttributeValue)
                        {
                            if (this.LogEntryValue == null)
                            {
                                if (Command == LogCommand.Delete)
                                    this.LogEntryValue = OldValue;
                                else
                                    this.LogEntryValue = NewValue;
                            }
                            //_LogProperty = true;
                        }
                        if (CLA is LogEntryAttributeKey)
                        {
                            if (this.LogEntryKey == null)
                                this.LogEntryKey = NewValue;

                            //_LogProperty = true;
                        }
                    }
                }
                else
                {
                    if (p.Name != "LogEntryKey" && p.Name != "LogEntryValue" && p.Name != "IsDirty" && p.Name != "InitialValue")
                    {
                        _LogProperty = true;
                    }
                }

                if ((OldValue != NewValue && _LogProperty) || (Command == LogCommand.Delete && _LogProperty))
                {
                    LogValue _LogValue = new LogValue();
                    _LogValue.FIELD = LogAttribute.EntityName + "." + p.Name;
                    _LogValue.OLD_VALUE = OldValue;
                    _LogValue.NEW_VALUE = NewValue;
                    _LogValues.Add(_LogValue);
                }
            }
            if (_LogValues.Count > 0)
            {
                try
                {
                    LogEntry _LogEntry = new LogEntry();

                    switch (Command)
                    {
                        case LogCommand.Delete:
                            _LogEntry.ACTION_CODE = "DELETE";
                            break;
                        case LogCommand.Insert:
                            _LogEntry.ACTION_CODE = "INSERT";
                            break;
                        case LogCommand.Modify:
                            _LogEntry.ACTION_CODE = "MODIFY";
                            break;
                    }

                    _LogEntry.USERID = SynapseForm.FormUser.UserID;
                    _LogEntry.TIMESTAMP = DateTime.Now;
                    _LogEntry.OBJECT_NAME = LogAttribute.EntityName;
                    _LogEntry.OBJECT_VALUE = this.LogEntryValue;
                    _LogEntry.LOGKEY = this.LogEntryKey;
                    _LogEntry.save();

                    try
                    {
                        foreach (LogValue lv in _LogValues)
                        {
                            lv.FK_LOGENTRY = _LogEntry.ID;
                        }
                        _LogValues.SaveCollection();
                    }
                    // TODO: Catch more specific exception
                    catch (Exception)
                    {
                        // TODO: Handle exception (e.g. log)
                    }
                }
                // TODO: Catch more specific exception
                catch (Exception)
                {
                    // TODO: Handle exception (e.g. log)
                }
            }
        }

        public void dump()
        {
            Refresh();
            ComputeHash();
            _initial = new T();
            Type objectType = typeof(T);
            foreach (PropertyInfo p in objectType.GetProperties())
            {
                if (p.CanWrite)
                    p.SetValue(_initial, p.GetValue(this, null), null);
            }
        }

        public void rollback()
        {
            if (_initial != null)
            {
                Type objectType = typeof(T);
                foreach (PropertyInfo p in objectType.GetProperties())
                {
                    if (p.CanWrite)
                        p.SetValue(this, p.GetValue(_initial, null), null);
                }
            }
        }

        private void Refresh()
        {
            String ConnectionName = "Default";
            Type objectType = typeof(T);
            object[] connections = objectType.GetCustomAttributes(typeof(DBConnectionAttribute), true);

            if (connections.Length > 0)
                ConnectionName = ((DBConnectionAttribute)connections[0]).ConnectionName;

            FieldInfo query = objectType.GetField("_query", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            FieldInfo IDproperty = objectType.GetField("_IDproperty", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            Int64 ID = Int64.Parse(objectType.GetProperty(IDproperty.GetValue(this).ToString()).GetValue(this, null).ToString());
            if (ID == 0)
            {
                return; //CDC525 14/03/2012 don't reread if new item
            }
            T temp;
            temp = DBFunction.GetTableFromQuery(query.GetValue(null).ToString() + " WHERE " + IDproperty.GetValue(null).ToString() + " = " + ID.ToString(), ConnectionName).ToEntity<T>();
            if (temp != null)
            {
                foreach (PropertyInfo p in objectType.GetProperties())
                {
                    if (p.CanWrite)
                        p.SetValue(this, p.GetValue(temp, null), null);
                }
            }
        }
    }
}
