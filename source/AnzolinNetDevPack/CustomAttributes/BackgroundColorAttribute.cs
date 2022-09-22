using System;

namespace AnzolinNetDevPack.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class BackgroundColorAttribute : Attribute
    {
        private readonly string _backgroundColorHexCode;

        public BackgroundColorAttribute(string backgroundColorHexCode)
        {
            _backgroundColorHexCode = backgroundColorHexCode;
        }

        public virtual string BackgroundColorHexCode
        {
            get { return _backgroundColorHexCode; }
        }
    }
}
