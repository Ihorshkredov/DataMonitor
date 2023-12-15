namespace DataMonitor.DataModels
{
	public class Test
	{
        public DateTime TestID { get; set; }
        public string Name { get; set; }

        public string Rule { get; set; }
        public string LowLimit { get; set; }

        public string HighLimit { get; set; }

        public string Value { get; set; }

        public string Status { get; set; }

        public Test(DateTime testId, string name, string rule, string lowLimit, string highLimit, string value, string status)
        {
            TestID = testId;
            Name = name;
            Rule = rule;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Value = value;
            Status = status;
        }
    }
}
