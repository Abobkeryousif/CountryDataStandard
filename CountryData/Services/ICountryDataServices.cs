using CountryData.Standard;

namespace CountryData.Services
{
    public interface ICountryDataServices
    {
        Task<string> GetCountryDataByCodeAsync(string code);   
        Task<string> GetCountryByPhoneCodeAsync(string phoneCode);
        Task<string> GetCountryDataAsync(int offset =1, int limit =20 , string? searchQuery = null);
        Task<string> GetCountryFlagAsync(string countryCode);
        Task<List<Regions>> GetRegionByCountryAsync(string CountyCode);
        Task<IEnumerable<Currency>> GetCurrencyAsync(string CountyCode);

    }
}
