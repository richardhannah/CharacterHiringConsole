namespace CharacterHiring.NameGenerator;

public class NameFactory<T> : INameFactory where T : new()
{
    public NameFactory()
    {
    }

    public NameFactory(Dictionary<string, List<string>> configuration)
    {
        Configuration = configuration;
    }

    public Dictionary<string, List<string>> Configuration { get; set; }

    public NameData GenerateName()
    {
        var rand = new Random();
        var nameData = new Dictionary<string, string>();

        foreach (var key in Configuration.Keys)
            nameData[key] = Configuration[key][rand.Next(0, Configuration[key].Count)];

        return new NameData
        {
            NameDict = nameData
        };
    }

    public T Build()
    {
        return (T) Activator.CreateInstance(typeof(T), GenerateName());
        ;
    }
}