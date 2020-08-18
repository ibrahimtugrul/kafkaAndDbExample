using kafkaAndDbPairing.Domain.Entity;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.Domain.Repository
{
    public interface IOrderLogRepository
    {
        public Task CreateOrderLog(OrderLog orderLog);

        public OrderLog ReadOrderLog();
    }
}