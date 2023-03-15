using System;
using Domain.Commands.Validations;

namespace Domain.Commands
{
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand(string name, string cpf, DateTime dateOfBirth)
        {
            Name = name;
            CPF = cpf;
            DateOfBirth = dateOfBirth;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}