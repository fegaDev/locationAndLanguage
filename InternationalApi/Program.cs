var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//1.localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//2. Supports Languages
    
var supportedCultures = new[] { "en-US", "es-ES", "fr-FR", "de-DE" };
var localizationOption = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0]) //Default
    .AddSupportedCultures(supportedCultures) //Add all supported cultures
    .AddSupportedUICultures(supportedCultures); // Add all supported UI

//3. Add localitation to App
app.UseRequestLocalization(localizationOption);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
