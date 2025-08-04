using Infrastructure;
using System.Runtime.Loader;

var builder = WebApplication.CreateBuilder(args);

var files = Directory.GetFiles(
            AppDomain.CurrentDomain.BaseDirectory,
            "CleanArchitecture.*.dll");
var assemblies = files
            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

builder.Services.AddCors(options =>
{
    options.AddPolicy("DynamicCors", policy =>
    {
        policy.SetIsOriginAllowed(origin =>
            origin.StartsWith("http://localhost") || origin.StartsWith("https://localhost"))
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.Scan(p => p.FromAssemblies(assemblies)
           .AddClasses()
           .AsMatchingInterface());
var app = builder.Build();
app.UseCors("DynamicCors");


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
