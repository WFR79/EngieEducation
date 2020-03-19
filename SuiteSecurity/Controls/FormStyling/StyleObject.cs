namespace SynapseCore.Controls.FormStyling
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public abstract class StyleObject : INotifyPropertyChanged
    {
        private StyleObject _parent;

        [XmlIgnore]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StyleObject Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            OnChildPropertyChanged(this, propertyName);
        }

        public event ChildPropertyChangedEventHandler ChildPropertyChanged;

        protected virtual void OnChildPropertyChanged(StyleObject subObject, string propertyName)
        {
            if (ChildPropertyChanged != null)
                ChildPropertyChanged(this, new ChildPropertyChangedEventArgs(subObject, propertyName));

            if (Parent != null)
                Parent.OnChildPropertyChanged(subObject, propertyName);
        }
    }
}