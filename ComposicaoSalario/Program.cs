using ComposicaoSalario.Entidades;
using ComposicaoSalario.Entidades.Enums;
using System;
using System.Globalization;

namespace ComposicaoSalario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do Departamento: ");
            string deptNome = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Level(Junior/MidLevel/Senior): ");
            TrabalhadorLevel level = Enum.Parse<TrabalhadorLevel>(Console.ReadLine());
            Console.Write("Salario Base: ");
            double salarioBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departamento dept = new Departamento(deptNome);
            Trabalhador trabalhador = new Trabalhador(nome, level, salarioBase, dept);

            Console.Write("Quantos contratos ira cadastrar? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Entre com o contrato #" + i);
                Console.Write("Date(DD/MM/YYYY): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duracao(horas): ");
                int horas = int.Parse(Console.ReadLine());

                ContratoHora contrato = new ContratoHora(data, valorHora, horas);

                trabalhador.AddContrato(contrato);
            }

            Console.WriteLine();

            Console.Write("Entre com o mes e o ano para calcular o ganho(MM/YYYY): ");
            string meseAno = Console.ReadLine();
            int mes = int.Parse(meseAno.Substring(0, 2));
            int ano = int.Parse(meseAno.Substring(3));


            Console.WriteLine();
            Console.WriteLine("Trabalhador: " + trabalhador.Nome);
            Console.WriteLine("Departamento: " + trabalhador.Departamento.Nome);
            Console.WriteLine("Ganho por " + meseAno + ": " + trabalhador.Ganho(ano, mes).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
