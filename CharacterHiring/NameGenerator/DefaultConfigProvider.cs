namespace CharacterHiring.NameGenerator;

public interface IConfigProvider
{
    public Configuration LoadConfiguration();
}

public class DefaultConfigProvider : IConfigProvider
{
    public Configuration LoadConfiguration()
    {
        throw new NotImplementedException();
    }
}