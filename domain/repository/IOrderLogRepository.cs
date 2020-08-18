using System.Threading.Tasks;
using KafkaDbPairProject.Domain.Entity;

namespace KafkaDbPairProject.Domain.Repository
{
    public interface IOrderLogRepository
    {
        public Task CreateOrderLog(OrderLog orderLog);

        public OrderLog ReadOrderLog();
    }
}