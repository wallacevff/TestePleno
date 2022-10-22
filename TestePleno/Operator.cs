using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePleno.Models
{
    public class Operator : IModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }

        public Operator()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Operator(Guid id, string code, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Code = code;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public void UpdateDate()
        {
            this.UpdatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Id: {this.Id}; Code: {this.Code}; CreatedAt: {this.CreatedAt}; " +
                $"UpdatedAt: {this.UpdatedAt}";
        }
    }
}
