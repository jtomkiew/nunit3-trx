using System.Collections.Generic;
using System.Xml;
using nunit3_trx.Helpers;
using nunit3_trx.Objects.NUnit3;
using XmlFluent;

namespace runner
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const string sourceXml = @"C:\Users\incognito\Desktop\nunit\TestResult.xml";

            var xml = new XmlDocument();
            xml.Load(sourceXml);
            var testNodes = xml.GetElementsByTagName("test-case");
            var nuTestList = new List<TestCase>();
            for (var i = 0; i < testNodes.Count; i++)
            {
                var node = testNodes.Item(i);
                var test = new TestCase();
                NUnit3TestHelper.NodeAttributeExtractor(node, test);
                test.Attachments = NUnit3TestHelper.GetAttachments(node);
                nuTestList.Add(test);
            }

            var vsXml = XmlFluentDocument.New()
                .RootNode("TestRun", r => r
                    .Attribute("id", "ID_VALUE")
                    .Attribute("name", "NAME_VALUE")
                    .Attribute("runUser", "RUNUSER_VALUE")
                    .Attribute("xmlns", "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")).In(r => r
                    .Node("Times", n => n
                        .Attribute("creation", "CREATION_VALUE")
                        .Attribute("queuing", "QUEUING_VALUE")
                        .Attribute("start", "START_VALUE")
                        .Attribute("finish", "FINISH_VALUE"))
                    .Node("TestSettings").In(n => n
                        .Node("Deployment"))
                    .Node("Results").In(n => n
                        .Node("UnitTestResult")));
            vsXml.GetXmlDocument().Save(@"C:\Users\incognito\Desktop\nunit\VsTestResult.xml");
        }
    }
}