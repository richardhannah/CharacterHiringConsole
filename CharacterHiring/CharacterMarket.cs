using CharacterHiring.domain;

namespace CharacterHiring;

public interface ICharacterMarket
{
    int MarketSize { get; set; }
    List<Character> Characters { get; }
    void Stock();
}

public class CharacterMarket : ICharacterMarket
{
    private readonly ICharacterFactory _characterFactory;
    private readonly ICharacterStore _characterStore;
    private readonly int DEFAULT_MARKETSIZE = 10;

    public CharacterMarket(ICharacterFactory characterFactory, ICharacterStore characterStore)
    {
        _characterFactory = characterFactory;
        _characterStore = characterStore;
        MarketSize = DEFAULT_MARKETSIZE;
    }

    public int MarketSize { get; set; }

    public List<Character> Characters { get; private set; } = new();

    public void Stock()
    {
        Characters = _characterStore.GetCharacters();
        var iter = MarketSize - Characters.Count;

        for (var i = 0; i < iter; i++)
        {
            Characters.Add(_characterFactory.Generate);
        }
    }
}