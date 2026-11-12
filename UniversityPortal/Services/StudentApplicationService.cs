
using System.Net.Http.Json;
using System.Text.Json;
using UniversityPortal.Models;

namespace UniversityPortal.Services;

public class StudentApplicationService
{
    private readonly HttpClient _httpClient;

    public StudentApplicationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // GET: Retrieve all applications
    public async Task<List<StudentApplication>> GetApplicationsAsync()
    {
        try
        {
            var applications = await _httpClient
                .GetFromJsonAsync<List<StudentApplication>>(
                    "api/studentapplication");

            return applications ?? new List<StudentApplication>();
        }
        catch (HttpRequestException ex)
        {
            throw new Exception(
                "Unable to connect to the student application service.", ex);
        }
        catch (JsonException ex)
        {
            throw new Exception(
                "The student application service returned invalid data.", ex);
        }
    }

    // GET: Find an application by ID
    public async Task<StudentApplication?> GetApplicationByIdAsync(int id)
    {
        var applications = await GetApplicationsAsync();

        return applications.FirstOrDefault(a => a.Id == id);
    }

    // POST: Create an application
    public async Task<bool> CreateApplicationAsync(
        StudentApplication application)
    {
        try
        {
            using var response = await _httpClient.PostAsJsonAsync(
                "api/studentapplication",
                application);

            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException ex)
        {
            throw new Exception(
                "Unable to connect to create the application.", ex);
        }
    }

    // PUT: Update an application
    public async Task<bool> UpdateApplicationAsync(
        int id,
        StudentApplication application)
    {
        try
        {
            using var response = await _httpClient.PutAsJsonAsync(
                $"api/studentapplication/{id}",
                application);

            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException ex)
        {
            throw new Exception(
                "Unable to connect to update the application.", ex);
        }
    }
}
