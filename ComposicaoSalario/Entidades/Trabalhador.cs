using ComposicaoSalario.Entidades.Enums;
using System.Collections.Generic;

namespace ComposicaoSalario.Entidades
{
    class Trabalhador
    {
        public string Nome { get; set; }
        public TrabalhadorLevel Level { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento  { get; set; }
        public List<ContratoHora> Contratos { get; set; } = new List<ContratoHora>();

        public Trabalhador()
        {

        }
        
        public Trabalhador(string nome, TrabalhadorLevel level, double salarioBase, Departamento departamento)
        {
            Nome = nome;
            Level = level;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AddContrato(ContratoHora contrato)
        {
            Contratos.Add(contrato);
        }

        public void RemoveContrato(ContratoHora contrato)
        {
            Contratos.Remove(contrato);
        }

        public double Ganho(int ano, int mes)
        {
            double somar = SalarioBase;

            foreach(ContratoHora contrato in Contratos)
            {
                if(contrato.Data.Year == ano && contrato.Data.Month == mes)
                {
                    somar += contrato.ValorTotal();
                }
            }
            return somar;
        }
    }
}
