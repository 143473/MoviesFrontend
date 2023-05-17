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
//Method 1
string connectionString = builder.Configuration.GetConnectionString("mssk");
string containerName = "accesskeys";
string blobName = "keys.xml";
BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

// optional - provision the container automatically
await container.CreateIfNotExistsAsync();

BlobClient blobClient = container.GetBlobClient(blobName);
builder.Services.AddDataProtection()
    .PersistKeysToAzureBlobStorage(blobClient)
    .SetApplicationName("MoviesApp");

//  Method 2
// var blobUriSAS = builder.Configuration.GetConnectionString("blobUriSAS");
//
// builder.Services.AddDataProtection()
//     .PersistKeysToAzureBlobStorage(new Uri(blobUriSAS))
//     .SetApplicationName("MoviesApp");

//Method 3
// builder.Services.AddDataProtection()
//     .PersistKeysToFileSystem(new DirectoryInfo(@"c:\temp-keys\"))
//     .SetApplicationName("SharedCookieApp");

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