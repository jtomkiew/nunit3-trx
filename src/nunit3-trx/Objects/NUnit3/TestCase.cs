using System.Collections.Generic;
using nunit3_trx.Attributes;

namespace nunit3_trx.Objects.NUnit3
{
    /// <summary>
    ///     https://github.com/nunit/docs/wiki/Test-Result-XML-Format#test-case
    /// </summary>
    public class TestCase
    {
        [XmlAttributeName("id")]
        public string Id { get; set; }

        [XmlAttributeName("name")]
        public string Name { get; set; }

        [XmlAttributeName("fullname")]
        public string FullName { get; set; }

        [XmlAttributeName("methodname")]
        public string MethodName { get; set; }

        [XmlAttributeName("classname")]
        public string ClassName { get; set; }

        [XmlAttributeName("runstate")]
        public string RunState { get; set; }

        [XmlAttributeName("seed")]
        public string Seed { get; set; }

        [XmlAttributeName("result")]
        public string Result { get; set; }

        [XmlAttributeName("label")]
        public string Label { get; set; }

        [XmlAttributeName("site")]
        public string Site { get; set; }

        [XmlAttributeName("start-time")]
        public string StartTime { get; set; }

        [XmlAttributeName("end-time")]
        public string EndTime { get; set; }

        [XmlAttributeName("duration")]
        public string Duration { get; set; }

        [XmlAttributeName("asserts")]
        public string Asserts { get; set; }

        public List<string> Attachments { get; set; }
    }
}