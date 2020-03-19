namespace SynapseCore.Controls.FormStyling
{
    using System.ComponentModel;

    public class ChildPropertyChangedEventArgs : PropertyChangedEventArgs
    {
        private StyleObject _subObject;
        public StyleObject SubObject
        {
            get { return _subObject; }
        }

        public ChildPropertyChangedEventArgs(StyleObject subObject, string propertyName)
            : base(propertyName)
        {
            _subObject = subObject;
        }
    }

    public delegate void ChildPropertyChangedEventHandler(object sender, ChildPropertyChangedEventArgs args);
}
