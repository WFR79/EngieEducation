using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Controls;
using SynapseCore.Entities;
using System.Reflection;
using SynapseAdvancedControls;


namespace SynapseCore
{
    public static class ControlExtension
    {
        public static bool WillDie(this Control c) 
        {
            return true;
        }
        public static string AspectName(this Control c)
        {
            foreach (SynapseControl sc in SynapseForm.FormUser.UserControls.Values.Cast<SynapseControl>().Where(ctrl => ctrl.CTRL_NAME == c.Name && ctrl.FORM_NAME == c.FindForm().Name))
            {
                return sc.ID.ToString();
            }
            return "";
        }
        public static void ObjectToForm(this SynapseForm form, object obj)
        {
            IList<SynapseControl> FormControls = SynapseForm.FormUser.UserControls.Values.Cast<SynapseControl>().Where(ctrl => ctrl.CTRL_NAME.Length > 0).ToList();
            IList<PropertyInfo> properties = (obj.GetType()).GetProperties();
            var c = GetAll(form, typeof(TextBox));

           
        }
        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        public static void SaveConfigToDB(this SynapseAdvancedControls.ObjectListView olv,string key)
        {
            
            SynapseOlvConfig Config;
            Config = SynapseOlvConfig.Load("WHERE OLVKEY = '" + key + "' AND MODULEID = " + SynapseForm.FormUser.CurrentModuleID + " AND USERID = '" + SynapseForm.FormUser.UserID + "'").FirstOrDefault();
            if (Config == null)
            {
                Config = new SynapseOlvConfig();
                Config.OLVKEY = key;
                Config.MODULEID = SynapseForm.FormUser.CurrentModuleID;
                Config.USERID = SynapseForm.FormUser.UserID;
            }
            Config.CONFIG=olv.SaveState();
            Config.save();
        }

        public static void LoadConfigFromDB(this SynapseAdvancedControls.ObjectListView olv, string key)
        {
            SynapseOlvConfig Config;
            Config = SynapseOlvConfig.Load("WHERE OLVKEY = '" + key + "' AND MODULEID = " + SynapseForm.FormUser.CurrentModuleID + " AND USERID = '" + SynapseForm.FormUser.UserID + "'").FirstOrDefault();
            if (Config != null)
            {
                olv.RestoreState(Config.CONFIG);
                //olv.RestoreState(new byte[1]);
            }
        }
        //public static void FillColumnID(this SynapseAdvancedControls.ObjectListView olv)
        //{ 
        //    foreach (OLVColumn c in olv.AllColumns)
        //    {
        //        c.ColumnID = c.Text;
        //    }
        //}


    }
}
