using System;
using System.Collections.Generic;
using TestePleno.Models;
using TestePleno.Services;
using System.Linq;

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
                selectedOperator = new Operator() { Id = Guid.NewGuid(), Code = operatorCode };
                _operatorService.Create(selectedOperator);
            }
            fare.OperatorId = selectedOperator.Id;

            if (FareService.HasSimilarActiveFares(fare))
            {
                throw new ArgumentException("Já existe Tarifa cadastrada ativa com este valor e operadora.");
            }
            FareService.Create(fare);
          
        }

        public void UpdateFare(Fare updatedFare)
        {
            
            Operator selectedOperator = _operatorService.GetOperatorById(updatedFare.OperatorId);
            if (selectedOperator == null)
            {
                throw new ArgumentException("Essa operadora não está cadastrada.");
            }

            if (FareService.HasSimilarActiveFares(updatedFare))
            {
                throw new ArgumentException("Já existe Tarifa cadastrada ativa com este valor e operadora.");
            }
            updatedFare.UpdateDate();
            FareService.Update(updatedFare);

        }

        public Fare GetFareById(Guid id)
        {
            Fare fare = FareService.GetFareById(id);
            if (fare == null)
            {
                throw new ArgumentException("Tarifa não encontrada.");
            }
            return fare;
        }

        public List<Fare> ListFares()
        {
            List<Fare> fares = FareService.GetFares();
            fares.ForEach(fa => fa.Operator = _operatorService.GetOperatorById(fa.OperatorId));
            fares = fares.OrderBy(fa => fa.Operator.Code).ToList();
            return fares;
        }

        public void DeleteFare(Fare fare)
        {
            FareService.Remove(fare);
        }

        public void ShowFares()
        {
            foreach (Fare fare in ListFares())
            {
                Console.WriteLine(fare);
            }
        }
    }
}
