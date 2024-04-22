using BMW.CloudAdoption.Parts.Api.BackgroundServices;
using BMW.CloudAdoption.Parts.Api.Messaging.Kafka;

namespace BMW.CloudAdoption.Parts.Api;

public static class StartupExtensions
{
    private const string CorsPolicy = "CorsPolicy";
    
    public static void ConfigureServices(this IServiceCollection services)
    {
        //---Configure JSON Serialization---//
        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters = AppConstants.JsonSerializerSettings.Converters;
                options.SerializerSettings.ContractResolver = AppConstants.JsonSerializerSettings.ContractResolver;
            });
        
        //---Add Swagger---//
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSwaggerGenNewtonsoftSupport();

        //---Add Services---//
        services.AddScoped<KafkaInitializer>();
        services.AddSingleton<PartsProducer>();
        services.AddSingleton<PartsConsumer>();
        
        services.AddScoped<IPartService, PartService>();
        
        services.AddSingleton<PartsCacheConcurrentDictionary>();
        services.AddScoped<IPartsRepository, PartsCacheRepository>();

        //---Add Background Services---//
        services.AddHostedService<PartsConsumerService>();

        //---Add CORS---//
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy, policyBuilder => policyBuilder
                //.WithOrigins("http://localhost:4200") // the Angular app url
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );
        });
        
        //---Add Health Checks---//
        services.AddHealthChecks();
    }

    public static async Task RunMigrationsAsync(this WebApplication app)
    {
        var scopeServiceProvider = app.Services.CreateScope().ServiceProvider;
        
        var kafkaInitializer = scopeServiceProvider.GetRequiredService<KafkaInitializer>();
        await kafkaInitializer.InitializeAsync();
    }

    public static void ConfigureApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseCors(CorsPolicy);
        app.UseHttpsRedirection();

        app.MapControllers();
        app.MapHealthChecks("/healthz");
    }
}
