using CharacterHiring;
using CharacterHiring.NameGenerator;
using CharacterHiring.NameGenerator.Configuration;
using CharacterHiring.NameGenerator.Configuration.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        //setup our DI
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<ICharacterMarket, CharacterMarket>()
            .AddSingleton(typeof(INameFactory<>), typeof(NameFactory<>))
            .AddSingleton(typeof(IConfigFactory), typeof(ConfigFactory))
            .AddSingleton(typeof(IConfigProvider), typeof(DefaultConfigProvider))
            .AddSingleton(typeof(ICharacterFactory), typeof(CharacterFactory))
            .AddSingleton(typeof(ICharacterStore), typeof(CharacterStore))
            .BuildServiceProvider();

        //configure console logging
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
                .AddConsole();
        });

        ILogger logger = loggerFactory.CreateLogger<Program>();
        logger.LogDebug("Starting application");

        //do the actual work here
        var characterMarket = serviceProvider.GetService<ICharacterMarket>();
        characterMarket.Stock();
        var characters = characterMarket.Characters;

        characters.ForEach(c => Console.WriteLine(c.FullName));

        logger.LogDebug("All done!");
    }
}