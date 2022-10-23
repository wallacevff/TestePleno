using TestePleno.Controllers;
using TestePleno.Services;

namespace TestePleno
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository _repository = new Repository();
            FareController fareController = new FareController(_repository);
            OperatorController operatorController = new OperatorController(_repository);
            Startup.StartProgram(fareController, operatorController);            
        }

        
    }

}
/*
    O primeiro problema a ser solucionado, foi referente a classe Fare que não implementava
a interface IModel, causando conflito com as operações definidas com a classe repository.
Outra questão que foi tratada, foi na criação do cadastro da Fare que precisava possuir
dois valores, OperatorId e Status. O tratamento para o OperatorId foi o seguinte, realizava-se
a busca no banco de dados referente ao registro do Operator utilizando o Code para a pesquisa,
caso não fosse encontrado nenhum Operator, um novo cadastro seria realizado. A classe Fare
teve uma propriedade adicionada CreatedAt do tipo DateTime para que fosse possível adicionar
a regra de negócio referente ao cadastro de Fare com o mesmo Value, OperatorId e 180 dias 
(6 meses) em relação ao cadastro atual, a classe Operator também teve uma propriedade
CreatedAt aducionada para controles futuros.Tiveram que ser adicionadas injeções de 
dependência nos Services e Controllers da aplicação, pois antes, um novo banco era criado 
para cada novo cadastro realizado.
    Foram realizados tratamentos de Excessões nos inputs da aplicação para mensagens
compreensíveis aos usuários. Foi criada uma classe Startup para tornar mais fácil os testes que
foram aplicados, permitindo também que a função Main ficasse mais limpa.
    Por fim, foram implementadas as demais funcionalidades do sistema: Listar, Atualizar e Remover.
    
**** Observação ****
* A lógica de cadastramento de Operadoras foi incluso nas operações de criação e atualização da Tarifa.
* Caso uma Tarifa seja criada, é verificada a existência de uma Operadora na base de dados,
* caso a Operadora não exista, será cadastrada uma nova. O mesmo acontece na atualização da Tarifa.
* No caso de exclusão de uma Operadora, caso existam Tarifas vinculadas, um aviso será exibido ao usuário e
* a exclusão só será realizada caso não hajam Tarifas vinculadas a ela.

*/