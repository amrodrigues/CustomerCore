using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Events;
using Domain.Interfaces;
using Domain.Model;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace Domain.Commands
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, ValidationResult>,
        IRequestHandler<UpdateCustomerCommand, ValidationResult>,
        IRequestHandler<RemoveCustomerCommand, ValidationResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(Guid.NewGuid(), message.Name, message.CPF, message.DateOfBirth);

            if (await _customerRepository.GetByCpF(customer.CPF) != null)
            {
                AddError("The customer e-cpf has already been taken.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new CustomerRegisteredEvent( customer.Id,  customer.Name, customer.CPF, customer.DateOfBirth));

            _customerRepository.Add(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(message.Id, message.Name, message.CPF, message.DateOfBirth);
            var existingCustomer = await _customerRepository.GetByCpF(customer.CPF);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    AddError("The customer cpf has already been taken.");
                    return ValidationResult;
                }
            }

            customer.AddDomainEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.CPF, customer.DateOfBirth));

            _customerRepository.Update(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _customerRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new CustomerRemovedEvent(message.Id));

            _customerRepository.Remove(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}