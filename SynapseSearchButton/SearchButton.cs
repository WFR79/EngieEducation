using System;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using SynapseAdvancedControls;
using SynapseCore.Controls;

namespace SynapseSearchButton
{
    [ToolboxBitmap(typeof(SearchButton), "SearchButton.bmp")]
    public partial class SearchButton : ToolStripDropDownButton
    {
        private ToolStripTextBox txtToSearch = new ToolStripTextBox();
        private ToolStripButton btEraseSearch = new ToolStripButton();
        private ContextMenuStrip mnuDropDown = new ContextMenuStrip();
        private ToolStripMenuItem mnuSelectAll = new ToolStripMenuItem();
        private ToolStripMenuItem mnuUnselectAll = new ToolStripMenuItem();
        private ToolStripMenuItem mnuHighlight = new ToolStripMenuItem();

        private HeaderFormatStyle NormalHeader = new HeaderFormatStyle();
        private HeaderFormatStyle SearchableHeader = new HeaderFormatStyle();

        private ToolStrip ParentToolStrip;

        [Category("Custom Properties of Search Button"), Description("At runtime, a Search Textbox and an Erase Button will be added")]
        public SearchButton()
        {
            CreateMenuList();
        }

        private ObjectListView _Listview;
        [Category("Custom Properties of Search Button"), Description("Name of the ObjectListview linked to the 'Search'")]
        public ObjectListView Listview
        {
            get { return _Listview; }
            set
            {
                _Listview = value;
                CreateColumnList();
            }
        }

        private bool _UseFrameworkGetLabel = true;
        [Category("Custom Properties of Search Button"), Description("If true, the labels for the buttons and menus will be taken from the Framework function GetLabel with the property defined for each one. If false, the labels are taken directly from the property of each one.")]
        public bool UseFrameworkGetLabel
        {
            get { return _UseFrameworkGetLabel; }
            set { _UseFrameworkGetLabel = value; }
        }

        private string _SearchButtonText = "Search Options";
        [Category("Custom Properties of Search Button"), Description("String for the 'GetLabel' function or Text that will be displayed as tooltip on the 'Search' DropDownButton")]
        public string SearchButtonText
        {
            get { return _SearchButtonText; }
            set
            {
                _SearchButtonText = value;
                this.Text = _SearchButtonText;
            }
        }

        private string _EraseButtonText = "Erase Searched Text";
        [Category("Custom Properties of Search Button"), Description("String for the 'GetLabel' function or Text that will be displayed as tooltip on the 'Erase Searched Text' Button")]
        public string EraseButtonText
        {
            get { return _EraseButtonText; }
            set
            {
                _EraseButtonText = value;
                btEraseSearch.Text = _EraseButtonText;
            }
        }

        private string _SelectAllText = "Select All Columns";
        [Category("Custom Properties of Search Button"), Description("String for the 'GetLabel' function or Text of the 'Select All Columns' ToolStripMenuItem")]
        public string SelectAllText
        {
            get { return _SelectAllText; }
            set
            {
                _SelectAllText = value;
                mnuSelectAll.Text = _SelectAllText;
            }
        }

        private string _UnselectAllText = "Unselect All Columns";
        [Category("Custom Properties of Search Button"), Description("String for the 'GetLabel' function or Text of the 'Unselect All Columns' ToolStripMenuItem")]
        public string UnselectAllText
        {
            get { return _UnselectAllText; }
            set
            {
                _UnselectAllText = value;
                mnuUnselectAll.Text = _UnselectAllText;
            }
        }

        private string _HilightResultText = "Highlight Results";
        [Category("Custom Properties of Search Button"), Description("String for the 'GetLabel' function or Text of the 'Hightlight Result' ToolStripMenuItem")]
        public string HilightResultText
        {
            get { return _HilightResultText; }
            set
            {
                _HilightResultText = value;
                mnuHighlight.Text = _HilightResultText;
            }
        }

        private bool _OnlySearchable = true;
        [Category("Custom Properties of Search Button"), Description("List only the columns of the ObjectListview with property 'Searchable' = True")]
        public bool OnlySearchable
        {
            get { return _OnlySearchable; }
            set 
            { 
                _OnlySearchable = value;

                RemoveColumnList();
                CreateColumnList();
            }
        }

