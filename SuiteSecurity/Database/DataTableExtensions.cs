namespace SynapseCore.Database
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using SynapseCore.Entities;

    public static class DataTableExtensions
    {
        public static IList<T> ToListOfEntities<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateEntityFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        public static IList<T> ToListOfEntities<T>(this DataTable table, Dictionary<string, string> mappings) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateEntityFromRow<T>((DataRow)row, properties, mappings);
                result.Add(item);
            }

            return result;
        }

        public static T ToEntity<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties();
            if (table.Rows.Count > 0)
            {
                return CreateEntityFromRow<T>(table.Rows[0], properties);
            }
            else
                return new T();
        }

        private static T CreateEntityFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (row.Table.Columns.Contains(property.Name) && row[property.Name] != DBNull.Value)
                    property.SetValue(item, row[property.Name], null);
            }
            foreach (var property in from x in properties where x.PropertyType.ToString() == "SynapseCore.Database.LabelBag" select x)
            {
                if (property.PropertyType.ToString() == "SynapseCore.Database.LabelBag")
                {
                    Int64 labelID = 0;
                    string DefaultText = null;
                    LabelId[] ids = (LabelId[])property.GetCustomAttributes(typeof(LabelId), true);
                    foreach (LabelId id in ids)
                    {
                        PropertyInfo field = item.GetType().GetProperty(id.IDField);
                        labelID = (Int64)field.GetValue(item, null);
                        if (id.DefaultField != null)
                        {
                            PropertyInfo defaultfield = item.GetType().GetProperty(id.DefaultField);
                            DefaultText = (string)defaultfield.GetValue(item, null);
                        }
                    }

                    LabelBag label = new LabelBag();
                    label.load(labelID, DefaultText);
                    property.SetValue(item, label, null);
                }
            }
            if (item is SynapseEntity<T>)
            {
                item.GetType().InvokeMember("ComputeHash", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, item, null);
            }
            return item;
        }

        private static T CreateEntityFromRow<T>(DataRow row, IList<PropertyInfo> properties, Dictionary<string, string> mappings) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (mappings.ContainsKey(property.Name))
                    property.SetValue(item, row[mappings[property.Name]], null);
            }
            return item;
        }
    }
}
