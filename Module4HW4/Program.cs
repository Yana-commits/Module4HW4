using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module4HW4.Config;
using Module4HW4.Data;
using Module4HW4.Services.Abstractions;
using Module4HW4.Services;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Repositories;
using Microsoft.Extensions.Logging;
using Module4HW4;

internal class Program
{

    async void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        serviceCollection.AddDbContextFactory<ApplicationDbContext>(opts
            => opts.UseNpgsql(connectionString));
        serviceCollection.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

        serviceCollection
            .AddTransient<ICategoryService, CategoryService>()
            .AddTransient<ICategoryRepository, CategoryRepository>()
            .AddLogging(configure => configure.AddConsole())
            .AddTransient<IPaymentService, PaymentService>()
            .AddTransient<IPaymentRepository, PaymentRepository>()
            .AddTransient<IProductsRepository, ProductsRepository>()
            .AddTransient<IProductsService, ProductsService>()
            .AddTransient<IRequestService, RequestService>()
            .AddTransient<IRequestRepository, RequestRepository>()
            .AddTransient<IShippersService, ShippersService>()
            .AddTransient<IShippersRepository, ShippersRepository>()
            .AddTransient<ISupplierService, SupplierService>()
            .AddTransient<ISupplierRepository, SuppliersRepository>()
            .AddTransient<INotificationService, NotificationService>()
            .AddTransient<App>();

        IConfiguration configuration1 = new ConfigurationBuilder().AddJsonFile("config.json")
            .Build();

        var serviceCollection1 = new ServiceCollection();
        ConfigureServices(serviceCollection1, configuration1);
        var provider = serviceCollection1.BuildServiceProvider();

        var app = provider.GetService<App>();
        await app!.Start();


    }
}