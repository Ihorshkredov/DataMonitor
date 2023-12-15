using DataMonitor.Models;
using DataMonitor.Services;
using DataMonitor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataMonitor.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IConfiguration _configuration;

		public HomeController(ILogger<HomeController> logger, IConfiguration config)
		{
			_logger = logger;
			_configuration = config;
			
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Contact()
		{	
			return View();
		}
		[HttpGet]
		public IActionResult Data()
		{
			string connection = _configuration.GetConnectionString("mainConnection");
			List<TesterView> testers = DBReader.GetTesterViewList(connection);
			@ViewBag.Testers = testers;

			return View();
		}

		[HttpPost]
		public IActionResult Data(int id)
		{
			return RedirectToAction("TesterData", new {ID = id});	
		}

		public IActionResult TesterData(int ID)
		{
			string connection = _configuration.GetConnectionString("mainConnection");
			List<FullCheckView> listOfChecks = DBReader.GetLast100Tests(connection,ID);
			@ViewBag.ID = ID;
			@ViewBag.Tests = listOfChecks;
			return View();
		}




		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
