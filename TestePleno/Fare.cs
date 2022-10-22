using System;
using System.Text;
namespace TestePleno.Models
{
    public class Fare : IModel
    {

        public Guid Id { get; set; }
        public Guid OperatorId { get; set; }
        public int Status { get; private set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }
        public Operator Operator { get; set; }

        public Fare()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Status = 1;
        }

        public Fare(Guid id, Guid operatorId, int status, decimal value, DateTime createdAt, DateTime updatedAt, Operator @operator)
        {
            Id = id;
            OperatorId = operatorId;
            Status = status;
            Value = value;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Operator = @operator;
        }

        public void UpdateDate()
        {
            this.UpdatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            if (Operator.Code == null)
            {
                return $"Id: {this.Id}; Value: {this.Value.ToString("F2")};" +
                $" CreatedAt: {this.CreatedAt}; UpdatedAt: {this.UpdatedAt}";
            }
            return $"Operator: {Operator.Code}; Id: {this.Id}; Value: {this.Value.ToString("F2")};" +
                $" Status: {this.Status}" +
                $" CreatedAt: {this.CreatedAt}; UpdatedAt: {this.UpdatedAt}";
        }
        public void setStatus(int status)
        {
            if (status != 0 && status != 1)
            {
                throw new ArgumentException("O status Deve ser 0 ou 1");
            }
            this.Status = status;
        }
    }

      
}
