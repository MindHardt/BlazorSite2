using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Un1ver5e.Web.III.Server.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SvgController : ControllerBase
	{
		private readonly string rawSvg;

		public SvgController()
		{
			rawSvg = System.IO.File.ReadAllText("./raw.svg");
		}
		// GET: <SvgController>
		[HttpGet]
		public string Get()
		{
			return rawSvg;
		}
	}
}
