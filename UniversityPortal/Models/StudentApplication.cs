
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityPortal.Models;

public class StudentApplication
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Student name is required.")]
    [JsonPropertyName("studentName")]
    public string StudentName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Country is required.")]
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [Required(ErrorMessage = "University name is required.")]
    [JsonPropertyName("university")]
    public string University { get; set; } = string.Empty;

    [Required(ErrorMessage = "Course name is required.")]
    [JsonPropertyName("course")]
    public string Course { get; set; } = string.Empty;

    [Required(ErrorMessage = "Application date is required.")]
    [DataType(DataType.Date)]
    [JsonPropertyName("applicationDate")]
    public DateTime? ApplicationDate { get; set; } = DateTime.Today;

    [StringLength(1000, ErrorMessage = "Personal statement cannot exceed 1000 characters.")]
    [JsonPropertyName("personalStatement")]
    public string PersonalStatement { get; set; } = string.Empty;
}
