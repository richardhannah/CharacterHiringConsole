namespace CharacterHiring.NameGenerator;

public class Configuration
{
    public Configuration(Type nameType, Dictionary<string, List<string>> nameLists)
    {
        NameLists = nameLists;
    }

    public Dictionary<string, List<string>> NameLists { get; init; }
}