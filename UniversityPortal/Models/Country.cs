
using System.Text.Json.Serialization;

namespace UniversityPortal.Models;

    public class Country
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("capital")]
        public string Capital { get; set; } = string.Empty;

        [JsonPropertyName("region")]
        public string Region { get; set; } = string.Empty;

        [JsonPropertyName("population")]
        public long Population { get; set; }

        [JsonPropertyName("flag")]
        public string Flag { get; set; } = string.Empty;
    }

