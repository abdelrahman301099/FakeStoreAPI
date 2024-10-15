using FakeStore.Core.Models;
using FakeStore.Core.Repositories;
using FakeStore.Core.Specifications;
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

            var Spec = new ProductBrandTypeSpecification();
            var Products = await _repository.GetAllWithSpecificationAsync(Spec);
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Spec = new ProductBrandTypeSpecification(id);
            var Product = await _repository.GetByIdWithSpecificationAsync(Spec);
            return Ok(Product);
        }

    }
}
