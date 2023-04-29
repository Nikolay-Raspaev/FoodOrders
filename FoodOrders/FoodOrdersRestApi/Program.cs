using FoodOrdersBusinessLogic.BusinessLogics;
using FoodOrdersBusinessLogic.MailWorker;
using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersDatabaseImplement.Implements;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Logging.AddLog4Net("log4net.config");

// Add services to the container.
builder.Services.AddTransient<IClientStorage, ClientStorage>();
builder.Services.AddTransient<IImplementerStorage, ImplementerStorage>();
builder.Services.AddTransient<IOrderStorage, OrderStorage>();
builder.Services.AddTransient<IDishStorage, DishStorage>();
builder.Services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
builder.Services.AddTransient<IShopStorage, ShopStorage>();

builder.Services.AddTransient<IOrderLogic, OrderLogic>();
builder.Services.AddTransient<IImplementerLogic, ImplementerLogic>();
builder.Services.AddTransient<IClientLogic, ClientLogic>();
builder.Services.AddTransient<IDishLogic, DishLogic>();
builder.Services.AddTransient<IShopLogic, ShopLogic>();
builder.Services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();

builder.Services.AddSingleton<AbstractMailWorker, MailKitWorker>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodOrdersRestApi", Version = "v1" });
});

var app = builder.Build();

var mailSender = app.Services.GetService<AbstractMailWorker>();
mailSender?.MailConfig(new MailConfigBindingModel
{
    MailLogin = builder.Configuration?.GetSection("MailLogin")?.Value?.ToString() ?? string.Empty,
    MailPassword = builder.Configuration?.GetSection("MailPassword")?.Value?.ToString() ?? string.Empty,
    SmtpClientHost = builder.Configuration?.GetSection("SmtpClientHost")?.Value?.ToString() ?? string.Empty,
    SmtpClientPort = Convert.ToInt32(builder.Configuration?.GetSection("SmtpClientPort")?.Value?.ToString()),
    PopHost = builder.Configuration?.GetSection("PopHost")?.Value?.ToString() ?? string.Empty,
    PopPort = Convert.ToInt32(builder.Configuration?.GetSection("PopPort")?.Value?.ToString())
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodOrdersRestApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
