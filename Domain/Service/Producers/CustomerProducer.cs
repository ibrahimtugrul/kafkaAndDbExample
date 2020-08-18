using kafkaAndDbPairing.Domain.Repository;
using kafkaAndDbPairing.Domain.Service.Interfaces;
using System.Text.Json;

namespace kafkaAndDbPairing.domain.service
{
    public class CustomerProducer : ICustomerProducer
    {
        private readonly ICustomerRepository _repository;

        public CustomerProducer(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void Produce()
        {
            var id = 2;
            var customer = _repository.RetrieveCustomer(id);

            var producer = new Producer<string, string>("CustomerCreatedEvent", 0, "localhost:9092");
            producer.Produce($"Customer{id}", JsonSerializer.Serialize(customer));
        }
    }
}
