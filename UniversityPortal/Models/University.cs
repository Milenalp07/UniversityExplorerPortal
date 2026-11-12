
using System.Text.Json.Serialization;

namespace UniversityPortal.Models;

    public class University
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("web_pages")]
        public List<string> WebPages { get; set; } = new();

        [JsonPropertyName("domains")]
        public List<string> Domains { get; set; } = new();

        [JsonPropertyName("alpha_two_code")]
        public string CountryCode { get; set; } = string.Empty;
    }

