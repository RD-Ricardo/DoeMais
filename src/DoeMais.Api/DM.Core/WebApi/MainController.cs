using Microsoft.AspNetCore.Mvc;

namespace DM.Core.WebApi
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();
        protected ActionResult CustomResponse<T>(RequestResult<T> request)
        {
            if (request.Sucesso)
            {
                return Ok(request);
            }

            return BadRequest(new { Sucesso = false, MensagensErros = request.MensagensErros.ToArray() });
        }
    }
}
