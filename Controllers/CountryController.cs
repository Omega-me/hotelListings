using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.Domain;
using HotelListing.DTO;
using HotelListing.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork,ILogger<CountryController> logger,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CountryDTO>> GetCountries()
        {
            try
            {
                IList<Country> countries =await _unitOfWork.Countries.GetAll(null,null,new List<string>(){"Hotels"});
                IList<CountryDTO> results = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(new
                {
                    status = "success",
                    length = results.Count,
                    data = countries
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e,$"Something went wrong in the {nameof(GetCountries)}");
                return StatusCode(500,"Internal server Error, Please try again leter");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CountryDTO>> GetCountry(int id)
        {
            try
            {
                Country country = await _unitOfWork.Countries.Get(c =>c.Id==id , new List<string>(){"Hotels"});
                CountryDTO result = _mapper.Map<CountryDTO>(country);
                return Ok(new
                {
                    status = "success",
                    country = result
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e,$"Something went wrong in the {nameof(GetCountries)}");
                return StatusCode(500,"Internal server Error, Please try again leter");
            }
        }
    }
}