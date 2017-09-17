using System;

namespace nunit3_trx.Objects.VSTest
{
    public class UnitTest
    {
        public string Name { get; set; }
        public string Storage { get; set; }
        public string Id { get; set; }
        public string ClassName { get; set; }
        public TimeSpan Duration { get; set; }
        public string Outcome { get; set; }
    }
}