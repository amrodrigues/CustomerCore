﻿namespace Domain.Commands.Validations
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            ValidateId();
            ValidateName();
       //     ValidateDateOfBirth();
            ValidateCPF();
        }
    }
}