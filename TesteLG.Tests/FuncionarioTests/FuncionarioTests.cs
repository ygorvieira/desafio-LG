using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using TesteLG.Domain.Repository;

namespace TesteLG.Tests.FuncionarioTests
{
    [TestClass]
    public class FuncionarioTests
    {
        private readonly FuncionarioRepository _funcionarioRepository = new FuncionarioRepository();

        [TestMethod]
        public void CadastroUsuarioCadastrandoFuncionarioMenorQueDezoitoAnosRetornaCadastroInvalido()
        {
            var funcionarioNascimento = DateTime.Now;

            Domain.Entities.Funcionario func = new Domain.Entities.Funcionario();

            func.DataNascimento = funcionarioNascimento;

            var resultado = _funcionarioRepository.CadastroFuncionario(func);

            Assert.AreEqual(resultado, 0);
        }

        [TestMethod]
        public void CadastroFuncionarioCadastrandoComDataAdmissaoAnoAnteriorRetornaCadastroInvalido()
        {
            var funcionarioAdmissao = DateTime.Now.AddYears(-1);

            Domain.Entities.Funcionario func = new Domain.Entities.Funcionario();

            func.DataAdmissao = funcionarioAdmissao;

            var resultado = _funcionarioRepository.CadastroFuncionario(func);

            Assert.AreEqual(resultado, 0);
        }
    }
}
