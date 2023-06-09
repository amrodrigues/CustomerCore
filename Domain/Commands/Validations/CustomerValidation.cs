﻿using System;
using FluentValidation;

namespace Domain.Commands.Validations
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 50 characters");
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c.DateOfBirth)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("The customer must have 18 years or more");
        }

        protected void ValidateCPF()
        {
            RuleFor(c => c.CPF)
                .NotEmpty();
              
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}