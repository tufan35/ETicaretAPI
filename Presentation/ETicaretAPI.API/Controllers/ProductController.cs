using ETicaretAPI.Application.Respositories;
using ETicatetAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() {Id = Guid.NewGuid(), Name = "Product 1 " , Price  = 100, CreatedDate = DateTime.UtcNow.Date,Stock = 10 },
            //    new() {Id = Guid.NewGuid(), Name = "Product 2 " , Price  = 200, CreatedDate = DateTime.UtcNow.Date,Stock = 20 },
            //    new() {Id = Guid.NewGuid(), Name = "Product 3 " , Price  = 300, CreatedDate = DateTime.UtcNow.Date,Stock = 10 }
            //});
            //var count = await _productWriteRepository.SaveAsync();

            Product p = await _productReadRepository.GetByIdAsync("424874a7-0f40-4f5b-a403-79e3f29d3117", false);
            p.Name = "memet";
            await _productWriteRepository.SaveAsync();


        }

    }



}

