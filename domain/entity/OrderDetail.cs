namespace kafkaAndDbPairing.Domain.Entity
{
    public class OrderDetail
    {
        public long OrderId { get; set; }
        public long Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
    }
}
