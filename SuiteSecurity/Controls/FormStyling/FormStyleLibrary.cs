namespace SynapseCore.Controls.FormStyling
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    [System.Xml.Serialization.XmlRoot("styleLibrary")]
    internal class FormStyleLibrary : StyleObject
    {
        private List<FormStyle> _styles = new List<FormStyle>();

        [XmlArray("styles")]
        [Description("List of styles contained in this library")]
        public List<FormStyle> Styles
        {
            get { return _styles; }
        }

        private string _version = "1.0";

        [XmlAttribute("schemaVersion")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("Version of Xml Schema the style library was saved")]
        public string SchemaVersion
        {
            get { return _version; }
            set { _version = value; }
        }


        private string _defaultStyleName = "Default";

        [XmlAttribute("defaultStyleName")]
        [Description("Name of default style in this library")]
        public string DefaultStyleName
        {
            get { return _defaultStyleName; }
            set
            {
                _defaultStyleName = value;
            }
        }

        internal static FormStyleLibrary Load(Stream stream)
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FormStyleLibrary));
                FormStyleLibrary library = (FormStyleLibrary)serializer.Deserialize(reader);
                return library;
            }
        }

        internal void Save(Stream stream)
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;

            using (XmlWriter wr = XmlWriter.Create(stream, set))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FormStyleLibrary));
                serializer.Serialize(wr, this);
            }
        }
    }
}
