using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace SynapseDeploymentTool
{
    public static class extensionsentity
    {
        public static Int64 PrdID<T>(this SynapseCore.Entities.SynapseEntity<T> entity, IList<ACCTOPRD> list) where T : new()
        {
            Type objectType = typeof(T);
            FieldInfo IDproperty = objectType.GetField("_IDproperty", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            PropertyInfo IDField = objectType.GetProperty(IDproperty.GetValue(null).ToString());
            Int64 ID = Convert.ToInt64(IDField.GetValue(entity, null));
            IList<ACCTOPRD> result = (from i in list where i.ACCID == ID && i.OBJECTTYPE==objectType.Name select i).ToList();
            if (result != null && result.Count > 0)
                return result.FirstOrDefault().PRDID;
            return 0;
        }

        public static Int64 ConvertID(this IList<ACCTOPRD> list, Type otype, Int64 AccID)
        {
            IList<ACCTOPRD> filtered = (from i in list where i.OBJECTTYPE == otype.Name && i.ACCID == AccID select i).ToList();
            if (filtered.Count != 1 )
            {
                throw new MissingFieldException("ID not found");
            }
            else
            {
                if (filtered.FirstOrDefault().PRDID == 0)
                    throw new KeyNotFoundException("object seems to have not been saved");
                else
                    return filtered.FirstOrDefault().PRDID;
            }
        }
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
