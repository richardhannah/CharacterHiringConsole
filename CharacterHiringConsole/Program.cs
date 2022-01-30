using System.Reflection;
using Autofac;
using CharacterHiring;
using CharacterHiringConsole;
using CharacterHiringDummy;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Modules;
using Module = Autofac.Module;

public class Program
{
    private static ILoggerFactory loggerFactory;
    private static IKernel kernel;
    private static IContainer Container { get; set; }
    private static Configuration config { get; set; }


    public static void Main(string[] args)
    {
        LoadReferencedAssemblies();

        //configure console logging
        ConfigureLogging();
        ConfigureNinject();
        ConfigureAutofac();

        ILogger logger = loggerFactory.CreateLogger<Program>();
        logger.LogDebug("Starting application");

        //do the actual work here

        config = new Configuration
        {
            NameLists = DefaultConfigProvider.GetValidCharacterNameLists()
        };


        RunWithNinject(config);
        RunWithAutofac(config);

        logger.LogDebug("All done!");
    }

    private static void Execute(ICharacterMarket characterMarket)
    {
        characterMarket.Configuration = config;
        characterMarket.Stock();

        var characters = characterMarket.Characters;

        characters.ForEach(c => Console.WriteLine(c.FullName));
    }

    private static void RunWithNinject(Configuration config)
    {
        Console.WriteLine("running with Ninject");
        Console.WriteLine("=====================");

        var hello = kernel.Get<IClass1>();
        hello.SayHello();

        var characterMarket = kernel.Get<ICharacterMarket>();

        Execute(characterMarket);
    }

    private static void RunWithAutofac(Configuration config)
    {
        Console.WriteLine("running with Autofac");
        Console.WriteLine("=====================");


        using (var scope = Container.BeginLifetimeScope())
        {
            var hello = scope.Resolve<IClass1>();
            hello.SayHello();

            var characterMarket = scope.Resolve<ICharacterMarket>();
            Execute(characterMarket);
        }
    }

    private static void ConfigureNinject()
    {
        kernel = new StandardKernel();

        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.GetExportedTypes().Any(t => t.BaseType == typeof(NinjectModule)));

        kernel.Load(assemblies);
    }

    private static void ConfigureAutofac()
    {
        var builder = new ContainerBuilder();
        // var assembly = typeof(CharacterMarket).Assembly;

        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.GetExportedTypes().Any(t => t.BaseType == typeof(Module)));

        builder.RegisterAssemblyModules(assemblies.ToArray());
        builder.RegisterType<CharacterMarket>().As<ICharacterMarket>();
        builder.RegisterType<Class1>().As<IClass1>();
        Container = builder.Build();
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

    private static void LoadReferencedAssemblies()
    {
        Assembly.GetExecutingAssembly().GetReferencedAssemblies().ToList().ForEach(a => Assembly.Load(a));
    }
}