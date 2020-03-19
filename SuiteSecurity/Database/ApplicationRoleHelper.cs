using System;
using System.Data;
using System.Data.SqlClient;
using SynapseCore.Security;
using System.Data.Objects;

namespace SynapseCore.Database
{
    /// <summary>
    /// Static helper class to switch to a SQL Server Application Role
    /// The encrypted key is retrieved from the DB on every call which is a minor performance hit. This is by design.
    /// </summary>
    /// <remarks>
    /// A singleton implementation is not feasible as the connection needs to be available in the constructor (or as a parameter).
    /// </remarks>
    /// <see cref="http://csharpindepth.com/Articles/General/Singleton.aspx"/>
    public static class ApplicationRoleHelper
    {
        private const string GetApplicationRoleKeyFunction = "[dbo].[GetApplicationRoleKey]";
        private const string SetAppRoleStoredProcedure = "[sys].[sp_setapprole]";
        private const string RoleNameParameter = "@rolename";
        private const string PasswordParameter = "@password";
        private const string ReturnValueParameter = "@returnValue";

        /// <summary>
        /// Switch the connection in "Application Role" mode with the provided Application Role name
        /// </summary>
        /// <see cref="http://technet.microsoft.com/en-us/library/ms188908.aspx"/>
        public static void SwitchToApplicationRole(this SqlConnection connectionToSwitch, string ApplicationRoleName)
        {
            // Get the encrypted version of the key from the DB
            string encryptedKey = getKeyFromDB(connectionToSwitch);
 
            // Get the key decoder
            SimpleAES decoder = new SimpleAES();

            // Execute the required stored procedure
            if (!performSwitch(connectionToSwitch, decoder.Decrypt(encryptedKey), ApplicationRoleName))
            { 
                throw new SynapseCoreException(string.Format("Unable to switch to Application Role '{0}'.", ApplicationRoleName));
            }
        }



        private static string getKeyFromDB(SqlConnection connection)
        {
            using (SqlCommand commandGetKey = new SqlCommand(GetApplicationRoleKeyFunction, connection))
            {
                commandGetKey.CommandType = CommandType.StoredProcedure;
                // Set Return Value parameter
                commandGetKey.Parameters.Add(new SqlParameter(ReturnValueParameter, SqlDbType.NVarChar, 192)).Direction = ParameterDirection.ReturnValue;
                try
                {
                    int rowsAffected = commandGetKey.ExecuteNonQuery(); // Will return -1 
                }
                catch (SqlException sex)
                {
                    throw new SynapseCoreException("SQL Error while getting Application Role key", sex);
                }
                return (string)commandGetKey.Parameters[ReturnValueParameter].Value;
            }
        }

        private static bool performSwitch(SqlConnection connection, string decodedKey, string ApplicationRoleName)
        {
            int returnCode;

            using (SqlCommand commandSetAppRole = new SqlCommand(SetAppRoleStoredProcedure, connection))
            {
                commandSetAppRole.CommandType = CommandType.StoredProcedure;
                SqlParameterCollection commandParameters = commandSetAppRole.Parameters;
                // Set Application Role name parameter
                commandParameters.Add(new SqlParameter(RoleNameParameter, SqlDbType.NVarChar, 128)).Direction = ParameterDirection.Input;
                commandParameters[RoleNameParameter].Value = ApplicationRoleName;
                // Set Password parameter
                commandParameters.Add(new SqlParameter(PasswordParameter, SqlDbType.NVarChar, 128)).Direction = ParameterDirection.Input;
                commandParameters[PasswordParameter].Value = decodedKey;
                // Set Return Value parameter
                commandParameters.Add(new SqlParameter(ReturnValueParameter, SqlDbType.Int)).Direction = ParameterDirection.ReturnValue;
                try
                {
                    int rowsAffected = commandSetAppRole.ExecuteNonQuery(); // Will return -1 
                }
                catch (SqlException sex)
                {
                    throw new SynapseCoreException("SQL Error while switching Application Role", sex);
                }
                returnCode = (int)commandParameters[ReturnValueParameter].Value;
            }
            return (returnCode == 0);
        }
    }
}
