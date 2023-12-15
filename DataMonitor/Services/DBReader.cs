using Dapper;
using DataMonitor.DataModels;
using System.Data.SqlClient;
using DataMonitor.ViewModels;


namespace DataMonitor.Services
{
	public static class DBReader
	{
		public static List<TesterView> GetTesterViewList(string connectionString)
		{
			string sql = "SELECT * FROM Tester";
			List<TesterView> result = new List<TesterView>();
			List<Tester> testerList = new List<Tester>();

            using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				testerList = connection.Query<Tester>(sql).ToList();

				foreach (Tester tester in testerList)
				{
					 DynamicParameters parameters = new DynamicParameters();
					 parameters.Add("@TesterID", tester.id);

					var fullCheckList = connection.Query<FullCheckView>("GetLast100FullTest", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();

					int passedCount = 0;
					foreach(var fullCheck in fullCheckList)
					{
						if (fullCheck.Status == "PASSED")
						{
							passedCount++;
						}
					}

					result.Add( new TesterView (tester.id,tester.Name,
								((passedCount*100)/fullCheckList.Count)));
				}

            }
			return result;
        }

		public static List<FullCheckView> GetLast100Tests(string connectionString, int id)
		{
			List<FullCheckView> fullCheckList = new List<FullCheckView>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@TesterID", id);

				connection.Open();
				fullCheckList = connection.Query<FullCheckView>("GetLast100FullTest",parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
				
				
				return fullCheckList;
			}
			
		}

	}
}
