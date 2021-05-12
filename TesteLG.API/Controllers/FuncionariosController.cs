using Microsoft.AspNetCore.Mvc;

using System.Net;

using TesteLG.Domain.Entities;
using TesteLG.Domain.Repository;

namespace TesteLG.API.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly FuncionarioRepository _funcionarioRepository = new FuncionarioRepository();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("CadastroFuncionario/")]
        public JsonResult CadastroFuncionario(Funcionario funcionario)
        {
            var retorno = _funcionarioRepository.CadastroFuncionario(funcionario);

            if (retorno == 0)
            {
                return new JsonResult(new { StatusCode = HttpStatusCode.BadRequest, Mensagem = "Dados inválidos" });
            }
            else
            {
                return new JsonResult(new { StatusCode = HttpStatusCode.OK, Mensagem = "Funcionário cadastrado com sucesso" });
            }
        }

        [HttpGet]
        [Route("SelecaoFuncionario/Matricula/{matricula}/")]
        public Funcionario SelecionarFuncionario(int matricula)
        {
            return _funcionarioRepository.SelecaoFuncionario(matricula);
        }

        [HttpGet]
        [Route("ObterAliquotaINSS/Matricula/{matricula}/")]
        public double ObterAliquotaINSS(int matricula)
        {
            return _funcionarioRepository.CalculaINSS(matricula);
        }

        [HttpGet]
        [Route("ObterAliquotaIRRF/Matricula/{matricula}/")]
        public double ObterAliquotaIRRF(int matricula)
        {
            return _funcionarioRepository.CalculaIRRF(matricula);
        }
    }
}
