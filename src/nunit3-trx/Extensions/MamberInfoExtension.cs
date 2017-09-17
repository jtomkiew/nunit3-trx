using System;
using System.Reflection;

namespace nunit3_trx.Extensions
{
    public static class MamberInfoExtension
    {
        public static bool HasAttribute(this MemberInfo infoObject, Type attributeType)
        {
            return infoObject.GetCustomAttribute(attributeType) != null;
        }
    }
}