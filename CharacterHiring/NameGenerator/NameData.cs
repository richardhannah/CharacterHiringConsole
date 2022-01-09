namespace CharacterHiring.NameGenerator;

public class NameData
{
    public NameData()
    {
        NameDict = new Dictionary<string, string>();
    }

    public Dictionary<string, string> NameDict { get; init; }
}