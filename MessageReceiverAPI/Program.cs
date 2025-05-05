using MessageReceiverAPI.Data;
using Microsoft.EntityFrameworkCore;
using MessageReceiverAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))
    ));

builder.Services.AddControllers();
builder.Services.AddHostedService<RabbitMQConsumer>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
