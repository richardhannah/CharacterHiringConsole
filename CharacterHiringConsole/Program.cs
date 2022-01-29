using CharacterHiring;
using CharacterHiringConsole;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Modules;

public class Program
{
    private static ILoggerFactory loggerFactory;
    private static IKernel kernel;

    public static void Main(string[] args)
    {
        //configure console logging
        ConfigureLogging();
        ConfigureDI();

        ILogger logger = loggerFactory.CreateLogger<Program>();
        logger.LogDebug("Starting application");

        //do the actual work here

        var config = new Configuration
        {
            NameLists = DefaultConfigProvider.GetValidCharacterNameLists()
        };

        var characterMarket = kernel.Get<ICharacterMarket>();

        characterMarket.Configuration = config;
        characterMarket.Stock();
        var characters = characterMarket.Characters;

        characters.ForEach(c => Console.WriteLine(c.FullName));

        logger.LogDebug("All done!");
    }

    private static void ConfigureDI()
    {
        kernel = new StandardKernel();

        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.GetExportedTypes().Any(t => t.BaseType == typeof(NinjectModule)));

        kernel.Load(assemblies);
    }

    private static void ConfigureLogging()
    {
        loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
                .AddConsole();
        });
    }
}