/*
 * Created by SharpDevelop.
 * User: hce339
 * Date: 21/03/2012
 * Time: 08:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SynapseAdvancedControls;
using SynapseCore.Controls;
using SynapseCore.Entities;

namespace SynapseCore.Security
{
	/// <summary>
	/// Description of Tools.
	/// </summary>
	public static class Tools
	{
        public static string[] DATETIME_PATTERNS = { "dd/MM/yyyy" };
		public static void CreateControlInDB(Int64 Module,string formName,string controlName,string controlType)
		{
            if (controlName != null && controlName.Length > 0)
            {
                SynapseControl SControl = new SynapseControl();
                SControl.CTRL_NAME = controlName;
                SControl.FORM_NAME = formName;
                SControl.CTRL_TYPE = controlType;
                SControl.FK_MODULE_ID = Module;
                SynapseForm.SynapseLogger.Debug("Creating new control in DB : "+ formName + "-" + controlName + "-" + controlType);
                SControl.save();
            }
		}
		public static StringBuilder UpdateControlsInDB(System.Windows.Forms.Control.ControlCollection controlCollection,Int64 ModuleID,Hashtable Keys)
		{
            StringBuilder SB = new StringBuilder();
            if (Keys==null)
			{
                if (controlCollection.Count > 0)
                {
                    SB.AppendLine(controlCollection[0].FindForm().Name + "=" + controlCollection[0].FindForm().Text);
                }
                Keys=new Hashtable();
				var SControlCollection = SynapseControl.Load("WHERE FK_MODULE_ID = " + ModuleID.ToString());
				foreach (SynapseControl SC in SControlCollection)
				{
                    try
                    {
                        Keys.Add(SC.FORM_NAME + SC.CTRL_NAME + SC.CTRL_TYPE, SC);
                    }
                    // TODO: Catch more specific exception
                    catch (Exception ex)
                    {
                        SynapseForm.SynapseLogger.Error(ex.Message);
                    }
				}
			}
			foreach (Control C in controlCollection)
			{
                
				string formName=C.FindForm().Name;
				string controlType=C.GetType().ToString();

                if (!Keys.ContainsKey(formName + C.Name + controlType))
                    CreateControlInDB(ModuleID, formName, C.Name, controlType);
				switch (controlType)
				{
                    case "System.Windows.Forms.Label":
                        SB.AppendLine(C.FindForm().Name + "." + C.Name + "=" + C.Text);
						break;
					case "System.Windows.Forms.Button":
                        SB.AppendLine(C.FindForm().Name + "." + C.Name + "=" + C.Text);
						break;
					case "System.Windows.Forms.MenuStrip":
						MenuStrip Menu = (MenuStrip)C;
						SB.AppendLine(ListMenuStrip(Menu.Items,C.FindForm().Name,ModuleID,Keys).ToString());
						break;
					case "System.Windows.Forms.TextBox":
						break;
					case "System.Windows.Forms.FlowLayoutPanel":
						FlowLayoutPanel FP = (FlowLayoutPanel)C;	
						SB.AppendLine(UpdateControlsInDB(FP.Controls,ModuleID, Keys).ToString());
						break;
					case "System.Windows.Forms.GroupBox":
                        SB.AppendLine(C.FindForm().Name + "." + C.Name + "=" + C.Text);
						GroupBox group = (GroupBox)C;
						SB.AppendLine(UpdateControlsInDB(group.Controls,ModuleID, Keys).ToString());
						break;
					case "System.Windows.Forms.CheckedListBox":
						break;
					case "System.Windows.Forms.CheckBox":
                        SB.AppendLine(C.FindForm().Name + "." + C.Name + "=" + C.Text);
						break;
					case "System.Windows.Forms.ToolStrip":
						ToolStrip Tool = (ToolStrip)C;
						SB.AppendLine(ListMenuStrip(Tool.Items,C.FindForm().Name,ModuleID,Keys).ToString());
						break;
                    case "System.Windows.Forms.StatusStrip":
                        StatusStrip Status = (StatusStrip)C;
                        SB.AppendLine(ListMenuStrip(Status.Items, C.FindForm().Name, ModuleID, Keys).ToString());
                        break;
                    case "System.Windows.Forms.ToolStripPanel":
                        ContainerControl mycontainer = (ContainerControl)C;
                        SB.AppendLine(UpdateControlsInDB(mycontainer.Controls, ModuleID, Keys).ToString());
                        break;
                    case "System.Windows.Forms.TabPage":
                        SB.AppendLine(C.FindForm().Name + "." + C.Name + "=" + C.Text);
                        Panel mytabpage = (Panel)C;
                        SB.AppendLine(UpdateControlsInDB(mytabpage.Controls, ModuleID, Keys).ToString());
                        break;
					case "System.Windows.Forms.Panel":
                    case "System.Windows.Forms.SplitterPanel":
                    case "System.Windows.Forms.ToolStripContentPanel":
                        Panel myPanel = (Panel)C;
                        SB.AppendLine(UpdateControlsInDB(myPanel.Controls, ModuleID, Keys).ToString());
                        break;
                    case "System.Windows.Forms.ToolStripContainer":
                        System.Windows.Forms.ToolStripContainer tscontainer = (System.Windows.Forms.ToolStripContainer)C;
                        SB.AppendLine(UpdateControlsInDB(tscontainer.Controls, ModuleID, Keys).ToString());
                        break;
                    case "System.Windows.Forms.SplitContainer":
                        System.Windows.Forms.SplitContainer mysplit = (System.Windows.Forms.SplitContainer)C;
                        SB.AppendLine(UpdateControlsInDB(mysplit.Controls, ModuleID, Keys).ToString());
                        break;
                    case "System.Windows.Forms.TabControl":
                        TabControl tabControl = (TabControl)C;
                        SB.AppendLine(UpdateControlsInDB(tabControl.Controls, ModuleID, Keys).ToString());
                        break;
                    case "System.Windows.Forms.ListView":
                        ListView liste = (ListView)C;
                        foreach (ColumnHeader Col in liste.Columns)
                        {
                            if (Col.Name != null && Col.Name != "")
                            {
                                SB.AppendLine(C.FindForm().Name + "." + C.Name + "." + Col.Name + "=" + Col.Text);
                                if (!Keys.ContainsKey(formName + C.Name + "." + Col.Name + Col.GetType().ToString()))
                                    CreateControlInDB(ModuleID, formName, C.Name + "." + Col.Name, Col.GetType().ToString());
                            }
                            else
                                SynapseForm.SynapseLogger.Warn("Column with text '" + Col.Text + "' has no name or the default one");
                        }
                        break;
					case "SynapseAdvancedControls.ObjectListView":
                        ObjectListView oliste = (ObjectListView)C;
                        SB.AppendLine("ObjectListView.MenuLabelColumns=" + oliste.MenuLabelColumns);
                        SB.AppendLine("ObjectListView.MenuLabelGroupBy=" + oliste.MenuLabelGroupBy);
                        SB.AppendLine("ObjectListView.MenuLabelLockGroupingOn=" + oliste.MenuLabelLockGroupingOn);
                        SB.AppendLine("ObjectListView.MenuLabelSelectColumns=" + oliste.MenuLabelSelectColumns);
                        SB.AppendLine("ObjectListView.MenuLabelSortAscending=" + oliste.MenuLabelSortAscending);
                        SB.AppendLine("ObjectListView.MenuLabelSortDescending=" + oliste.MenuLabelSortDescending);
                        SB.AppendLine("ObjectListView.MenuLabelTurnOffGroups=" + oliste.MenuLabelTurnOffGroups);
                        SB.AppendLine("ObjectListView.MenuLabelUnlockGroupingOn=" + oliste.MenuLabelUnlockGroupingOn);
                        SB.AppendLine("ObjectListView.MenuLabelUnsort=" + oliste.MenuLabelUnsort);
                        
                        foreach (OLVColumn Col in oliste.AllColumns)
                        {
                            if (Col.Text != null && Col.Text != "")
                            {
                                SB.AppendLine(C.FindForm().Name + "." + C.Name + "." + Col.Text.Replace(' ', '_').ToUpper() + "=" + Col.Text);
                                if (!Keys.ContainsKey(formName + C.Name + "." + Col.Text.Replace(' ', '_').ToUpper() + Col.GetType().ToString()))
                                    CreateControlInDB(ModuleID, formName, C.Name + "." + Col.Text.Replace(' ', '_').ToUpper(), Col.GetType().ToString());
                            }
                            else
                                SynapseForm.SynapseLogger.Warn("Column with text '" + Col.Text + "' has no name or the default one");
                        }
						break;
                    case "SynapseCore.Controls.SynapseGraphic":
                        SynapseGraphic graph = (SynapseGraphic)C;
                        SB.AppendLine("SynapseGraphic.CopyMenu=" + graph.CopyMenu);
                        SB.AppendLine("SynapseGraphic.CurveOnlyMenu=" + graph.CurveOnlyMenu);
                        SB.AppendLine("SynapseGraphic.CurvesMenu=" + graph.CurvesMenu);
                        SB.AppendLine("SynapseGraphic.PageSetupMenu=" + graph.PageSetupMenu);
                        SB.AppendLine("SynapseGraphic.PrintMenu=" + graph.PrintMenu);
                        SB.AppendLine("SynapseGraphic.SaveAsMenu=" + graph.SaveAsMenu);
                        SB.AppendLine("SynapseGraphic.SetDefaultScaleMenu=" + graph.SetDefaultScaleMenu);
                        SB.AppendLine("SynapseGraphic.ShowAllCurvesMenu=" + graph.ShowAllCurvesMenu);
                        SB.AppendLine("SynapseGraphic.ShowHideCurveMenu=" + graph.ShowHideCurveMenu);
                        SB.AppendLine("SynapseGraphic.ShowHideLegendMenu=" + graph.ShowHideLegendMenu);
                        SB.AppendLine("SynapseGraphic.ShowPointValuesMenu=" + graph.ShowPointValuesMenu);
                        SB.AppendLine("SynapseGraphic.UndoAllZoomMenu=" + graph.UndoAllZoomMenu);
                        SB.AppendLine("SynapseGraphic.UnZoomMenu=" + graph.UnZoomMenu);
                        
                        break;
					default:
						if (C is UserControl)
						{
						}
						break;
				}
				if (C.ContextMenuStrip!=null)
				{
                    SynapseForm.SynapseLogger.Debug("Context menu found for control '" + C.Name + "' with menu name : '"+C.ContextMenuStrip.Name+"'");
					controlType=C.ContextMenuStrip.GetType().ToString();
                    if (!Keys.ContainsKey(formName + C.ContextMenuStrip.Name + controlType))
                    {
                        CreateControlInDB(ModuleID, formName, C.ContextMenuStrip.Name, controlType);
                        Keys.Add(formName + C.ContextMenuStrip.Name + controlType, null);
                    }

					SB.AppendLine(ListMenuStrip(C.ContextMenuStrip.Items,C.FindForm().Name,ModuleID,Keys).ToString());
				}
			}
            return SB;
		}
        public enum SecureAndTranslateMode
        {
            Transalte=1,
            Secure=2
        };
			    
		public static void SecureAndTranslate(Int64 ModuleID,User UserID, System.Windows.Forms.Control.ControlCollection controlCollection,ref ResourceManager RM,bool debug,SecureAndTranslateMode Mode)
		{
			foreach (Control C in controlCollection)
			{
				bool IsActive = false;
				bool IsVisible=false;
                bool SetLabel = false;
                if (C.Name != null && C.Name.Length>0)
                {
                    IsActive = UserID.IsControlEnabledForUser(C.FindForm().Name+C.Name);
				    IsVisible = UserID.IsControlVisibleForUser(C.FindForm().Name+C.Name);
                }
                else
                {
                    IsActive=true;
                    IsVisible=true;
                }
                
                
                if ((Mode & SecureAndTranslateMode.Secure) != 0)
                {
                    C.Visible = IsVisible;
                    C.Enabled = IsActive;
                }
				switch (C.GetType().ToString())
				{
                    case "System.Windows.Forms.Label":
                        SetLabel = true;
                        break;
                    case "System.Windows.Forms.Button":
                        SetLabel = true;
						break;
					case "System.Windows.Forms.MenuStrip":
						MenuStrip Menu = (MenuStrip)C;
                        ValidateMenuStrip(ModuleID,UserID, Menu.Items, C.FindForm().Name, ref RM, debug,Mode);
						break;
					case "System.Windows.Forms.TextBox":
                        if ((Mode & SecureAndTranslateMode.Secure) != 0)
                        {
                            TextBox Edit = (TextBox)C;
                            Edit.ReadOnly = !IsActive;
                        }
						break;
					case "System.Windows.Forms.FlowLayoutPanel":
						FlowLayoutPanel FP = (FlowLayoutPanel)C;	
						SecureAndTranslate(ModuleID,UserID,FP.Controls,ref RM,debug,Mode);
						break;
					case "System.Windows.Forms.GroupBox":
                        SetLabel = true;
						GroupBox group = (GroupBox)C;
						SecureAndTranslate(ModuleID, UserID,group.Controls,ref RM,debug,Mode);
						break;
					case "System.Windows.Forms.CheckedListBox":
						break;
					case "System.Windows.Forms.CheckBox":
                        SetLabel = true;
						break;
					case "System.Windows.Forms.ToolStrip":
						ToolStrip Tool = (ToolStrip)C;
						ValidateMenuStrip(ModuleID,UserID,Tool.Items,C.FindForm().Name,ref RM,debug,Mode);
						break;
                    case "System.Windows.Forms.StatusStrip":
                        StatusStrip Status = (StatusStrip)C;
                        ValidateMenuStrip(ModuleID, UserID, Status.Items, C.FindForm().Name, ref RM, debug,Mode);
                        break;
                    case "System.Windows.Forms.ToolStripPanel":
                    
                        ContainerControl mycontainer = (ContainerControl)C;
                        SecureAndTranslate(ModuleID, UserID, mycontainer.Controls, ref RM, debug, Mode);
                        break;
                    case "System.Windows.Forms.TabPage":
                        SetLabel = true;
                        Panel mytabpage = (Panel)C;
                        SecureAndTranslate(ModuleID, UserID, mytabpage.Controls, ref RM, debug, Mode);
						break;
					case "System.Windows.Forms.Panel":
                    case "System.Windows.Forms.SplitterPanel":
                    case "System.Windows.Forms.ToolStripContentPanel":
                        Panel myPanel = (Panel)C;
                        SecureAndTranslate(ModuleID, UserID, myPanel.Controls, ref RM, debug,Mode);
						break;
                    case "System.Windows.Forms.ToolStripContainer":
                        ToolStripContainer tscontainer = (ToolStripContainer)C;
                        SecureAndTranslate(ModuleID, UserID, tscontainer.Controls, ref RM, debug, Mode);
                        break;
                    case "System.Windows.Forms.SplitContainer":
                        SplitContainer mySplit = (SplitContainer)C;
                        SecureAndTranslate(ModuleID, UserID, mySplit.Controls, ref RM, debug,Mode);
                        break;
                    case "System.Windows.Forms.TabControl":
                        TabControl tabControl = (TabControl)C;
                        SecureAndTranslate(ModuleID, UserID, tabControl.Controls, ref RM, debug,Mode);
                        break;
                    case "System.Windows.Forms.ListView":
                        ListView liste = (ListView)C;
                        foreach (ColumnHeader Col in liste.Columns)
                        {
                            string sublabel = GetLabel(ref RM, C.FindForm().Name + "." + C.Name + "." + Col.Name, debug);
                            if (((Mode & SecureAndTranslateMode.Transalte) != 0) && sublabel != null && sublabel != string.Empty && sublabel.Length > 0)
                                Col.Text = sublabel;
                            if ((Mode & SecureAndTranslateMode.Secure) != 0)
                            {

                            }
                        }
                        break;
                    case "SynapseAdvancedControls.ObjectListView":
                        ObjectListView oliste = (ObjectListView)C;

                        oliste.MenuLabelColumns=GetLabel(ref RM,"ObjectListView.MenuLabelColumns",debug);
                        oliste.MenuLabelGroupBy=GetLabel(ref RM,"ObjectListView.MenuLabelColumns",debug);
                        oliste.MenuLabelLockGroupingOn=GetLabel(ref RM,"ObjectListView.MenuLabelLockGroupingOn",debug);
                        oliste.MenuLabelSelectColumns=GetLabel(ref RM,"ObjectListView.MenuLabelSelectColumns",debug);
                        oliste.MenuLabelSortAscending=GetLabel(ref RM,"ObjectListView.MenuLabelSortAscending",debug);
                        oliste.MenuLabelSortDescending=GetLabel(ref RM,"ObjectListView.MenuLabelSortDescending",debug);
                        oliste.MenuLabelTurnOffGroups=GetLabel(ref RM,"ObjectListView.MenuLabelTurnOffGroups",debug);
                        oliste.MenuLabelUnlockGroupingOn=GetLabel(ref RM,"ObjectListView.MenuLabelUnlockGroupingOn",debug);
                        oliste.MenuLabelUnsort=GetLabel(ref RM,"ObjectListView.MenuLabelUnsort",debug);

                        foreach (OLVColumn Col in oliste.AllColumns)
                        {
                            string sublabel = GetLabel(ref RM, C.FindForm().Name + "." + C.Name + "." + Col.Text.Replace(' ', '_').ToUpper(), debug);

                            if ((Mode & SecureAndTranslateMode.Secure) != 0)
                            {
                                bool CIsActive = UserID.IsControlEnabledForUser(C.FindForm().Name +  C.Name + "." + Col.Text.Replace(' ', '_').ToUpper());
                                bool CIsVisible = UserID.IsControlVisibleForUser(C.FindForm().Name +  C.Name + "." + Col.Text.Replace(' ', '_').ToUpper());

                                Col.IsVisible = CIsVisible;
                     
                                Col.IsEditable = CIsActive;
                            }
                            if (((Mode & SecureAndTranslateMode.Transalte) != 0) && sublabel != null && sublabel != string.Empty && sublabel.Length > 0)
                                Col.Text = sublabel;
                        }
                        oliste.RebuildColumns();
                        break;
                    case "SynapseCore.Controls.SynapseGraphic":
                        SynapseGraphic graph = (SynapseGraphic)C;
                        graph.CopyMenu=GetLabel(ref RM,"SynapseGraphic.CopyMenu",debug);
                        graph.CurveOnlyMenu=GetLabel(ref RM,"SynapseGraphic.CurveOnlyMenu",debug);
                        graph.CurvesMenu=GetLabel(ref RM,"SynapseGraphic.CurvesMenu",debug);
                        graph.PageSetupMenu=GetLabel(ref RM,"SynapseGraphic.PageSetupMenu",debug);
                        graph.PrintMenu=GetLabel(ref RM,"SynapseGraphic.PrintMenu",debug);
                        graph.SaveAsMenu=GetLabel(ref RM,"SynapseGraphic.SaveAsMenu",debug);
                        graph.SetDefaultScaleMenu=GetLabel(ref RM,"SynapseGraphic.SetDefaultScaleMenu",debug);
                        graph.ShowAllCurvesMenu=GetLabel(ref RM,"SynapseGraphic.ShowAllCurvesMenu",debug);
                        graph.ShowHideCurveMenu=GetLabel(ref RM,"SynapseGraphic.ShowHideCurveMenu",debug);
                        graph.ShowHideLegendMenu=GetLabel(ref RM,"SynapseGraphic.ShowHideLegendMenu",debug);
                        graph.ShowPointValuesMenu=GetLabel(ref RM,"SynapseGraphic.ShowPointValuesMenu",debug);
                        graph.UndoAllZoomMenu=GetLabel(ref RM,"SynapseGraphic.UndoAllZoomMenu",debug);
                        graph.UnZoomMenu=GetLabel(ref RM,"SynapseGraphic.UnZoomMenu",debug);
                        
                        break;
					default:
						if (C is UserControl)
						{
                            if ((Mode & SecureAndTranslateMode.Secure) != 0)
                            {
                                C.Enabled = IsActive;
                                C.Visible = IsVisible;
                            }
						}
						break;
				}
                if (((Mode & SecureAndTranslateMode.Transalte) != 0)  && SetLabel)
                {
                    string label = GetLabel(ref RM, C.FindForm().Name + "." + C.Name, debug);
                    if (label != null && label != string.Empty && label.Length > 0)
                        C.Text = label;
                }
				if (C.ContextMenuStrip!=null)
				{
                    ValidateMenuStrip(ModuleID,UserID, C.ContextMenuStrip.Items, C.FindForm().Name, ref RM, debug,Mode);
				}
				
				if (debug)
				{	
                    System.Windows.Forms.ToolTip ToolTip = new System.Windows.Forms.ToolTip();
                    ToolTip.ToolTipTitle = "Synapse Security";
                    ToolTip.UseFading = true;
                    ToolTip.UseAnimation = true;
                    ToolTip.IsBalloon = true;
                    ToolTip.ShowAlways = true;
                    ToolTip.AutoPopDelay = 5000;
                    ToolTip.InitialDelay = 500;
                    ToolTip.ReshowDelay = 100;
                    ToolTip.SetToolTip(C, C.FindForm().Name+"\n"+ C.Name+"\n"+GetControlGroups(ModuleID, C.FindForm().Name, C.Name));
				}                
			}
		}

        public static string GetControlGroups(Int64 ModuleID, string formName, string controlName)
        {
            string query = "SELECT     dbo.Synapse_Security_Profile.ID, dbo.Synapse_Security_Profile.FK_MODULEID, dbo.Synapse_Security_Profile.FK_LABELID, " +
                      "dbo.Synapse_Security_Profile.TECHNICALNAME, dbo.Synapse_Security_Profile.IS_OWNER, dbo.Synapse_Security_Profile.[LEVEL] " +
                        "FROM         dbo.Synapse_Security_Control INNER JOIN " +
                      "dbo.[Synapse_Security_Profile Control] ON dbo.Synapse_Security_Control.ID = dbo.[Synapse_Security_Profile Control].FK_CONTROLID INNER JOIN " +
                      "dbo.Synapse_Security_Profile ON dbo.[Synapse_Security_Profile Control].FK_PROFILEID = dbo.Synapse_Security_Profile.ID";
            string groups = string.Empty;
            IList<SynapseProfile> ctrl_security = SynapseProfile.LoadFromQuery(query + " WHERE FK_MODULE_ID = " + ModuleID + " AND FORM_NAME = '" + formName + "' AND CTRL_NAME = '" + controlName + "'");
            foreach (SynapseProfile P in ctrl_security)
            { 
               if (!groups.Contains(P.TECHNICALNAME+"/"))
                   groups+=P.TECHNICALNAME+"/";
            }
            if (groups == string.Empty)
                return "Everybody";
            else
                return groups;
        }

		public static void ValidateMenuStrip(Int64 ModuleID, User UserID, ToolStripItemCollection Items,string FormName,ref ResourceManager RM,bool debug,SecureAndTranslateMode Mode)
		{
			foreach (ToolStripItem ts_item in Items)
			{
				string label=GetLabel(ref RM, FormName+"."+ts_item.Name,debug);
                if (((Mode & SecureAndTranslateMode.Transalte) != 0) && label != null && label != string.Empty && label.Length > 0)
                    ts_item.Text = label;
                if ((Mode & SecureAndTranslateMode.Secure) != 0)
                {
                    ts_item.Enabled = UserID.IsControlEnabledForUser(FormName + ts_item.Name);
                    ts_item.Visible = UserID.IsControlVisibleForUser(FormName + ts_item.Name);
                }
				if (ts_item is ToolStripDropDownItem)
				{
					ToolStripDropDownItem tsdd_item = (ToolStripDropDownItem)ts_item;
					ValidateMenuStrip(ModuleID,UserID, tsdd_item.DropDownItems,FormName,ref RM,debug,Mode);
				}
				if (debug)
				{
                    ts_item.ToolTipText = ts_item.Name+":"+GetControlGroups(ModuleID, FormName, ts_item.Name);                   
				}
			}
		}
		public static StringBuilder ListMenuStrip(ToolStripItemCollection Items,string FormName,Int64 ModuleID,Hashtable Keys)
		{            
            StringBuilder SB = new StringBuilder();
			foreach (ToolStripItem ts_item in Items)
			{
				if (ts_item is ToolStripDropDownItem)
				{                    
					string controlType=ts_item.GetType().ToString();
					if (!Keys.ContainsKey(FormName+ts_item.Name+controlType))
							CreateControlInDB(ModuleID,FormName,ts_item.Name,controlType);					
					ToolStripDropDownItem tsdd_item = (ToolStripDropDownItem)ts_item;
					SB.AppendLine(ListMenuStrip(tsdd_item.DropDownItems,FormName,ModuleID,Keys).ToString());
				}
				else
				{
					string controlType=ts_item.GetType().ToString();
					if (!Keys.ContainsKey(FormName+ts_item.Name+controlType))
							CreateControlInDB(ModuleID,FormName,ts_item.Name,controlType);
				}
                if (!(ts_item is ToolStripSeparator))
                {
                    SB.AppendLine(FormName + "." + ts_item.Name + "=" + ts_item.Text);
                }
			}
            return SB;
		}

        public static void SetCulture(string culture)
        { 
            CultureInfo objCI = new CultureInfo(culture);
            objCI.DateTimeFormat.SetAllDateTimePatterns(DATETIME_PATTERNS, 'd');
            Thread.CurrentThread.CurrentCulture = objCI;
            Thread.CurrentThread.CurrentUICulture = objCI;
        }

        public static string GetLabel(ref ResourceManager RM,string ResourceName,bool debug)
        {
            string label;
            try
            {
                label = RM.GetString(ResourceName);

                if (label == null && debug)
                    label = "<UNKNOWN:" + ResourceName + ">";
                if (label == null && !debug)
                    label = "";
            }
            // TODO: Catch more specific exception
            catch (Exception ex)
            {
                return ResourceName;
            }
            return label;
        }
	}
}
