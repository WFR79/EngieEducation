using System;
using System.Windows.Forms;
using ISNuclear.Data.Interfaces;
using ISNuclear.Core.Synapse.Enums.ISNuclear.Data.Enums;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace ISNuclear.Core.Synapse.Forms
{
    public abstract class NewForm<T,U>: ISNuclearForm<U> where T: class, IEntityObject, new() where U: IContainer
    {
        #region "Fields"
        private BindingSource _bds;
        public event EventHandler BeforeSave;
        #endregion "Fields"

        #region "Properties"
        public BindingSource BDS => _bds ?? (_bds = new BindingSource() { DataSource = typeof(T) });

        protected T Object
        {
            get => BDS.DataSource != null && BDS.DataSource is T ? BDS.DataSource as T : new T();
            set => BDS.DataSource = value;
        }
        #endregion "Properties"

        #region "Constructors"
        public NewForm(T myObject, IGlobal<U> global)
            : base(global)
        {
            Object = myObject;
            FormClosing += frm_FormClosing;
            WindowState = FormWindowState.Normal; 
        }
        #endregion "Constructors"

        #region "Event Handlers"
        public void tsbSave_Click(object sender, EventArgs e)
        {
            if (!checkFields()) { return; }
            if (Object.Id <= 0) { addAction(); }
            BeforeSave?.Invoke(this, new EventArgs()); Global.Container.SaveChanges();
            DialogResult = DialogResult.OK;
            CloseForm();
        }

        public void tsbCancel_Click(object sender, EventArgs e)
        {
            if (Object.Id > 0) { Global.Container.ObjectContext.Refresh(RefreshMode.StoreWins, Object); }
            DialogResult = DialogResult.Cancel;
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (Object.Id <= 0 || Global.Container.Entry(Object).State != EntityState.Unchanged)
                {
                    var _result = Global.ShowMessage(ErrorCode.QUEST_AND_CANCEL, "RoomPicker.Quest.0001");
                    switch (_result)
                    {
                        case DialogResult.Yes:
                            tsbSave_Click(null, null);
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                        default:
                            tsbCancel_Click(null, null);
                            break;
                    }
                }
            }
        }
        #endregion "Event Handlers"

        #region "Methods"
        public abstract bool checkFields();
        public abstract void addAction();
        #endregion "Methods"
    }
}
