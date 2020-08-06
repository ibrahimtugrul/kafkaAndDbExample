using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.entity;
using kafkaAndDbPairing.domain.service;
using kafkaAndDbPairing.request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kafkaAndDbPairing.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _productContext;
        private readonly IProducerService _producerService;
        private readonly IConsumerService _consumerService;
        public ProductController(DataContext productContext, IProducerService producerService, IConsumerService consumerService)
        {
            _productContext = productContext;
            _producerService = producerService;
            _consumerService = consumerService;
        }

        /*[HttpGet]
        public ActionResult<List<Product>> GetAllResult()
        {
            return _productContext.Products.ToList();
        }*/

        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<Product> GetResult(int id)
        {
            return _productContext.Products.Find((long)id);
        }


        [HttpGet]
        public ActionResult<Product> GetResultFromKafka()
        {
            return _consumerService.ConsumeProduct();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateResult(ProductCreateRequest productCreateRequest)
        {
            Product product = new Product()
            {
                Title = productCreateRequest.Title, 
                Price = productCreateRequest.Price, 
                CategoryId = productCreateRequest.CategoryId
            };

            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            await _producerService.PublishAsync(product);
            return CreatedAtAction("CreateResult", new {Id = product.Id}, product);
        }
    }
}
