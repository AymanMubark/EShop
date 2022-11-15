using EventBus.Messages.Common;
using EventBus.Messages.Events;
using MassTransit;
using Notification.API.EventBusConsumer;
using Notification.API.Mapper;
using Notification.API.Services;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IEmailService,EmailService>();
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);


//RabbitMq

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));

    x.AddRider(rider =>
    {
        rider.AddConsumer<SendEmailConsumer>();

        rider.UsingKafka((context, k) =>
        {
            k.Host("localhost:9092");

            k.TopicEndpoint<SendEmailEvent>(nameof(SendEmailEvent), GetUniqueName(nameof(SendEmailEvent)), e =>
            {
                // e.AutoOffsetReset = AutoOffsetReset.Latest;
                //e.ConcurrencyLimit = 3;
                e.CheckpointInterval = TimeSpan.FromSeconds(10);
                e.ConfigureConsumer<SendEmailConsumer>(context);

                e.CreateIfMissing(t =>
                {
                    //t.NumPartitions = 2; //number of partitions
                    //t.ReplicationFactor = 1; //number of replicas
                });
            });
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

static string GetUniqueName(string eventName)
{
    string hostName = Dns.GetHostName();
    string callingAssembly = Assembly.GetCallingAssembly().GetName().Name;
    return $"{hostName}.{callingAssembly}.{eventName}";
}