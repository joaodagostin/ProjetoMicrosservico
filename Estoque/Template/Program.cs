using EstoqueService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<EstoqueServices>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
