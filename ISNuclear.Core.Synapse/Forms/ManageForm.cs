using System;
using SynapseAdvancedControls;
using ISNuclear.Data.Interfaces;
using System.Collections;

namespace ISNuclear.Core.Synapse.Forms
{
    public abstract class ManageForm<T,Y>: ISNuclearForm<T> where T : IContainer where Y: class, IDeleteable
    {
        #region "Fields"
        private ObjectListView _objectListView;
        #endregion "Fields"

        #region "Properties"
        public ObjectListView ObjectListView =>_objectListView ?? (_objectListView = new ObjectListView()                   {          
                    AlternateRowBackColor = System.Drawing.Color.Lavender,
                    FullRowSelect = true,
                    GridLines = true,
                    HasCollapsibleGroups = false,
                    OwnerDraw = true,
                    ShowGroups = false,
                    ShowImagesOnSubItems = true,
                    UseAlternatingBackColors = true,
                    UseCompatibleStateImageBehavior = false,
                    UseSubItemCheckBoxes = true,
                    View = System.Windows.Forms.View.Details,
                    UseFiltering = true
                });

        public Y Object => ObjectListView.SelectedObject != null ? ObjectListView.SelectedObject as Y : null;
        #endregion "Properties"

        #region "Constructors"
        public ManageForm(IGlobal<T> global): base(global) { }
        #endregion "Constructors"

        #region "Event Handlers"
        public void tsbDelete_Click(object sender, EventArgs e)
        {
            if (Object != null)
            {
                Object.Deleted = true;
                Global.Container.SaveChanges();
                ObjectListView.SetObjects(GetObjects());
            }
        }

        public void tsbExit_Click(object sender, EventArgs e) => CloseForm();
        #endregion "Event Handlers"

        #region "Methods"
        public abstract IEnumerable GetObjects();
        #endregion "Methods"
    }
}
