using System;
using System.Data;
using System.Data.SqlClient;
using SynapseCore.Security;
using System.Data.Objects;

using System.Data.Entity;
//using System.Data.Entity.Infrastructure;

namespace SynapseCore.Database
{
    public static class EntityFrameworkHelper
    {
        /// <summary>
        /// Switch the connection for the Entity framework context
        /// Warning : DO NOT USE CONNECTION POOLING
        /// </summary>
        /// <param name="OC">Object Context</param>
        /// <param name="ApplicationRoleName">Application Role Name</param>
        /// <remarks>HCE339:Warning : DO NOT USE CONNECTION POOLING</remarks>
        public static void SwicthEFAppRole(this ObjectContext OC, string ApplicationRoleName)
        {
            var entityConnection = (System.Data.EntityClient.EntityConnection)OC.Connection;
            //SqlConnection SqlConn = (System.Data.EntityClient.EntityConnection)OC.Connection.st;
            SqlConnection conn = entityConnection.StoreConnection as SqlConnection;
            ConnectionState initialState = conn.State;
            //conn.StateChange += new StateChangeEventHandler(conn_StateChange);
            //conn.InfoMessage += new SqlInfoMessageEventHandler(conn_InfoMessage);
            if (initialState != ConnectionState.Open)
                conn.Open();

            conn.SwitchToApplicationRole(ApplicationRoleName);

        }
        /// <summary>
        /// Switch the connection for the Entity framework context
        /// Warning : DO NOT USE CONNECTION POOLING
        /// </summary>
        /// <param name="DC"></param>
        /// <param name="ApplicationRoleName"></param>
        public static void SwicthEFAppRole(this DbContext DC, string ApplicationRoleName)
        {
            var entityConnection = DC.Database.Connection;
            //SqlConnection SqlConn = (System.Data.EntityClient.EntityConnection)OC.Connection.st;
            SqlConnection conn = entityConnection as SqlConnection;
            ConnectionState initialState = conn.State;
            //conn.StateChange += new StateChangeEventHandler(conn_StateChange);
            //conn.InfoMessage += new SqlInfoMessageEventHandler(conn_InfoMessage);
            if (initialState != ConnectionState.Open)
                conn.Open();

            conn.SwitchToApplicationRole(ApplicationRoleName);

        }
    }
}
