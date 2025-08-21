using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.EntityLayer.Concrete;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _cargoCustomerService = customerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList() 
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id) 
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,   
                Name = createCargoCustomerDto.Name,
                Phone = createCargoCustomerDto.Phone,
                Surname = createCargoCustomerDto.Surname,
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo Müşteri Ekleme İşlemi Başarıyla Yapıldı");   
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id) 
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone,
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District= updateCargoCustomerDto.District,
                Email= updateCargoCustomerDto.Email,
                Surname = updateCargoCustomerDto.Surname,
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo Müşteri Güncelleme İşlemi Başarıyla Yapıldı");
        }
    }
}
