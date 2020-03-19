namespace SynapseCore.Controls.FormStyling
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    internal static class SerializableImageProperty
    {
        public const string SizeMode = "SizeMode";
        public const string StretchMargins = "StretchMargins";
        public const string Image = "Image";
    }

    public sealed class SerializableImage : StyleObject
    {
        private ImageSizeMode _sizeMode;

        [XmlAttribute("sizeMode")]
        public ImageSizeMode SizeMode
        {
            get { return _sizeMode; }
            set
            {
                if (_sizeMode != value)
                {
                    _sizeMode = value;
                    OnPropertyChanged(SerializableImageProperty.SizeMode);
                }
            }
        }

        private Padding _stretchMargins;

        [XmlIgnore]
        public Padding StretchMargins
        {
            get { return _stretchMargins; }
            set
            {
                if (_stretchMargins != value)
                {
                    _stretchMargins = value;
                    OnPropertyChanged(SerializableImageProperty.StretchMargins);
                }
            }
        }

        [XmlAttribute("stretchMargins")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string StretchMargins_XmlSurrogate
        {
            get
            {
                if (StretchMargins != Padding.Empty)
                {
                    TypeConverter PaddingConverter = TypeDescriptor.GetConverter(typeof(Padding));
                    return PaddingConverter.ConvertToInvariantString(StretchMargins);
                }
                return null;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TypeConverter PaddingConverter = TypeDescriptor.GetConverter(typeof(Padding));
                    StretchMargins = (Padding)PaddingConverter.ConvertFromInvariantString(value);
                }
                else
                    StretchMargins = Padding.Empty;
            }
        }

        private Bitmap _image;

        [XmlIgnore]
        public Bitmap Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(SerializableImageProperty.Image);
                }
            }
        }

        [XmlElement("image")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] Image_XmlSurrogate
        {
            get
            {
                if (Image != null)
                {
                    TypeConverter BitmapConverter =
                        TypeDescriptor.GetConverter(Image.GetType());
                    return (byte[])BitmapConverter.ConvertTo(Image, typeof(byte[]));
                }
                else
                    return null;
            }
            set
            {
                if (value != null)
                    Image = new Bitmap(new MemoryStream(value));
                else
                    Image = null;
            }
        }

        public void DrawImage(Graphics g, Rectangle destRect)
        {
            if (Image == null)
                return;

            DrawUtil.DrawImage(g, Image, destRect, SizeMode, StretchMargins);
        }
    }
}
