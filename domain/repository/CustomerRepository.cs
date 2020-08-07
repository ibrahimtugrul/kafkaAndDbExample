using kafkaAndDbPairing.domain.data;
using kafkaAndDbPairing.domain.entity;
using System.Linq;

namespace kafkaAndDbPairing.domain.repository
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