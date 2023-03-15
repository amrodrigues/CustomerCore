using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetDevPack.Data;
using Domain.Model;

namespace Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetById(Guid id);
        Task<Customer> GetByCpF(string cpf);
        Task<IEnumerable<Customer>> GetAll();

        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}