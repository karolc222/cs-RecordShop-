using Microsoft.EntityFrameworkCore;
using RecordShop.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//database configuration 
if (builder.Environment.IsDevelopment())
{
    //inmemory database
    builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("RecordShopDevDb"));
} else {
    //SQL server 
    builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
}

var app = builder.Build();

// Configure the HTTP request pipeline/middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


