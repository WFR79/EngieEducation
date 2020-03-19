namespace SynapseCore.Controls.FormStyling
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;

#if !DEBUGFORM
    [DebuggerStepThrough]
#endif
    [XmlType("formStyle")]
    internal sealed class FormStyle : StyleObject
    {        
        public FormStyle()
        {
            NormalState = new SerializableImage();
            MinimizeButton = new FormButtonStyle();
            MaximizeButton = new FormButtonStyle();
            CloseButton = new FormButtonStyle();
            RestoreButton = new FormButtonStyle();
            HelpButton = new FormButtonStyle();
        }

        private string _name;

        [XmlAttribute("name")]
        [Description("Name used to indentify this style in the library")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException(FormStyleProperty.Name);

                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(FormStyleProperty.Name);
                }
            }
        }

        private Padding _clientAreaPadding;

        [XmlIgnore]
        [Description("Padding of the client rectangle relative to window bounds")]
        public Padding ClientAreaPadding
        {
            get { return _clientAreaPadding; }
            set
            {
                if (_clientAreaPadding != value)
                {
                    _clientAreaPadding = value;
                    OnPropertyChanged(FormStyleProperty.ClientAreaPadding);
                }
            }
        }

        [XmlAttribute("clientAreaPadding")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ClientAreaPadding_XmlSurrogate
        {
            get
            {
                if (ClientAreaPadding != Padding.Empty)
                {
                    TypeConverter PaddingConverter = TypeDescriptor.GetConverter(typeof(Padding));
                    return PaddingConverter.ConvertToInvariantString(ClientAreaPadding);
                }
                return null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TypeConverter PaddingConverter = TypeDescriptor.GetConverter(typeof(Padding));
                    ClientAreaPadding = (Padding)PaddingConverter.ConvertFromInvariantString(value);
                }
                else
                    ClientAreaPadding = Padding.Empty;
            }
        }

        private Padding _iconPadding;

        [XmlIgnore]
        [Description("Padding of icon rectangle relative to top-left corner of title bar")]
        public Padding IconPadding
        {
            get { return _iconPadding; }
            set
            {
                if (_iconPadding != value)
                {
                    _iconPadding = value;
                    OnPropertyChanged(FormStyleProperty.IconPadding);
                }
            }
        }

        [XmlAttribute("iconPadding")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IconPadding_XmlSurrogate
        {
            get
            {
                if (IconPadding != Padding.Empty)
                {
                    TypeConverter PaddingConverter = TypeDescriptor.GetConverter(typeof(Padding));
                    return PaddingConverter.ConvertToInvariantString(IconPadding);
                }
                return null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TypeConverter PaddingConverter = TypeDescriptor.GetConverter(typeof(Padding));
                    IconPadding = (Padding)PaddingConverter.ConvertFromInvariantString(value);
                }
                else
                    IconPadding = Padding.Empty;
            }
        }

        private Padding _titlePadding;

        [XmlIgnore]
        [Description("Padding of the title rectangle relative to rectangle of title bar")]
        public Padding TitlePadding
        {
            get { return _titlePadding; }
            set
            {
                if (_titlePadding != value)
                {
                    _titlePadding = value;
                    OnPropertyChanged(FormStyleProperty.TitlePadding);
                }
            }
        }

        [XmlAttribute("titlePadding")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TitlePadding_XmlSurrogate
        {
            get
            {
                if (TitlePadding != Padding.Empty)
                {
                    TypeConverter PaddingConverter = TypeDescriptor.GetConverter(typeof(Padding));
                    return PaddingConverter.ConvertToInvariantString(TitlePadding);
                }
                return null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TypeConverter PaddingConverter = TypeDescriptor.GetConverter(typeof(Padding));
                    TitlePadding = (Padding)PaddingConverter.ConvertFromInvariantString(value);
                }
                else
                    TitlePadding = Padding.Empty;
            }
        }

        private Font _titleFont;

        [XmlIgnore]
        [Description("Font used to paint window title")]
        public Font TitleFont
        {
            get { return _titleFont; }
            set
            {
                if (_titleFont != value)
                {
                    _titleFont = value;
                    OnPropertyChanged(FormStyleProperty.TitleFont);
                }
            }
        }

        [XmlAttribute("titleFont")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TitleFont_XmlSurrogate
        {
            get
            {
                if (TitleFont != null)
                {
                    TypeConverter FontConverter = TypeDescriptor.GetConverter(typeof(Font));
                    return FontConverter.ConvertToInvariantString(TitleFont);
                }
                else
                    return null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TypeConverter FontConverter = TypeDescriptor.GetConverter(typeof(Font));
                    TitleFont = (Font)FontConverter.ConvertFromInvariantString(value);
                }
                else
                    TitleFont = null;
            }
        }

        private Color _titleColor;

        [XmlIgnore]
        [Description("Color used to paint window title")]
        public Color TitleColor
        {
            get { return _titleColor; }
            set
            {
                if (_titleColor != value)
                {
                    _titleColor = value;
                    OnPropertyChanged(FormStyleProperty.TitleColor);
                }
            }
        }

        [XmlAttribute("titleColor")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TitleColor_XmlSurrogate
        {
            get
            {
                if (TitleColor != Color.Empty)
                {
                    TypeConverter ColorConverter = TypeDescriptor.GetConverter(typeof(Color));
                    return ColorConverter.ConvertToInvariantString(TitleColor);
                }
                else
                    return null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TypeConverter ColorConverter = TypeDescriptor.GetConverter(typeof(Color));
                    TitleColor = (Color)ColorConverter.ConvertFromInvariantString(value);
                }
                else
                    TitleColor = Color.Empty;
            }
        }


        private Color _titleShadowColor;

        [XmlIgnore]
        [Description("Color used to draw drop shadow behind window title")]
        public Color TitleShadowColor
        {
            get { return _titleShadowColor; }
            set
            {
                if (_titleShadowColor != value)
                {
                    _titleShadowColor = value;
                    OnPropertyChanged(FormStyleProperty.TitleShadowColor);
                }
            }
        }

        [XmlAttribute("titleShadowColor")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TitleShadowColor_XmlSurrogate
        {
            get
            {
                if (TitleShadowColor != Color.Empty)
                {
                    TypeConverter ColorConverter = TypeDescriptor.GetConverter(typeof(Color));
                    return ColorConverter.ConvertToInvariantString(TitleShadowColor);
                }
                else
                    return null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TypeConverter ColorConverter = TypeDescriptor.GetConverter(typeof(Color));
                    TitleShadowColor = (Color)ColorConverter.ConvertFromInvariantString(value);
                }
                else
                    TitleShadowColor = Color.Empty;
            }
        }


        private int _sizingBorderWidth = 3;

        [XmlAttribute("sizingBorderWidth")]
        [Description("Offset from window border where window can be sized using a mouse horizontaly or verically")]
        public int SizingBorderWidth
        {
            get { return _sizingBorderWidth; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("SizingBorderWidth", "Sizing offset must be greater then zero.");

                if (_sizingBorderWidth != value)
                {
                    _sizingBorderWidth = value;
                    OnPropertyChanged(FormStyleProperty.SizingBorderWidth);
                }
            }
        }

        private int _sizingCornerOffset = 16;

        [XmlAttribute("sizingBorderOffset")]
        [Description("Offset from window corner where form can be sized in both directions")]
        public int SizingCornerOffset
        {
            get { return _sizingCornerOffset; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("SizingCornerOffset", "Sizing offset must be greater then zero.");

                if (_sizingCornerOffset != value)
                {
                    _sizingCornerOffset = value;
                    OnPropertyChanged(FormStyleProperty.SizingCornerOffset);
                }
            }
        }

        private SerializableImage _normalState;

        [XmlElement("normalState")]
        [Browsable(false)]
        [Description("Image used to paint background on forms non client area")]
        public SerializableImage NormalState
        {
            get { return _normalState; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("NormalState");

                if (_normalState != value)
                {
                    _normalState = value;
                    _normalState.Parent = this;
                    OnPropertyChanged(FormStyleProperty.NormalState);
                }
            }
        }

        private FormButtonStyle _minimizeButton;

        [XmlElement("minimizeButton")]
        [Browsable(false)]
        [Description("Style for window minimize button")]
        public FormButtonStyle MinimizeButton
        {
            get { return _minimizeButton; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("MinimizeButton");

                if (_minimizeButton != value)
                {
                    _minimizeButton = value;
                    _minimizeButton.Parent = this;
                    OnPropertyChanged(FormStyleProperty.MinimizeButton);
                }
            }
        }

        private FormButtonStyle _maximizeButton;

        [XmlElement("maximizeButton")]
        [Browsable(false)]
        [Description("Style for window maximize button")]
        public FormButtonStyle MaximizeButton
        {
            get { return _maximizeButton; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("MaximizeButton");

                if (_maximizeButton != value)
                {
                    _maximizeButton = value;
                    _maximizeButton.Parent = this;
                    OnPropertyChanged(FormStyleProperty.MaximizeButton);
                }
            }
        }

        private FormButtonStyle _closeButton;

        [XmlElement("closeButton")]
        [Browsable(false)]
        [Description("Style for window close button")]
        public FormButtonStyle CloseButton
        {
            get { return _closeButton; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("CloseButton");

                if (_closeButton != value)
                {
                    _closeButton = value;
                    _closeButton.Parent = this;
                    OnPropertyChanged(FormStyleProperty.CloseButton);
                }
            }
        }

        private FormButtonStyle _restoreButton;

        [XmlElement("restoreButton")]
        [Browsable(false)]
        [Description("Style for window restore button")]
        public FormButtonStyle RestoreButton
        {
            get { return _restoreButton; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("RestoreButton");

                if (_restoreButton != value)
                {
                    _restoreButton = value;
                    _restoreButton.Parent = this;
                    OnPropertyChanged(FormStyleProperty.RestoreButton);
                }
            }
        }

        private FormButtonStyle _helpButton;

        [XmlElement("helpButton")]
        [Browsable(false)]
        [Description("Style for window help button")]
        public FormButtonStyle HelpButton
        {
            get { return _helpButton; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("HelpButton");

                if (_helpButton != value)
                {
                    _helpButton = value;
                    _helpButton.Parent = this;
                    OnPropertyChanged(FormStyleProperty.HelpButton);
                }
            }
        }
    }
}