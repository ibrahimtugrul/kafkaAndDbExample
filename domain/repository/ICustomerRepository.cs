using KafkaDbPairProject.Domain.Entity;

namespace KafkaDbPairProject.Domain.Repository
{
    public interface ICustomerRepository
    {
        Customer RetrieveCustomer(long customerId);
    }
}
