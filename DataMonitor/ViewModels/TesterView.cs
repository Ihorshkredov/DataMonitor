namespace DataMonitor.ViewModels
{
	public class TesterView
	{
		public int id { get;}
		public string Name { get; }

        public double FPY { get; }

        public TesterView(int id, string name, double fpy )
        {
            this.id = id;
            this.Name = name;
            this.FPY = fpy;                
        }


    }
}
