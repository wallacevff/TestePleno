using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno.Controllers
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService FareService;

        public FareController(Repository _repository)
        {
            _operatorService = new OperatorService(_repository);
            FareService = new FareService(_repository);
        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            Operator selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            if (selectedOperator == null)
            {
                Console.WriteLine("cadastro de operator");
                selectedOperator = new Operator() { Id = Guid.NewGuid(), Code = operatorCode };
                _operatorService.Create(selectedOperator);
            }
            fare.OperatorId = selectedOperator.Id;
            /*
            if (FareService.HasSimilarActiveFares(fare))
            {

                Console.WriteLine("Já existe Tarifa cadastrada ativa com este valor e operadora.");
            } */
            FareService.Create(fare);

            List<Fare> fars = FareService.GetFares();
            foreach (Fare fare1 in fars)
            {
                Console.WriteLine($"Operadora: {fare1.OperatorId}, Valor: {fare1.Value}");
            }
            
        }
    }
}
