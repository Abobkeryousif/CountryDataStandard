using CountryData.Standard;
using Newtonsoft.Json;

namespace CountryData.Services
{
    public class CountryDataServices : ICountryDataServices
    {
        private readonly CountryHelper _countryHelper;

        public CountryDataServices(CountryHelper countryHelper)
        {
            _countryHelper = countryHelper;
        }

        public Task<string> GetCountryByPhoneCodeAsync(string phoneCode)
        {
            var country = _countryHelper.GetCountryByPhoneCode(phoneCode);
            if(country == null)
            {
                return Task.FromResult("Invalid Phone Code");
            }

            return Task.FromResult(JsonConvert.SerializeObject(country,Formatting.Indented));

        }

        public Task<string> GetCountryDataAsync(int offset = 1, int limit = 20, string? searchQuery = null)
        {
            var country = _countryHelper.GetCountryData();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.ToLower();
                country = country.Where(n => n.CountryName.ToLower().Contains(searchQuery)).ToList();
            }
            
            var pagenation = country.Skip((offset - 1) * limit).Take(limit).ToList();

            if (!pagenation.Any())
                return Task.FromResult("Not Found Data");

            return Task.FromResult(JsonConvert.SerializeObject(pagenation,Formatting.Indented));
        }

        public Task<string> GetCountryDataByCodeAsync(string code)
        {
            var country = _countryHelper.GetCountryByCode(code);
            if(country == null)
            {
                return Task.FromResult("Invalid Code");
            }

            return Task.FromResult(JsonConvert.SerializeObject(country , Formatting.Indented));

        }

        public Task<string> GetCountryFlagAsync(string countryCode)
        {
            var flag = _countryHelper.GetCountryEmojiFlag(countryCode);
            if (string.IsNullOrEmpty(flag))
            {
                return Task.FromResult("Invalid Country Code");
            }

            return Task.FromResult(flag);
        }

        public Task<IEnumerable<Currency>> GetCurrencyAsync(string CountryCode)
        {
            var currency = _countryHelper.GetCurrencyCodesByCountryCode(CountryCode);
            return Task.FromResult(currency);

        }

        public Task<List<Regions>> GetRegionByCountryAsync(string CountyCode)
        {
            var region = _countryHelper.GetRegionByCountryCode(CountyCode);
            return Task.FromResult(region);
        }
    }
}
