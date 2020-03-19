using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using SynapseCore.Database;
using SynapseCore.Entities;
using System.Collections;
using SynapseCore.Controls;

namespace SynapseCore.Controls
{
    public partial class frm_SynapseObjectEdit : SynapseForm
    {
        private  string _IDproperty;
        private  string _EcludeForSave;
        private string _tableName;
        private IList<SynapseLanguage> languages;
        private Hashtable bags;
        private object _SynapseObject;
        private bool _NewLabels = false;
        public frm_SynapseObjectEdit(object SynapseObject)
        {
            InitializeComponent();
            _SynapseObject = SynapseObject;
            bags = new Hashtable();
            languages = SynapseLanguage.Load();
            IList<PropertyInfo> properties = SynapseObject.GetType().GetProperties();
            IList<FieldInfo> fields = SynapseObject.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance|BindingFlags.Static);
            List<Control> labelBagControl=new List<Control>();
            foreach (FieldInfo fi in fields)
            {
                if (fi.Name == "_IDproperty")
                    _IDproperty = fi.GetValue(SynapseObject).ToString();
                if (fi.Name == "_EcludeForSave")
                    _EcludeForSave = fi.GetValue(SynapseObject).ToString();
                if (fi.Name == "_tableName")
                    _tableName = fi.GetValue(SynapseObject).ToString().Trim(new char[] {'[',']'});
            }
            foreach (PropertyInfo pi in from x in properties where x.PropertyType.ToString()=="SynapseCore.Database.LabelBag" select x)
            {

                    uc_LabelBag bag = new uc_LabelBag();
                    object value = pi.GetValue(SynapseObject, null);
                    LabelBag lbl = (LabelBag)value;
                    Int64 lblid = lbl.GetLabelID();
                    if (lblid == 0)
                        lblid = SynapseLabel.GetNextID();

                    LabelId[] ids = (LabelId[])pi.GetCustomAttributes(typeof(LabelId), true);
                    foreach (LabelId id in ids)
                    {
                        PropertyInfo field = SynapseObject.GetType().GetProperty(id.IDField);
                        field.SetValue(SynapseObject, lblid, null);
                        bags.Add(id.IDField, id);
                    }

                    if (lbl.Labels.Count < languages.Count)
                    {
                        foreach (SynapseLanguage lang in languages)
                        {
                            if (lbl.GetLabel(lang.CODE) == null)
                            {
                                SynapseLabel newlabel = new SynapseLabel();

                                newlabel.LABELID = lblid;

                                newlabel.LANGUAGE = lang.CODE;
                                newlabel.TEXT = "";
                                newlabel.save();
                                lbl.Labels.Add(newlabel);
                            }
                        }
                        _NewLabels = true;
                    }

                    bag.FieldName = pi.Name;
                    bag.LblBag = lbl;
                    labelBagControl.Add(bag);
                    //flowLayoutPanel1.Controls.Add(bag);

            }

            foreach (PropertyInfo pi in from x in properties where x.PropertyType.ToString() != "SynapseCore.Database.LabelBag" select x)
            {
                if (!bags.ContainsKey(pi.Name))
                {
                    EntityFieldType FieldType = ((EntityFieldType[])pi.GetCustomAttributes(typeof(EntityFieldType), true)).SingleOrDefault();

                    uc_Field field;
                    if (FieldType != null)
                        field = new uc_Field(FieldType);
                    else
                        field = new uc_Field();
                    field.FieldName = pi.Name;
                    field.DisplayName = SynapseForm.GetLabel(_tableName.ToUpperInvariant() + "." + pi.Name.ToUpperInvariant());
                    object value = pi.GetValue(SynapseObject, null);
                    if (value != null)
                        field.FieldValue = value;
                    if (pi.Name == _IDproperty)
                        field.Enabled = false;
                    flowLayoutPanel1.Controls.Add(field);
                }

            }
            flowLayoutPanel1.Controls.AddRange(labelBagControl.ToArray());
            if (_NewLabels) SynapseObject.GetType().InvokeMember("save", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, SynapseObject, null);
        }

        private void frm_LabelBogEdit_Load(object sender, EventArgs e)
        {

        }

        private void tsbtn_save_Click(object sender, EventArgs e)
        {
            List<uc_Field> fields = flowLayoutPanel1.Controls.OfType<uc_Field>().Cast<uc_Field>().ToList();
            List<uc_LabelBag> bags = flowLayoutPanel1.Controls.OfType<uc_LabelBag>().Cast<uc_LabelBag>().ToList();
            foreach (uc_LabelBag bag in bags)
                bag.Save();
            foreach (uc_Field field in fields)
            {
                try
                {
                    _SynapseObject.GetType().GetProperty(field.FieldName).SetValue(_SynapseObject, field.FieldValue, null);
                }
                // TODO: Replace by more specific exception
                catch (Exception ex)
                {
                    SynapseForm.SynapseLogger.Error(ex.Message);
                }
            }
            _SynapseObject.GetType().InvokeMember("save", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, _SynapseObject, null);
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
