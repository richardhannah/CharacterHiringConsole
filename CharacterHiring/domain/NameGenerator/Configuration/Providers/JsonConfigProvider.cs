using CharacterHiring.domain.NameGenerator.NameTypes;

namespace CharacterHiring.domain.NameGenerator.Configuration.Providers;

public class JsonConfigProvider : IConfigProvider
{
    public Configuration LoadConfiguration()
    {
        return new Configuration
        {
            ConfigType = typeof(BaseName),
            NameLists = new Dictionary<string, List<string>>()
        };
    }
}