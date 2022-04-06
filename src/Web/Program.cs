var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IContainerSettingsMapper, ContainerSettingsMapper>();
builder.Services.AddSingleton<IContainerSettingsService, ContainerSettingsService>(provider =>
{
    var mapper = provider.GetService<IContainerSettingsMapper>() ?? throw new();
    var containers = builder.Configuration.GetSection("CONTAINERS").GetChildren();
    return new(mapper,containers);
});
builder.Services.AddSingleton<IContainerRegistryService, ContainerRegistryService>(provider =>
{
    var settingsService = provider.GetService<IContainerSettingsService>() ?? throw new();
    var settings = settingsService.SettingsRegistry;
    return new(settings);
});


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
