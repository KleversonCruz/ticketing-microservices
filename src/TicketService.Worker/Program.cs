using MassTransit;
using TicketService.Worker.Workers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<QueueTicketCreated>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.UseMessageRetry(r => r.Immediate(5));
                cfg.Host(hostContext.Configuration.GetConnectionString("RabbitMq"));
                cfg.ConfigureEndpoints(context);
            });
        });
    })
    .Build();

await host.RunAsync();
