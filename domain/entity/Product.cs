using System.ComponentModel.DataAnnotations.Schema;

namespace kafkaAndDbPairing.domain.entity
{
    [Table("prodcut")]
    public class Product
    {
        [Column(name: "id")]
        public long Id { get; set; }
        [Column(name: "title")]
        public string Title { get; set; }
        [Column(name: "price")]
        public double Price { get; set; }
        
        [Column(name: "categoryid")]
        public long CategoryId { get; set; }
    }
}