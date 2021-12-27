using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hectre.Core.RequestModels;
using Hectre.Service.Interfaces;

namespace Hectre.API.Controllers
{
	[ApiController]
	[Route("api/v1/chemicals")]
	public class ChemicalsController : ControllerBase
	{
		private readonly IChemicalsService _chemicals;

		public ChemicalsController(IChemicalsService chemicals)
		{
			_chemicals = chemicals;
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> List([FromQuery] ListChemicalsRequest request)
		{
			//throw new NotImplementedException();
			var result = await _chemicals.GetAsync();
			return Ok(result);
		}

		[HttpPost]
		[Route("")]
		public async Task<IActionResult> Create([FromBody] CreateChemicalRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
