using Microsoft.EntityFrameworkCore; //DUK
using WarehouseApp.Components;
using WarehouseApp.Data; //DUK

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add services to the container. //DUK 
builder.Services.AddRazorPages(); //DUK
builder.Services.AddServerSideBlazor(); //DUK
//builder.Services.AddSingleton<WeatherForecastService>(); // Можна видалити, якщо не використовуєш //DUK
// Додаємо DbContext до сервісів
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Додаємо сервіси для роботи з продуктами та транзакціями
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TransactionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
