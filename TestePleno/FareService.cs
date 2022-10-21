using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class FareService
    {
        Repository _repository;
        
        public FareService(Repository repository)
        {
            _repository = repository;
        }

        public void Create(Fare fare)
        {
            _repository.Insert(fare);
        }

        public void Update(Fare fare)
        {
            _repository.Update(fare);
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = _repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = _repository.GetAll<Fare>();
            return fares;
        }
        public bool HasSimilarActiveFares(Fare fare)
        {
           List<Fare> fares = this.GetFares().Where(f => f.Value == fare.Value &&
                f.Status == 1 && (fare.CreatedAt - f.CreatedAt).Days <= 180 ).ToList();
            Console.WriteLine(fares.FirstOrDefault());
            if(fares.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
