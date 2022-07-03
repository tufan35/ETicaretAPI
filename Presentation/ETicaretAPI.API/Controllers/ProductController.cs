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

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;


        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;

            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {

            var id = Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() {  Name="tufan123", Id = id});

            await _orderWriteRepository.AddAsync(new() { Description = "bla bla1 ", Address = "mersin silifke", CustomerId=id});
            await _orderWriteRepository.AddAsync(new() { Description = "bla bla2 ", Address = "mersin silifke2", CustomerId = id});
            await _orderWriteRepository.SaveAsync();


        }


    }
}
