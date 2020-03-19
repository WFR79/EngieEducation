namespace SynapseCore.Controls.FormStyling
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    internal static class FormButtonStyleProperty
    {
        public const string Size = "Size";
        public const string Margin = "Margin";
        public const string NormalState = "NormalState";
        public const string ActiveState = "ActiveState";
        public const string HoverState = "HoverState";
        public const string DisabledState = "DisabledState";
    }

#if !DEBUGFORM
    [DebuggerStepThrough]
#endif
    [XmlType("buttonStyle")]
    public class FormButtonStyle : StyleObject
    {

        public FormButtonStyle()
        {
            NormalState = new SerializableImage();
            ActiveState = new SerializableImage();
            HoverState = new SerializableImage();
            DisabledState = new SerializableImage();
        }

        private Size _size;

        [XmlIgnore]
        [Description("Size of button rectangle.")]
        public Size Size
        {
            get { return _size; }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    OnPropertyChanged(FormButtonStyleProperty.Size);
                }
            }
        }

        [XmlAttribute("size")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Size_XmlSurrogate
        {
            get
            {
                if (Size != Size.Empty)
                {
                    TypeConverter SizeConverter = TypeDescriptor.GetConverter(typeof(Size));
                    return SizeConverter.ConvertToInvariantString(Size);
                }
                return null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TypeConverter SizeConverter = TypeDescriptor.GetConverter(typeof(Size));
                    Size = (Size)SizeConverter.ConvertFromInvariantString(value);
                }
                else
                    Size = Size.Empty;
            }
        }

        private Padding _margin;

        [XmlIgnore]
        [Description("Margin around button rectangle relative to title bar")]
        public Padding Margin
        {
            get { return _margin; }
            set
            {
                if (_margin != value)
                {
                    _margin = value;
                    OnPropertyChanged(FormButtonStyleProperty.Margin);
                }
            }
        }

        [XmlAttribute("margin")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Margin_XmlSurrogate
        {
            get
            {
                if (Margin != Padding.Empty)
                {
                    TypeConverter PaddingConverter = TypeDescriptor.GetConverter(typeof(Padding));
                    return PaddingConverter.ConvertToInvariantString(Margin);
                }
                return null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TypeConverter PaddingConverter = TypeDescriptor.GetConverter(typeof(Padding));
                    Margin = (Padding)PaddingConverter.ConvertFromInvariantString(value);
                }
                else
                    Margin = Padding.Empty;
            }
        }

        private SerializableImage _normalState;

        [Browsable(false)]
        [XmlElement("normalState")]
        [Description("Image used to paint button in normal state")]
        public SerializableImage NormalState
        {
            get { return _normalState; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(FormButtonStyleProperty.NormalState);

                if (_normalState != value)
                {
                    _normalState = value;
                    _normalState.Parent = this;
                    OnPropertyChanged(FormButtonStyleProperty.NormalState);
                }
            }
        }

        private SerializableImage _activeState;

        [Browsable(false)]
        [XmlElement("activeState")]
        [Description("Image used to paint button in active state")]
        public SerializableImage ActiveState
        {
            get { return _activeState; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(FormButtonStyleProperty.ActiveState);

                if (_activeState != value)
                {
                    _activeState = value;
                    _activeState.Parent = this;
                    OnPropertyChanged(FormButtonStyleProperty.ActiveState);
                }
            }
        }

        private SerializableImage _hoverState;

        [Browsable(false)]
        [XmlElement("hoverState")]
        [Description("Image used to paint button in hover state")]
        public SerializableImage HoverState
        {
            get { return _hoverState; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(FormButtonStyleProperty.HoverState);

                if (_hoverState != value)
                {
                    _hoverState = value;
                    _hoverState.Parent = this;
                    OnPropertyChanged(FormButtonStyleProperty.HoverState);
                }
            }
        }

        private SerializableImage _disabledState;

        [Browsable(false)]
        [XmlElement("disabledState")]
        [Description("Image used to paint button in disabled state")]
        public SerializableImage DisabledState
        {
            get { return _disabledState; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(FormButtonStyleProperty.DisabledState);

                if (_disabledState != value)
                {
                    _disabledState = value;
                    _disabledState.Parent = this;
                    OnPropertyChanged(FormButtonStyleProperty.DisabledState);
                }
            }
        }
    }
}