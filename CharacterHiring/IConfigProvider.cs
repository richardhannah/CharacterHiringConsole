namespace CharacterHiring;

public interface IConfigProvider
{
    public domain.NameGenerator.Configuration.Configuration LoadConfiguration();
}