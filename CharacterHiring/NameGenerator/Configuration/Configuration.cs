namespace CharacterHiring.NameGenerator.Configuration;

public class Configuration
{
    public Type ConfigType { get; init; }

    public Dictionary<string, List<string>> NameLists { get; init; }
}