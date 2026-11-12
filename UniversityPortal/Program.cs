
using UniversityPortal.Components;
using UniversityPortal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure Country API
builder.Services.AddHttpClient<CountryService>(client =>
{
    client.BaseAddress = new Uri("https://countries.dev/");
});

// Configure University API
builder.Services.AddHttpClient<UniversityService>(client =>
{
    client.BaseAddress = new Uri("http://universities.hipolabs.com/");
});

// Configure Student Application API
builder.Services.AddHttpClient<StudentApplicationService>(client =>
{
    client.BaseAddress = new Uri("https://edutots.net/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
