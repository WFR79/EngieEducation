namespace SynapseCore.Database
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;

    public enum ConnectionType
    {
        MsSql = 0,
        OleDB = 1
    };

    public sealed class DBConnection
    {
        private System.Data.Common.DbConnection _Connection;
        private System.Data.Common.DbTransaction _Transaction;
        private ConnectionType _Type;
        private DateTime _LastCheck;
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public DateTime LastCheck
        {
            get { return _LastCheck; }
            set { _LastCheck = value; }
        }
        public ConnectionType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public DBConnection(ConnectionType type, string name)
        {
            _Type = type;
            _Name = name;
            switch (_Type)
            {
                case ConnectionType.MsSql:
                    _Connection = new SqlConnection();
                    break;
                case ConnectionType.OleDB:
                    _Connection = new OleDbConnection();
                    break;
                default:
                    throw new SynapseCoreException("Bad connection type");
            }
        }

        public System.Data.Common.DbConnection Connection
        {
            get { return _Connection; }
            set { _Connection = value; }
        }
        public System.Data.Common.DbTransaction Transaction
        {
            get { return _Transaction; }
            set { _Transaction = value; }
        }
        public string ConnectionString
        {
            get { return _Connection.ConnectionString; }
            set { _Connection.ConnectionString = value; }
        }

        public ConnectionState State
        {
            get
            {
                return ((System.Data.Common.DbConnection)_Connection).State;
            }
        }
        public void Open()
        {
            ((System.Data.Common.DbConnection)_Connection).Open();
        }
        public void Close()
        {
            _Connection.Close();
        }
        public System.Data.Common.DbTransaction BeginTransaction()
        {
            _Transaction = _Connection.BeginTransaction();
            return _Transaction;
        }
    }
}