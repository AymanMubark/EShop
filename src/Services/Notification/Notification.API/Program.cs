using EventBus.Messages.Common;
using MassTransit;
using Notification.API.EventBusConsumer;
using Notification.API.Mapper;
using Notification.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IEmailService,EmailService>();
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);


//RabbitMq
builder.Services.AddMassTransit(config => {
    config.AddConsumer<SendEmailConsumer>();
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        cfg.ReceiveEndpoint(EventBusConstants.SendEmailQueue, c =>
        {
            c.ConfigureConsumer<SendEmailConsumer>(ctx);
        });
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
