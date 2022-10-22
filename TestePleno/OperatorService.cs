using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class OperatorService
    {
        private readonly Repository _repository;
        public OperatorService(Repository repository)
        {
            _repository = repository;
        }
        public Operator GetOperatorByCode(string code)
        {
            List<Operator> operators = _repository.GetAll<Operator>();
            Operator selectedOperator = operators.FirstOrDefault(o => o.Code == code);
            return selectedOperator;
        }

        public Operator GetOperatorById(Guid id)
        {
            Operator selectedOperator = _repository.GetById<Operator>(id);
            return selectedOperator;
        }

        public List<Operator> GetOperators()
        {
            List<Operator> operators = _repository.GetAll<Operator>();
            return operators;
        }

        public Operator Create(Operator insertingOperator)
        {
            _repository.Insert(insertingOperator);
            return insertingOperator;
        }

        public void Update(Operator updatingOperator)
        {            
            _repository.Update(updatingOperator);
        }

        public void Remove(Operator updatingOperator)
        {
            _repository.Delete(updatingOperator);
        }
    }
}
