using Azure.Storage.Blobs;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Win32;
using MoviesApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Set up authentication and authorization
string connectionString = "DefaultEndpointsProtocol=https;AccountName=mssk;AccountKey=1pKz7yMisCYrVrHvlO03o74dLdR/A5qIPVtC4Cexo+lKsE9t1mi97+zfQF4wWA2+vFYQa2i+eDML+AStDeTjyg==;EndpointSuffix=core.windows.net";
string containerName = "accesskeys";
string blobName = "keys.xml";
BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

// optional - provision the container automatically
await container.CreateIfNotExistsAsync();

BlobClient blobClient = container.GetBlobClient(blobName);
// var blobUriSAS = builder.Configuration.GetConnectionString("blobUriSAS");
//
// builder.Services.AddDataProtection()
//     .PersistKeysToAzureBlobStorage(new Uri(blobUriSAS))
//     .SetApplicationName("MoviesApp");

builder.Services.AddDataProtection()
    .PersistKeysToAzureBlobStorage(blobClient)
    .SetApplicationName("MoviesApp");

builder.Services.AddAuthentication("Identity.Application")
    .AddCookie("Identity.Application",options =>
    {
        options.Cookie.Name = ".Yummy";
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();