using System;

namespace TesteLG.Domain.Entities
{
    public class Funcionario
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Salario { get; set; }
    }
}
