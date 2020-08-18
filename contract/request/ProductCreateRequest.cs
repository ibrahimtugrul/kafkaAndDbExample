namespace kafkaAndDbPairing.Contract.Request
{
    public class ProductCreateRequest
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
    }
}