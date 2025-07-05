using CountryData.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class countryController : ControllerBase
    {
        private readonly ICountryDataServices _countryDataServices;
       public countryController(ICountryDataServices countryDataServices)=>
        _countryDataServices = countryDataServices;

        [HttpGet("countrydata")]
        public async Task<IActionResult> GetCountryDataAsync([FromQuery]int offset = 1, [FromQuery] int limit = 20, [FromQuery] string? searchQuery = null)
        { 
         var data = await _countryDataServices.GetCountryDataAsync(offset, limit, searchQuery);
            return Ok(data);
        }

        [HttpGet("countryflag")]
        public async Task<IActionResult> GetCountryFlagAsync(string countryCode) =>
            Ok(await _countryDataServices.GetCountryFlagAsync(countryCode));

        [HttpGet("currency")]
        public async Task<IActionResult> GetCurrencyAsync(string countryCode) =>
            Ok(await _countryDataServices.GetCurrencyAsync(countryCode));

        [HttpGet("regioncountry")]
        public async Task<IActionResult> GetCountryAsync(string Countrycode) =>
            Ok(await _countryDataServices.GetRegionByCountryAsync(Countrycode));

        [HttpGet("countryByPhoneCode")]
        public async Task<IActionResult> GetCountryByPhoneCode(string phoneCode)=>
            Ok(await _countryDataServices.GetCountryByPhoneCodeAsync(phoneCode));
        
        
    }
}
