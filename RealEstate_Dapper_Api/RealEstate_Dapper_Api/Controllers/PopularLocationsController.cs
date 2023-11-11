﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
