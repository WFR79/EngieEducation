namespace SynapseCore.Controls.FormStyling
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public static class FormStyleManager
    {
        static FormStyleLibrary globalStyleLibrary;

        public static void Save(string fileName)
        {
            using (Stream stream = File.Create(fileName))
            {
                Save(stream);
            }
        }

        public static void Save(Stream stream)
        {
            if (globalStyleLibrary != null)
            {
                globalStyleLibrary.Save(stream);
            }
        }

        public static void Load(string fileName)
        {
            using (Stream stream = File.OpenRead(fileName))
            {
                Load(stream);
            }
        }

        public static void Load(Stream stream)
        {
            FormStyleLibrary newLibrary = FormStyleLibrary.Load(stream);
            LoadHelper(newLibrary);
        }

        public static void Reset()
        {
            LoadHelper(null);
        }

        public static EventHandler StyleChanged;

        private static void OnStyleChanged()
        {
            if (StyleChanged != null)
                StyleChanged(null, EventArgs.Empty);
        }

        private static void LoadHelper(FormStyleLibrary newLibrary)
        {

            if (newLibrary != globalStyleLibrary)
            {
                FormStyleLibrary oldLibrary = globalStyleLibrary;
                globalStyleLibrary = newLibrary;
                OnStyleChanged();
            }
        }

        internal static FormStyle GetStyle(string styleName)
        {
            if (globalStyleLibrary != null)
            {
                foreach (FormStyle style in globalStyleLibrary.Styles)
                    if (styleName == style.Name)
                        return style;
            }

            return null;
        }

        internal static FormStyle GetDefaultStyle()
        {
            if (globalStyleLibrary != null)
                return GetStyle(globalStyleLibrary.DefaultStyleName);

            return null;
        }

        internal static string[] GetStyleNames()
        {
            List<string> styleNames = new List<string>();
            if (globalStyleLibrary != null)
            {
                foreach (FormStyle style in globalStyleLibrary.Styles)
                    styleNames.Add(style.Name);
            }
            return styleNames.ToArray();
        }

        internal static FormStyle AddNewStyle()
        {
            FormStyle style = new FormStyle();

            if (globalStyleLibrary == null)
                globalStyleLibrary = new FormStyleLibrary();

            List<string> styleNames = new List<string>(FormStyleManager.GetStyleNames());
            style.Name = "FormStyle";
            for (int i = 1; styleNames.Contains(style.Name); i++)
                style.Name = String.Format("FormStyle{0}", i);

            globalStyleLibrary.Styles.Add(style);
            OnStyleChanged();

            return style;
        }

        internal static void DeleteStyle(FormStyle style)
        {
            if (style == null)
                throw new ArgumentNullException("style");

            if (globalStyleLibrary == null)
                return;

            globalStyleLibrary.Styles.Remove(style);
            OnStyleChanged();
        }
    }
}