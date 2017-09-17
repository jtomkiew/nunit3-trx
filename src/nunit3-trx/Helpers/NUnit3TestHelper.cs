using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using nunit3_trx.Attributes;
using nunit3_trx.Extensions;

namespace nunit3_trx.Helpers
{
    public class NUnit3TestHelper
    {
        /// <summary>
        ///     Modyfies target object.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="node"></param>
        /// <param name="target"></param>
        public static void NodeAttributeExtractor<TType>(XmlNode node, TType target)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (target == null) throw new ArgumentNullException(nameof(target));

            var props = typeof(TType).GetProperties().Where(p => p.HasAttribute(typeof(XmlAttributeNameAttribute)));
            foreach (var property in props)
            {
                // ReSharper disable once PossibleNullReferenceException
                var attributeValue = node.Attributes[GetXmlAttributeName(property)]?.Value;
                property.SetMethod.Invoke(target, new object[] {attributeValue});
            }
        }

        private static string GetXmlAttributeName(PropertyInfo property)
        {
            var attribute =
                (XmlAttributeNameAttribute) Attribute.GetCustomAttribute(property, typeof(XmlAttributeNameAttribute));

            if (attribute == null)
                throw new InvalidOperationException("The attribute was not found.");

            return attribute.Name;
        }

        public static List<string> GetAttachments(XmlNode node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            var attachmentFilePaths = new List<string>();

            if (!node.HasChildNodes)
                return attachmentFilePaths;

            var attachmentFilePathNodes = node.SelectNodes("//attachment/filePath");
            if (attachmentFilePathNodes == null)
                return attachmentFilePaths;

            for (var i = 0; i < attachmentFilePathNodes.Count; i++)
                attachmentFilePaths.Add(attachmentFilePathNodes[i].InnerText);
            return attachmentFilePaths;
        }
    }
}