namespace DataMonitor.ViewModels
{
	public class TestView
	{
		public DateTime TestID { get; }
		public string Name { get; }

		public string Rule { get; }
		public string LowLimit { get; }

		public string HighLimit { get;}

		public string Value { get; }

		public string Status { get; }

		public TestView(DateTime testId, string name, string rule, string lowLimit, string highLimit, string value, string status)
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
