using CharacterHiring;
using CharacterHiringConsole;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Modules;
using TestAssembly;

public class Program
{
    public static void Main(string[] args)
    {
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

        var config = new Configuration
        {
            NameLists = DefaultConfigProvider.GetValidCharacterNameLists()
        };

        var kernel = new StandardKernel();

        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.GetExportedTypes().Any(t => t.BaseType == typeof(NinjectModule)));

        kernel.Load(assemblies);

        var characterMarket = kernel.Get<ICharacterMarket>();
        var class1 = kernel.Get<IClass1>();

        class1.HelloWorld();

        characterMarket.Configuration = config;
        characterMarket.Stock();
        var characters = characterMarket.Characters;

        characters.ForEach(c => Console.WriteLine(c.FullName));

        logger.LogDebug("All done!");
    }
}