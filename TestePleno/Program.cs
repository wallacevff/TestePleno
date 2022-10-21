using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Controllers;
using TestePleno.Models;
using TestePleno.Services;
namespace TestePleno
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    /*
                    Console.Write("Escolha a Opção Desejada:\r\n[1] => Cadastrar Tarifa" +
                        "\r\n[2] => Cadastrar Operadora" +
                        "\r\n[3] => Atualizar Tarifa" +
                        "\r\n[4] => Atualizar Operadora" +
                        "\r\n[5] => Remover Tarifa" +
                        "\r\n[6] => Remover Operadora\r\n\r\nOpção Desejada: ");
                    int opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                            string fareValueInput = Console.ReadLine();
                            Fare fare = new Fare();
                            fare.Id = Guid.NewGuid();
                            fare.Value = convertDecimal(fareValueInput);
                            Console.WriteLine("Informe o código da operadora para a tarifa:");
                            Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                            string operatorCodeInput = Console.ReadLine();
                            FareController fareController = new FareController();
                            fareController.CreateFare(fare, operatorCodeInput);
                            Console.WriteLine("Tarifa cadastrada com sucesso!");
                            Console.Read();
                            break;

                        case 2:
                            Console.WriteLine();
                            break;

                        default:
                            Console.WriteLine("Opção inválida! Selecione uma destre as opções acima.");
                            break;
                    }


                    Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                    string fareValueInput = Console.ReadLine();
                    Fare fare = new Fare();
                    fare.Id = Guid.NewGuid();
                    fare.Value = convertDecimal(fareValueInput);
                    Console.WriteLine("Informe o código da operadora para a tarifa:");
                    Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                    string operatorCodeInput = Console.ReadLine();
                    FareController fareController = new FareController();
                    fareController.CreateFare(fare, operatorCodeInput);
                    Console.WriteLine("Tarifa cadastrada com sucesso!");
                    Console.Read();
                    */
                    // Guid guid = Guid.NewGuid();
                    // DateTime date = DateTime.Now;
                    //date.AddMonths(1);
                    //Console.WriteLine(date.AddMonths(-1));

                    Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                    string fareValueInput = Console.ReadLine();
                    Fare fare = new Fare();
                    fare.Id = Guid.NewGuid();
                    fare.Value = convertDecimal(fareValueInput);
                    Console.WriteLine("Informe o código da operadora para a tarifa:");
                    Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                    string operatorCodeInput = Console.ReadLine();
                    FareController fareController = new FareController();
                    fareController.CreateFare(fare, operatorCodeInput);
                    Console.WriteLine("Tarifa cadastrada com sucesso!");
                    //Console.Read();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
        static decimal convertDecimal(string value)
        {
            decimal intVal;
            try
            {
                intVal = decimal.Parse(value);
            }
            catch (Exception e)
            {
                throw new ArgumentException("O Valor digitado não é um número, apenas números são aceitos.");
            }
            return intVal;
        }
    }
}
