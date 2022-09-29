using Microsoft.EntityFrameworkCore;
using SupportChat.BLL.Interfaces;
using SupportChat.BLL.Services;
using SupportChat.DAL.EF;
using SupportChat.RabbitMQ;
using SupportChat.RabbitMQ.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(options => options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

builder.Services.AddCors();
builder.Services.AddAntiforgery(o => o.HeaderName = "X-XSRF-TOKEN");
builder.Services.AddTransient<IRabbitMqService, RabbitMqService>();
builder.Services.AddTransient<IMessageService, MessageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<MessageHub>("/messageHub");
app.UseHttpsRedirection();
app.UseCors(builder =>
    builder.AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod()
  );
app.UseAuthorization();

app.MapControllers();

app.Run();
