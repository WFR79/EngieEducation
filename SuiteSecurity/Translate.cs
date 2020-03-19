/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 22-05-2012
 * Time: 10:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace SynapseCore
{
	/// <summary>
	/// Description of Translate.
	/// </summary>
	public static class Translate
	{
		public static void TranslateC(Control.ControlCollection CCollection)
		{
			foreach (Control C in CCollection)
			{
				C.Text="T_"+C.Text;
			
			}
		}
	}
}
