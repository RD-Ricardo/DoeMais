using DM.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;

namespace DM.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : Controller
    {
        private readonly IRelatorioService _relatorioService;
        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpPost("estoque-sangue")]
        public async Task<IActionResult> RelatorioEstoqueSangue(string email)
        {
            if (IsValidEmail(email))
            {
                return BadRequest("Email invalido!");
            }

            var result = await _relatorioService.GerarRelatorioEstoqueSangue(email);

            if (!result)
                return BadRequest();
            
            return Ok();
        }

        static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
    }
}
