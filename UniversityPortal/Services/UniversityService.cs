
using System.Net.Http.Json;
using UniversityPortal.Models;

namespace UniversityPortal.Services
{
    public class UniversityService
    {
        private readonly HttpClient _httpClient;

        public UniversityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<University>> GetUniversitiesByCountryAsync(
            string country)
        {
            try
            {
                string url = $"search?country={Uri.EscapeDataString(country)}";

                var universities = await _httpClient
                    .GetFromJsonAsync<List<University>>(url);

                return universities ?? new List<University>();
            }
            catch (HttpRequestException)
            {
                throw new Exception(
                    "Unable to connect to the university service. Please try again later."
                );
            }
            catch (System.Text.Json.JsonException)
            {
                throw new Exception(
                    "The university service returned invalid data."
                );
            }
        }
    }
}
