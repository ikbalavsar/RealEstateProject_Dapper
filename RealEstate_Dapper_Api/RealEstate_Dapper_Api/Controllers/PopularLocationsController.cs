using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.Repositories.PopularLocationRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _populaLocationRepository;


        public PopularLocationsController(IPopularLocationRepository populaLocationRepository)
        {
            _populaLocationRepository = populaLocationRepository;
        }


        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            var values = await _populaLocationRepository.GetAllPopularLocationAsync();
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            _populaLocationRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok("Lokasyon başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            _populaLocationRepository.DeletePopularLocation(id);
            return Ok("Lokasyon Başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            _populaLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("Lokasyon başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _populaLocationRepository.GetPopularLocation(id);
            return Ok(value);
        }
    }
}
