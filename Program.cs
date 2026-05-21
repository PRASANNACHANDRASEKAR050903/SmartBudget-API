using Microsoft.EntityFrameworkCore;
using SmartBudget.API.Data;
using SmartBudget.API.Repository;

var builder = WebApplication.CreateBuilder(args);


// ==========================================
// Add Services
// ==========================================

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository Registration
builder.Services.AddScoped<ExpenseRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<BudgetRepository>();
builder.Services.AddScoped<AISuggestionRepository>();


// ==========================================
// Database Connection
// ==========================================

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    )
);


// ==========================================
// CORS Configuration
// ==========================================

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


// ==========================================
// Build App
// ==========================================

var app = builder.Build();


// ==========================================
// Configure HTTP Pipeline
// ==========================================

// Swagger
app.UseSwagger();
app.UseSwaggerUI();


// Enable CORS
app.UseCors("AllowFrontend");


// HTTPS
app.UseHttpsRedirection();


// Authorization
app.UseAuthorization();


// Map Controllers
app.MapControllers();


// Run App
app.Run();