        public new Image Image
        {
            get
            {
                Image img = Properties.Resources.Find;

                if (img != null)
                {
                    base.Image = img;
                    return img;
                }
                return base.Image;
            }
            set
            {
                base.Image = value;
            }
        }

        public void InitializeSearcher()
        {
            ParentToolStrip = (ToolStrip)this.Parent;

            if (ParentToolStrip.Items.Contains(txtToSearch))
                ParentToolStrip.Items.Remove(txtToSearch);
            if (ParentToolStrip.Items.Contains(btEraseSearch))
                ParentToolStrip.Items.Remove(btEraseSearch);

            txtToSearch = new ToolStripTextBox();
            txtToSearch.BorderStyle = BorderStyle.FixedSingle;
            txtToSearch.KeyUp += new KeyEventHandler(txtToSearch_KeyUp);
            ParentToolStrip.Items.Insert(ParentToolStrip.Items.IndexOf(this) + 1, txtToSearch);

            btEraseSearch = new ToolStripButton();
            btEraseSearch.Click += new EventHandler(btEraseSearch_Click);
            btEraseSearch.Text = _EraseButtonText;
            btEraseSearch.Image = Properties.Resources.Eraser;
            btEraseSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ParentToolStrip.Items.Insert(ParentToolStrip.Items.IndexOf(this) + 2, btEraseSearch);

            CreateMenuList();
            CreateColumnList();

            if (_UseFrameworkGetLabel)
            {
                this.Text = SynapseForm.GetLabel(_SearchButtonText);
                btEraseSearch.Text = SynapseForm.GetLabel(_EraseButtonText);
                mnuSelectAll.Text = SynapseForm.GetLabel(_SelectAllText);
                mnuUnselectAll.Text = SynapseForm.GetLabel(_UnselectAllText);
                mnuHighlight.Text = SynapseForm.GetLabel(_HilightResultText);
            }
            else
            {
                this.Text = _SearchButtonText;
                btEraseSearch.Text = _EraseButtonText;
                mnuSelectAll.Text = _SelectAllText;
                mnuUnselectAll.Text = _UnselectAllText;
                mnuHighlight.Text = _HilightResultText;
            }

            this.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
        }

        private void CreateMenuList()
        {
            this.DropDownItems.Clear();
            this.Image = Properties.Resources.Find;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;

            mnuDropDown = new ContextMenuStrip();
            mnuDropDown.ImageScalingSize = new Size(16, 16);

            mnuSelectAll = new ToolStripMenuItem();
            mnuSelectAll.Text = _SelectAllText;
            mnuSelectAll.Image = Properties.Resources.Checked;
            mnuSelectAll.Click += new EventHandler(SearchAll_Click);
            mnuDropDown.Items.Add(mnuSelectAll);

            mnuUnselectAll = new ToolStripMenuItem();
            mnuUnselectAll.Text = _UnselectAllText;
            mnuUnselectAll.Image = Properties.Resources.Unchecked;
            mnuUnselectAll.Click += new EventHandler(SearchNone_Click);
            mnuDropDown.Items.Add(mnuUnselectAll);

            mnuHighlight = new ToolStripMenuItem();
            mnuHighlight.Text = _HilightResultText;
            mnuHighlight.Image = Properties.Resources.Highlight;
            mnuHighlight.Checked = false;
            mnuHighlight.CheckState = CheckState.Unchecked;
            mnuHighlight.CheckOnClick = true;
            mnuHighlight.Click += new EventHandler(mnuHighlight_Click);
            mnuDropDown.Items.Add(mnuHighlight);

            mnuDropDown.Items.Add(new ToolStripSeparator());

            this.DropDown = mnuDropDown;
        }

