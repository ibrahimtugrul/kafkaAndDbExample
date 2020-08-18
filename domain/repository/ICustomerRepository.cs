using kafkaAndDbPairing.Domain.Entity;

namespace kafkaAndDbPairing.Domain.Repository
{
    public interface ICustomerRepository
    {
        Customer RetrieveCustomer(long customerId);
    }
}
