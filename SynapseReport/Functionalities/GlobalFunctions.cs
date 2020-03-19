using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Controls;
using SynapseCore.Security;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using SynapseReport.Forms;
using SynapseReport.Entities;
using SynapseReport.Functionalities;
using SynapseReport.UserControls;
namespace SynapseReport
{
    class GlobalFunctions
    {
        public static Boolean formAlreadyOpen(string formName, Int64 ID=0)
        {
            bool activate=false;
            if (Application.OpenForms["frmMain"] != null)
            {
                foreach (Form childForm in ((frmMain)Application.OpenForms["frmMain"]).MdiChildren)
                {
                    if (childForm.Name.ToUpper() == formName.ToUpper())
                    {
                        if (ID != 0)
                        {
                            switch (formName.ToUpper())
                            {
                                case "FRMREPORTDETAIL":
                                    if (((frmReportDetail)childForm).ReportID == ID)
                                    { activate = true; }
                                    break;
                            }
                        }
                        else
                        {
                            activate = true;
                        }
                        if (activate)
                        {
                            childForm.Activate();
                            childForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static string ReplaceXtraVariables(string Query)
        {
            string replaced = Query.Replace("[#currentlanguage#]", SynapseForm.CurrentLanguage.CODE);
            foreach (string k in GlobalVariables.XtraVariables.Keys)
            {
                replaced = replaced.Replace(k, GlobalVariables.XtraVariables[k]);
            }

            Regex _regex = new Regex("\\\x5B\\\x23(?<tag>.*?)\\\x23\\\x5D", RegexOptions.Compiled | RegexOptions.CultureInvariant);
            if (_regex.Matches(replaced).Count > 0)
            {
                frmMissingTags fMissingTags = new frmMissingTags();

                foreach (Match m in _regex.Matches(replaced))
                {
                    missingTag mTag = new missingTag();
                    mTag.lbTag.Text = m.Groups["tag"].Value.ToUpper();
                    mTag.txTagValue.Text = "";
                    mTag.Tag = m.Groups["tag"].Value;
                    mTag.Width = fMissingTags.pnlMissingTags.Width;
                    fMissingTags.pnlMissingTags.Controls.Add(mTag);
                }

                if (fMissingTags.ShowDialog() == DialogResult.OK)
                {
                    foreach (missingTag tag in fMissingTags.pnlMissingTags.Controls)
                    {
                        string tagName = "[#" + tag.Tag + "#]";
                        string tagValue = tag.txTagValue.Text;

                        replaced = replaced.Replace(tagName, tagValue);

                        if (GlobalVariables.XtraVariables.ContainsKey(tagName))
                            GlobalVariables.XtraVariables[tagName] = tagValue;
                        else
                            GlobalVariables.XtraVariables.Add(tagName, tagValue);
                    }
                }
            }

            return replaced;
        }
        public  class ObjectComparator<T>
        {
            public bool CompareProperties(T newObject, T oldObject)
            {
                if (object.Equals(newObject, oldObject)) 
                { 
                return true;
                } 

                if (newObject.GetType().GetProperties().Length != oldObject.GetType().GetProperties().Length) 
                { 
                    return false; 
                } 
                else 
                { 
                    var oldProperties = oldObject.GetType().GetProperties(); 
                    foreach (PropertyInfo newProperty in newObject.GetType().GetProperties()) 
                    { 
                        try 
                        { 
                            PropertyInfo oldProperty = oldProperties.Single(pi => pi.Name == newProperty.Name);
                            if (!object.Equals(newProperty.GetValue(newObject, null), oldProperty.GetValue(oldObject, null)))
                            {
                                if (newProperty.GetValue(newObject, null).GetType().Name.ToUpper() == "STRING")
                                {
                                    if ((string)newProperty.GetValue(newObject, null) == "" || (string)newProperty.GetValue(newObject, null) == null)
                                    {
                                        if ((string)oldProperty.GetValue(oldObject, null) != "" && (string)oldProperty.GetValue(oldObject, null) != null)
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        } 
                        catch 
                        { 
                            return false; 
                        } 
                    } 
                    return true; 
                } 
            }
        }

        private static List<String> _errorList=new List<String>();

        public static void resetError()
        {
            _errorList.Clear();
        }

        public static void addError(String code, String param = "")
        { 
            String _msg;

            _msg = SynapseForm.GetLabel(code);

            if (_msg == null)
            { _msg = code; }

            if (param != "")
            {
                _msg = _msg.Replace("#1", param);
            }

            _errorList.Add(_msg);
        }

        public static void showError(String CODE = "", String PARAM1 = "", String PARAM2 = "")
        {
            String _message = "";

            if(CODE != "")
            {
                _message = SynapseForm.GetLabel(CODE);
                if (PARAM1 != "")
                {
                    _message = _message.Replace("#1", PARAM1);
                }
                if (PARAM2 != "")
                {
                    _message = _message.Replace("#2", PARAM2);
                }
            }
            else
            {
                foreach (string line in _errorList)
                {
                    _message = _message + line.Replace("$tab$", "        ") + "\n";
                }
            }

            MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Error"),MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        public static System.Windows.Forms.DialogResult showMessage(String TYPE, String CODE = "", String PARAM1 = "", String PARAM2 = "")
        {
            String _message = "";

            if (CODE != "")
            {
                _message = SynapseForm.GetLabel(CODE);
                if (PARAM1 != "")
                {
                    _message = _message.Replace("#1", PARAM1);
                }
                if (PARAM2 != "")
                {
                    _message = _message.Replace("#2", PARAM2);
                }
            }

            switch (TYPE)
            {
                case "WARN":
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                case "ERR":
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                case "INFO":
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                case "QUEST":
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                default:
                    return MessageBox.Show(_message, SynapseForm.GetLabel("Dialog.Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static byte[] ReadFile(string sPath) 
        { 
 
            //Initialize byte array with a null value initially. 
            byte[] data = null; 
            //Use FileInfo object to get file size. 
            FileInfo fInfo = new FileInfo(sPath); 
            long numBytes = fInfo.Length; 
            //Open FileStream to read file 
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read); 
            //Use BinaryReader to read file stream into byte array. 
            BinaryReader br = new BinaryReader(fStream); 
            //When you use BinaryReader, you need to supply number of bytes to read from file. 
            //In this case we want to read entire file. So supplying total number of bytes. 
            data = br.ReadBytes((int)numBytes); 
            //Close BinaryReader 
            br.Close(); 
            //Close FileStream 
            fStream.Close(); 
  
            return data; 
        }

        public static List<FieldFunction> LoadFieldFunction()
        {
            List<FieldFunction> _list = new List<FieldFunction>();

            FieldFunction ff1 = new FieldFunction();
            ff1.CODE = "";
            ff1.LABEL = "None";
            _list.Add(ff1);

            FieldFunction ff2 = new FieldFunction();
            ff2.CODE = "LBL";
            ff2.LABEL = "Line Label";
            _list.Add(ff2);

            FieldFunction ff3 = new FieldFunction();
            ff3.CODE = "SUM";
            ff3.LABEL = "Sum(*)";
            _list.Add(ff3);

            FieldFunction ff4 = new FieldFunction();
            ff4.CODE = "MAX";
            ff4.LABEL = "Max(*)";
            _list.Add(ff4);

            FieldFunction ff5 = new FieldFunction();
            ff5.CODE = "MIN";
            ff5.LABEL = "Min(*)";
            _list.Add(ff5);

            FieldFunction ff6 = new FieldFunction();
            ff6.CODE = "AVG";
            ff6.LABEL = "Average(*)";
            _list.Add(ff6);

            FieldFunction ff7 = new FieldFunction();
            ff7.CODE = "CNT";
            ff7.LABEL = "Count(*)";
            _list.Add(ff7);

            FieldFunction ff8 = new FieldFunction();
            ff8.CODE = "CNTNB";
            ff8.LABEL = "Count Non Blank(*)";
            _list.Add(ff8);

            return _list;
        }

        public static FieldFunction LoadFieldFunctionByCode(string Code)
        {
            return (from f in LoadFieldFunction() where f.CODE == Code select f).FirstOrDefault();
        }
    }
}
