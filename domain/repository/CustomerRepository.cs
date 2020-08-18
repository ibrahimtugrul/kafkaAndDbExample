using kafkaAndDbPairing.Domain.Data;
using kafkaAndDbPairing.Domain.Entity;
using System.Linq;

namespace kafkaAndDbPairing.Domain.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public Customer RetrieveCustomer(long customerId)
        {
            return _context
                .Customers
                .FirstOrDefault(c => c.Id == customerId);
        }
    }
}