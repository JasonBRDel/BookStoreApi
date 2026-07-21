using BookStoreWorkerService;
using BookStoreWorkerService.DAL;
using BookStoreWorkerService.Data;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"))
            );

        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
