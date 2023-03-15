using System;
using NetDevPack.Domain;

namespace Domain.Model
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id, string name, string cpf, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            DateOfBirth = dateOfBirth;
        }

        // Empty constructor for EF
        protected Customer() { }

        public string Name { get; private set; }

        public string CPF { get; private set; }

        public DateTime DateOfBirth { get; private set; }
    }
}