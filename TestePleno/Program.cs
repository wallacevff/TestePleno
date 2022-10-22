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

*/