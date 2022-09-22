using System;

namespace AnzolinNetDevPack.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class CustomBadgeColorAttribute : Attribute
    {
        private readonly string _textColorHexCode;
        private readonly string _backgroundColorHexCode;

        public CustomBadgeColorAttribute(string textColorHexCode, string backgroundColorHexCode)
        {
            _textColorHexCode = textColorHexCode;
            _backgroundColorHexCode = backgroundColorHexCode;
        }

        public virtual string TextColorHexCode
        {
            get { return _textColorHexCode; }
        }

        public virtual string BackgroundColorHexCode
        {
            get { return _backgroundColorHexCode; }
        }
    }
}
