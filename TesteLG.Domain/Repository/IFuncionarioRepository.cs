
using TesteLG.Domain.Entities;

namespace TesteLG.Domain.Repository
{
    public interface IFuncionarioRepository
    {
        int CadastroFuncionario(Funcionario funcionario);
        Funcionario SelecaoFuncionario(int matricula);
        double CalculaINSS(int matricula);
        double CalculaIRRF(int matricula);
    }
}
