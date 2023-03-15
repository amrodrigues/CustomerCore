using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto.Repository.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using Domain.Model;
using Domain.Interfaces;

namespace Projeto.Repository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly CustomerContext Db;
        protected readonly DbSet<Customer> DbSet;
        public CustomerRepository(CustomerContext context)
        {
            Db = context;
            DbSet = Db.Set<Customer>();
        }

         public IUnitOfWork UnitOfWork => Db;

        public void Add(Customer customer)
        {
            DbSet.Add(customer);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Customer> GetByCpF(string cpf)
        {
             return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.CPF == cpf);
            
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Remove(Customer customer)
        {
            DbSet.Remove(customer);
        }

        public void Update(Customer customer)
        {
            DbSet.Update(customer);
        }
    }
}
