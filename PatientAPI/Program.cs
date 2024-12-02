using Microsoft.EntityFrameworkCore;
using PatientAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with dependency injection
builder.Services.AddDbContext<PatientDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();

// Minimal APIs
app.MapPost("/patients", async (PatientDbContext context, Patient patient) =>
{
    try
    {
        context.Patients.Add(patient);
        await context.SaveChangesAsync();

        // Return the newly created patient data as part of the response body
        return Results.Created($"/patients/{patient.PatientID}", patient);
    }
    catch (Exception ex)
    {
        // Log the error
        Console.WriteLine($"Error: {ex.Message}");
        return Results.Problem("An error occurred while saving the patient record.");
    }
});



app.MapGet("/patients", async (PatientDbContext context) =>
{
    return await context.Patients.ToListAsync();
});

app.Run();
