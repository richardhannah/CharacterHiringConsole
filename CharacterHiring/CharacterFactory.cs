using CharacterHiring.NameGenerator;
using CharacterHiring.NameGenerator.NameTypes;

namespace CharacterHiring;

public interface ICharacterFactory
{
    Character Generate { get; }
}

public class CharacterFactory : ICharacterFactory
{
    private readonly INameFactory _nameFactory;

    public CharacterFactory(INameFactory nameFactory)
    {
        _nameFactory = nameFactory;
    }

    public Character Generate
    {
        get
        {
            var generatedName = new CharacterName(_nameFactory.GenerateName());

            var (firstname, lastname, nickname) = generatedName;

            return new Character
            {
                FirstName = firstname,
                LastName = lastname,
                NickName = nickname,
                FullName = $"{firstname} \"{nickname}\" {lastname}"
            };
        }
    }
}