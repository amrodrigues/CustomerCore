using System;
using Domain.Commands.Validations;

namespace Domain.Commands
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(Guid id, string name, string cpf, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            DateOfBirth = dateOfBirth;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}