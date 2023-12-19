namespace DataMonitor.ViewModels
{
	public class FullCheckView
	{
		public int id { get; set; }
		public string Status { get; set; }

		public DateTime TimeStamp { get; set; }

		public FullCheckView(int id, string status, DateTime timeStamp)
		{
			this.id = id;
			Status = status;
			TimeStamp = timeStamp;

		}

	}
}
