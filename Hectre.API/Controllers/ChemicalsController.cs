using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hectre.API.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ChemicalsController : ControllerBase
	{
		public ChemicalsController()
		{
			
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> List()
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		[Route("")]
		public async Task<IActionResult> Create()
		{
			throw new NotImplementedException();
		}
	}
}
