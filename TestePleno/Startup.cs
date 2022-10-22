using System;
using TestePleno.Controllers;
using TestePleno.Services;
using TestePleno.Models;

namespace TestePleno
{
    internal class Startup
    {
        public static void StartProgram(FareController fareController, OperatorController operatorController)
        {
            string option;
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.Write("Escolha a opção desejada:\r\n" +
                        "\r\n[1] => Cadastrar Tarifa" +
                        "\r\n[2] => Listar Tarifas" +
                        "\r\n[3] => Listar Operadoras" +
                        "\r\n[4] => Atualizar Tarifa" +
                        "\r\n[5] => Atualizar Operadora" +
                        "\r\n[6] => Excluir Tarifa" +
                        "\r\n[7] => Excluir Operadora" +
                        "\r\n[8] => Encerrar\r\n" +
                        "\r\nOpção desejada: ");
                    option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            registerFare(fareController);
                            break;
                        case "2":
                            fareController.ShowFares();
                            break;
                        case "3":
                            operatorController.ShowOperators();
                            break;
                        case "4":
                            Console.WriteLine("Digite o Id da tarifa que deseja alterar:");                          
                            Guid guid = new Guid(Console.ReadLine());
                            Fare oldFare = fareController.GetFareById(guid);
                            Fare newFare = new Fare(oldFare.Id, oldFare.OperatorId,
                                oldFare.Status, oldFare.Value, oldFare.CreatedAt, oldFare.UpdatedAt,
                                oldFare.Operator);
                            Console.WriteLine("Digite o valor da tarifa: ");
                            newFare.Value = convertDecimal(Console.ReadLine());
                            Console.WriteLine("Digite o status da tarifa 1 ou 0: ");
                            newFare.setStatus(convertInt(Console.ReadLine()));
                            Console.WriteLine("Digite a operadora da tarifa");
                            Operator op = operatorController.GetOperatorByCode(Console.ReadLine());
                            newFare.OperatorId = op.Id;
                            newFare.Operator = op;                                                    
                            fareController.UpdateFare(newFare);
                            Console.WriteLine(newFare);
                            break;
                        case "5":
                            Console.WriteLine("Digite o código da operadora que deseja alterar:");
                            Operator oldOperator = operatorController.GetOperatorByCode(Console.ReadLine());
                            Operator newOperator = new Operator(oldOperator.Id, oldOperator.Code,
                                oldOperator.CreatedAt, oldOperator.UpdatedAt);
                            Console.WriteLine("Digite o novo código da operadora que deseja alterar:");
                            newOperator.Code = Console.ReadLine();
                            operatorController.UpdateOperator(newOperator);
                            Console.WriteLine(newOperator);
                            break;
                        case "6":
                            Console.WriteLine("Digite o id da tarifa que deseja excluir:");
                            Fare delFare = fareController.GetFareById(new Guid(Console.ReadLine()));
                            fareController.DeleteFare(delFare);
                            Console.WriteLine($"Tarifa de Id: {delFare.Id} foi excluida.");
                            break;

                        case "7":
                            Console.WriteLine("Digite o código da operadora que deseja excluir:");
                            Operator delOperator = operatorController.GetOperatorByCode(Console.ReadLine());
                            operatorController.DeleteOperator(delOperator);
                            Console.WriteLine($"Operadora: {delOperator.Code} excluída.");
                            break;

                        case "8":
                            Console.WriteLine("Saindo...");
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Opção Invalida!");
                            break;
                            
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static decimal convertDecimal(string value)
        {
            decimal decVal;
            try
            {
                decVal = decimal.Parse(value);
            }
            catch (Exception e)
            {
                throw new ArgumentException("O Valor digitado não é um número, apenas números são aceitos.");
            }
            return decVal;
        }
        static int convertInt (string value)
        {
            int intVal;
            try
            {
                intVal = int.Parse(value);
            }
            catch (Exception e)
            {
                throw new ArgumentException("O Valor digitado não é um número, apenas números são aceitos.");
            }
            return intVal;
        }
        



        static void registerFare(FareController fareController)
        {
            Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
            string fareValueInput = Console.ReadLine();
            Fare fare = new Fare();
            fare.Id = Guid.NewGuid();
            fare.Value = convertDecimal(fareValueInput);
            Console.WriteLine("Informe o código da operadora para a tarifa:");
            Console.WriteLine("Exemplos: OP01, OP02, OP03...");
            string operatorCodeInput = Console.ReadLine();
            fareController.CreateFare(fare, operatorCodeInput);
            Console.WriteLine("Tarifa cadastrada com sucesso!");
        }

       
       
    }
}
