using System;

namespace nunit3_trx.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XmlAttributeNameAttribute : Attribute
    {
        public string Name;

        public XmlAttributeNameAttribute(string name)
        {
            Name = name;
        }
    }
}