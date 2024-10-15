using FakeStore.Core.Models;
using FakeStore.Core.Repositories;
using FakeStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeStore.APIs.Controllers
{

    public class ProductsController : APIController
    {
        private readonly IGenericRepository<Product> _repository;
        public ProductsController(IGenericRepository<Product> ProductRepo)
        {

            _repository = ProductRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            var Products = await _repository.GetAllAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Product = await _repository.GetByIdAsync(id);
            return Ok(Product);
        }

    }
}
