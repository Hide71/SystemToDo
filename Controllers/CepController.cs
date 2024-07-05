using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using SystemToDo.Integracao.Interfaces;
using SystemToDo.Integracao.Response;

namespace SystemToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;
        public CepController(IViaCepIntegracao viaCepIntegracao)
        {
            _viaCepIntegracao = viaCepIntegracao;
        }
        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
        {
           var responseData =  await _viaCepIntegracao.ObterDadosViaCep(cep);
            if(responseData == null)
            {
                return BadRequest("Endereço não encontrado!");
            }
            return Ok(responseData);
        }
    }
}
