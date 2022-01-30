using CharacterHiring.domain.NameGenerator;
using CharacterHiring.domain.NameGenerator.NameTypes;

namespace CharacterHiring.domain;

public interface ICharacterFactory
{
    Character Generate { get; }
}

internal class CharacterFactory : ICharacterFactory
{
    private readonly INameFactory<CharacterName> _nameFactory;

    public CharacterFactory(INameFactory<CharacterName> nameFactory)
    {
        _nameFactory = nameFactory;
    }

    public Character Generate
    {
        get
        {
            var generatedName = _nameFactory.Build();

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