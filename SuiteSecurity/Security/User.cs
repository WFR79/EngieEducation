/*
 * Created by SharpDevelop.
 * User: hce339
 * Date: 21/03/2012
 * Time: 08:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using SynapseCore.Controls;
using SynapseCore.Entities;

namespace SynapseCore.Security
{
    /// <summary>
    /// Description of MyClass.
    /// </summary>
    public class User
    {
        IList<ControlSecurity> CSC;
        Hashtable _UserControls;

        public Hashtable UserControls
        {
            get { return _UserControls; }
            set { _UserControls = value; }
        }

        private string _UserID;
        private SynapseUser SUser;
        private Int64 _CurrentModuleID;

        public Int64 CurrentModuleID
        {
            get { return _CurrentModuleID; }
            set { _CurrentModuleID = value; }
        }

        public void SaveUser()
        {
            SUser.save();
        }

        public string UserCulture
        {
            get { return SUser.CULTURE; }
            set { SUser.CULTURE = value; }
        }

        public string FirstName
        {
            get { return SUser.FIRSTNAME; }
        }

        public string LastName
        {
            get { return SUser.LASTNAME; }
        }

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private IList<SynapseProfile> _Groups;

        public IList<SynapseProfile> Groups
        {
            get { return _Groups; }
            set { _Groups = value; }
        }
        private IList<SynapseModule> _Modules;

        public IList<SynapseModule> Modules
        {
            get { return _Modules; }
            set { _Modules = value; }
        }

        public User(string UID, Int64 ModuleID)
        {
            SUser = SynapseUser.LoadByUserID(UID);
            UserID = UID;
            _CurrentModuleID = ModuleID;
            _UserControls = new Hashtable();
            try
            {
                _Groups = SynapseProfile.LoadFromQuery("SELECT [P_ID] as ID,[FK_ModuleID],[FK_LABELID],[P_TECHNICALNAME] as TECHNICALNAME,[IS_OWNER],[LEVEL] FROM [V_Synapse_UserGroups] WHERE UserID = '" + UID + "'");

                _Modules = SynapseModule.LoadFromQuery("SELECT DISTINCT [M_ID] as ID,[LABELID],[PATH],[M_TECHNICALNAME] as TECHNICALNAME,[VERSION],[MODULECATEGORY],[VERSIONDATE],[DESCLABELID],[DEVSOURCE],[PRODSOURCE],[IS_ACTIVE],[IS_REQUESTABLE] FROM [V_Synapse_UserGroups] WHERE UserID = '" + UID + "' OR M_ID=1 ORDER BY MODULECATEGORY");

                CSC = ControlSecurity.Load("WHERE (UserID = '" + UserID + "' OR UserID = 'Everybody') AND (FK_MODULE_ID=" + ModuleID + " OR FK_MODULE_ID=1)");
                foreach (ControlSecurity C in CSC)
                {
                    try
                    {
                        _UserControls.Add(C.FORM_NAME + C.CTRL_NAME, C);
                    }
                    // TODO: Catch more specific exception
                    catch (Exception ex)
                    {
                        SynapseForm.SynapseLogger.Error(ex.Message);
                    }
                }
            }
            // TODO: Catch more specific exception
            catch (Exception ex)
            {
                SynapseForm.SynapseLogger.Error(ex.Message);
            }
        }

        public void ReloadModulesAndGroups()
        {
            try
            {
                _Groups = SynapseProfile.LoadFromQuery("SELECT [P_ID] as ID,[FK_ModuleID],[FK_LABELID],[P_TECHNICALNAME] as TECHNICALNAME,[IS_OWNER],[LEVEL] FROM [V_Synapse_UserGroups] WHERE UserID = '" + UserID + "'");
                _Modules = SynapseModule.LoadFromQuery("SELECT DISTINCT [M_ID] as ID,[LABELID],[PATH],[M_TECHNICALNAME] as TECHNICALNAME,[VERSION],[MODULECATEGORY],[VERSIONDATE],[DESCLABELID],[DEVSOURCE],[PRODSOURCE],[IS_ACTIVE],[IS_REQUESTABLE] FROM [V_Synapse_UserGroups] WHERE UserID = '" + UserID + "' OR M_ID=1 ORDER BY MODULECATEGORY");
            }
            // TODO: Catch more specific exception
            catch (Exception ex)
            {
                SynapseForm.SynapseLogger.Error(ex.Message);
            }
        }

        public bool IsControlVisibleForUser(string key)
        {
            if (_UserControls.ContainsKey(key))
                return ((ControlSecurity)_UserControls[key]).IS_VISIBLE;
            else
            {
                return false;
            }
        }

        public bool IsControlEnabledForUser(string key)
        {
            if (_UserControls.ContainsKey(key))
                return ((ControlSecurity)_UserControls[key]).IS_ACTIVE;
            else
                return false;
        }

        public bool IsMemberOf(string group)
        {
            foreach (SynapseProfile Profile in this.Groups)
            {
                if (Profile.TECHNICALNAME == group)
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            return LastName + " " + FirstName;
        }
    }
}