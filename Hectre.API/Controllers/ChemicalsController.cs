using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hectre.Core.RequestModels;

namespace Hectre.API.Controllers
{
	[ApiController]
	[Route("api/v1/chemicals")]
	public class ChemicalsController : ControllerBase
	{
		public ChemicalsController()
		{
			
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> List([FromQuery] ListChemicalsRequest request)
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
