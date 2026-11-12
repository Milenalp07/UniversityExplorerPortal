
using System.Net.Http.Json;
using global::UniversityPortal.Models;

namespace UniversityPortal.Services
{
    public class CountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            try
            {
                var countries = await _httpClient.GetFromJsonAsync<List<Country>>(
                    "countries?sort=name"
                );

                return countries ?? new List<Country>();
            }
            catch (HttpRequestException)
            {
                throw new Exception(
                    "Unable to connect to the country service. Please try again later."
                );
            }
            catch (System.Text.Json.JsonException)
            {
                throw new Exception(
                    "The country service returned invalid data."
                );
            }
        }
    }
}
