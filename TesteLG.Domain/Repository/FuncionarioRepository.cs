using Dapper;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using TesteLG.Domain.Entities;

namespace TesteLG.Domain.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly string connectionString = "Data Source=den1.mssql8.gear.host; Initial Catalog=desafiolg; User Id=desafiolg; Password=Pn8F!di7~a05";

        public int CadastroFuncionario(Funcionario funcionario)
        {
            if ((DateTime.Now.Year - funcionario.DataNascimento.Year) <= 18)
            {
                return 0;
            }

            if ((DateTime.Now.Month - funcionario.DataAdmissao.Month) != 1)
            {
                return 0;
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO FUNCIONARIOS(Matricula, Nome, DataAdmissao, DataNascimento, Salario) VALUES (@Matricula, @Nome, @DataAdmissao, @DataNascimento, @Salario)";
                connection.Execute(query, funcionario);
            }

                return 1;
        }

        public double CalculaIRRF(int matricula)
        {
            string tipoImposto = "ALIQUOTA_IRRF";

            return CalculaImposto(matricula, tipoImposto);
        }

        public double CalculaINSS(int matricula)
        {
            string tipoImposto = "ALIQUOTA_INSS";

            return CalculaImposto(matricula, tipoImposto);
        }

        private double CalculaImposto(int matricula, string tipoImposto)
        {
            try
            {  
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                var querySalario = "SELECT f.Salario FROM FUNCIONARIOS where Matricula = " + matricula;
                double salario = Convert.ToDouble(connection.Query<Funcionario>(querySalario));

                var queryAliquotas = "SELECT * FROM " + tipoImposto;
                var lstAliquotas = connection.Query<Aliquota>(queryAliquotas);

                var valorAliquota = 0.0;

                foreach (var item in lstAliquotas)
                {
                    if (salario >= item.ValorSalario)
                    {
                        valorAliquota = item.PercentualAliquota;
                    }
                }

                return valorAliquota;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Funcionario SelecaoFuncionario(int matricula)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                var query = "SELECT * FROM FUNCIONARIOS WHERE Matricula = " + matricula;
                var funcionario = connection.Query<Funcionario>(query);

                return (Funcionario)funcionario;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
