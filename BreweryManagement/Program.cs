using Services.Implementation;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IBeerService,BeerService>();
builder.Services.AddScoped<IBrewerService,BrewerService>();
builder.Services.AddScoped<IBreweryService, BreweryService>();
builder.Services.AddScoped<IWholeSalerService, WholeSalerService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IAuditService, AuditService>();

builder.Services.AddScoped<IBrewerBussinessService, BrewerBussinessService>();
builder.Services.AddScoped<IBreweryBussinessService, BreweryBussinessService>();
builder.Services.AddScoped<IBeerBussinessService, BeerBussinessService>();
builder.Services.AddScoped<IWholeSalerBussinessService, WholeSalerBussinessService>();
builder.Services.AddScoped<ISaleBussinessService, SaleBussinessService>();
builder.Services.AddScoped<IStockBussinessService, StockBussinessService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
