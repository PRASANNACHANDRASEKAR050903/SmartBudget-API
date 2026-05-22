using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SmartBudget.API.Data;
using SmartBudget.API.Repository;

var builder = WebApplication.CreateBuilder(args);


// ==========================================
// Controllers
// ==========================================

builder.Services.AddControllers();


// ==========================================
// Swagger
// ==========================================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ==========================================
// Database Connection
// ==========================================

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion)
);


// ==========================================
// Repository Registration
// ==========================================

builder.Services.AddScoped<ExpenseRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<BudgetRepository>();
builder.Services.AddScoped<AISuggestionRepository>();


// ==========================================
// CORS
// ==========================================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


// ==========================================
// Build App
// ==========================================

var app = builder.Build();


// ==========================================
// Middleware
// ==========================================

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();