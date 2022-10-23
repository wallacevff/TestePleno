using System;
using System.Collections.Generic;
using System.Text;
using TestePleno.Services;
using TestePleno.Models;
using System.Linq;

namespace TestePleno.Controllers
{
    internal class OperatorController
    {
        private readonly OperatorService _operatorService;
        private readonly FareService _fareService;

        public OperatorController(Repository repository)
        {
            this._operatorService = new OperatorService(repository);
            this._fareService = new FareService(repository);
        }

        public void CreateOperator(Operator op)
        {
            _operatorService.Create(op);
        }

        public List<Operator> ListOperators()
        {
            return _operatorService.GetOperators().OrderBy(op => op.Code).ToList();
        }

        public void UpdateOperator(Operator upDatedOperator)
        {
            Operator @operator = _operatorService.GetOperatorByCode(upDatedOperator.Code);
            if (@operator != null)
            {
                throw new ArgumentException("Já existe operadora com esse código, não é possível atualizar.");
            }
            upDatedOperator.UpdateDate();
            _operatorService.Update(upDatedOperator);
        }

        public void DeleteOperator(Operator deletedOperator)
        {
            List<Fare> fares = _fareService.GetFares().Where(f => f.OperatorId == deletedOperator.Id).ToList();
            if (fares.Count > 0)
            {
                throw new ArgumentException("Não é possível excluir esta operadora. Há taxas cadastradas nela.");
            }
            
            _operatorService.Remove(deletedOperator);
        }

        public void ShowOperators()
        {
            foreach (Operator op in ListOperators())
            {
                Console.WriteLine(op);
            }
            
        }
        public Operator GetOperatorByCode(string code)
        {
            Operator op = _operatorService.GetOperatorByCode(code);
            if (op == null)
            {
                throw new ArgumentException("Operadora não cadastrada.");
            }
            return op;
        }

    }
}
