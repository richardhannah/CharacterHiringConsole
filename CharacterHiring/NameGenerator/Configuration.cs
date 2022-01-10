namespace CharacterHiring.NameGenerator;

public class Configuration
{
    public Configuration(Type nameType, Dictionary<string, List<string>> nameLists)
    {
        NameLists = nameLists;
        ConfigType = nameType;
    }

    public Type ConfigType { get; init; }

    public Dictionary<string, List<string>> NameLists { get; init; }
}