        private void CreateColumnList()
        {
            if (_Listview != null)
            {
                foreach (OLVColumn col in _Listview.Columns)
                {
                    if ((_OnlySearchable && col.Searchable) || !_OnlySearchable)
                    {
                        col.HeaderImageKey = "";

                        ToolStripMenuItem SearchColumn = new ToolStripMenuItem();
                        SearchColumn.Text = col.Text;
                        SearchColumn.Checked = true;
                        SearchColumn.CheckState = CheckState.Checked;
                        SearchColumn.CheckOnClick = true;
                        SearchColumn.Tag = col;
                        SearchColumn.CheckedChanged += new EventHandler(SearchColumn_CheckedChanged);

                        this.DropDownItems.Add(SearchColumn);
                    }
                }
            }
            else
                RemoveColumnList();
        }

        private void RemoveColumnList()
        {
            for (int x = this.DropDownItems.Count - 1; x > 3; x--)
            {
                this.DropDownItems.RemoveAt(x);
            }
        }

        protected void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
        }

        private void SearchAll_Click(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                foreach (object obj in this.DropDownItems)
                {
                    if (obj.GetType() == typeof(ToolStripMenuItem))
                    {
                        if (((ToolStripMenuItem)obj).Tag != null)
                            ((ToolStripMenuItem)obj).Checked = true;
                    }
                }
            }
        }
        private void SearchNone_Click(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                foreach (object obj in this.DropDownItems)
                {
                    if (obj.GetType() == typeof(ToolStripMenuItem))
                    {
                        if (((ToolStripMenuItem)obj).Tag != null)
                            ((ToolStripMenuItem)obj).Checked = false;
                    }
                }
            }
        }

        private void mnuHighlight_Click(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                txtToSearch_KeyUp(null, null);
            }
            else
                mnuHighlight.Checked = false;
        }

        private void SearchColumn_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                OLVColumn col = (OLVColumn)((ToolStripMenuItem)sender).Tag;
                col.Searchable = ((ToolStripMenuItem)sender).Checked;
                col.HeaderFormatStyle = getHeaderStyle(col.Searchable);

                _Listview.Refresh();

                if (txtToSearch.Text.Trim() != string.Empty)
                    txtToSearch_KeyUp(null, null);
            }
            else
                ((ToolStripMenuItem)sender).Checked = true;
        }

        private void txtToSearch_KeyUp(object sender, KeyEventArgs e)
        {
            FilterList(_Listview, txtToSearch.Text, mnuHighlight.Checked);
        }

        private void btEraseSearch_Click(object sender, EventArgs e)
        {
            txtToSearch.Text = string.Empty;
            FilterList(_Listview, string.Empty);
        }


        private HeaderFormatStyle getHeaderStyle(bool searchable)
        {
            NormalHeader.Normal.ForeColor = SystemColors.GrayText;
            SearchableHeader.Normal.ForeColor = SystemColors.ControlText;

            return searchable ? SearchableHeader : NormalHeader;
        }

        private void FilterList(ObjectListView olv, string searchText, bool showMatching = false)
        {
            // Construct the regex to search for
            string[] SearchedString = searchText.Split('*');
            StringBuilder regex = new StringBuilder();
            //regex.Append(".*");

            foreach (string term in SearchedString)
            {
                if (term != string.Empty && Array.IndexOf(SearchedString, term) == (SearchedString.Length - 1))
                    regex.Append(term);
                else
                    regex.Append(term + ".*");
            }
            regex.Append(".*");
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^" + regex.ToString() + "$", System.Text.RegularExpressions.RegexOptions.IgnoreCase & System.Text.RegularExpressions.RegexOptions.Multiline);

            TextMatchFilter filter = null;

            if (!string.IsNullOrEmpty(searchText))
                filter = TextMatchFilter.Regex(olv, r.ToString());

            if (showMatching)
            {
                // Setup a default renderer to draw the filter matches
                if (filter == null)
                    olv.DefaultRenderer = null;
                else
                    olv.DefaultRenderer = new HighlightTextRenderer(filter);

                // Some lists have renderers already installed
                HighlightTextRenderer highlightingRenderer = olv.GetColumn(0).Renderer as HighlightTextRenderer;
                if (highlightingRenderer != null)
                    highlightingRenderer.Filter = filter;

                olv.AdditionalFilter = filter;
            }
            else
            {
                olv.DefaultRenderer = null;
                olv.AdditionalFilter = filter;
            }
        }
    }
}
