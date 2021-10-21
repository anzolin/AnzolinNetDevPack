using System;

namespace AnzolinNetDevPack.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class BackgroundStyleAttribute : Attribute
    {
        private readonly string backgroundColorClass;

        public BackgroundStyleAttribute(string backgroundColorClass)
        {
            this.backgroundColorClass = backgroundColorClass;
        }

        public virtual string BackgroundColorClass
        {
            get { return backgroundColorClass; }
        }
    }
}
