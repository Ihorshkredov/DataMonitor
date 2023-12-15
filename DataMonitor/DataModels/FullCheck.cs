namespace DataMonitor.DataModels
{
	public class FullCheck
	{
        public int FullCheckID { get; set; }
        public string Status { get; set; }

        public DateTime TimeStamp { get; set; }

        public FullCheck(int fullCheckId, string status, DateTime timeStamp)
        {
            FullCheckID = fullCheckId;
            Status = status;
            TimeStamp = timeStamp;
                
        }
    }
}
