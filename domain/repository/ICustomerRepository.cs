using System.Runtime.InteropServices.WindowsRuntime;
using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.repository
{
    public interface ICustomerRepository
    {
        Customer RetrieveCustomer(long customerId);
    }
}
