using Microsoft.EntityFrameworkCore;
using SmartBudget.API.Data;
using SmartBudget.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// Repository Registration
builder.Services.AddScoped<ExpenseRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<BudgetRepository>();
builder.Services.AddScoped<AISuggestionRepository>();

// MySQL Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    )
);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:4200",
                    "https://frolicking-pony-e51e33.netlify.app"
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// IMPORTANT
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();