﻿using APICodigoEFC.Context;
using APICodigoEFC.Models;

namespace APICodigoEFC.Services
{
    public class CustomersService
    {
        private readonly CodigoContext _context;

        public CustomersService(CodigoContext context)
        {
            _context = context;
        }
        public List<Customer> GetByFilters(string? name, string? documentNumber)
        {
            IQueryable<Customer> query = _context.Customers.Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));

            if (!string.IsNullOrEmpty(documentNumber))
                query = query.Where(x => x.DocumentNumber.Contains(documentNumber));

            return query.ToList();
        }
    }
}
