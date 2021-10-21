using System;

namespace AnzolinNetDevPack.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class BadgeStyleAttribute : Attribute
    {
        private readonly string textColorClass;
        private readonly string backgroundColorClass;

        public BadgeStyleAttribute(string textColorClass, string backgroundColorClass)
        {
            this.textColorClass = textColorClass;
            this.backgroundColorClass = backgroundColorClass;
        }

        public virtual string TextColorClass
        {
            get { return textColorClass; }
        }

        public virtual string BackgroundColorClass
        {
            get { return backgroundColorClass; }
        }
    }
}
