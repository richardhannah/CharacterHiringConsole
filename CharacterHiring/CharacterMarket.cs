namespace CharacterHiring;

public class CharacterMarket
{

    private List<Character> _characters = new List<Character>();
    private readonly ICharacterFactory _characterFactory;
    private readonly ICharacterStore _characterStore;
    private readonly int DEFAULT_MARKETSIZE = 10;

    public int MarketSize { get; set; }

    public CharacterMarket(ICharacterFactory characterFactory, ICharacterStore characterStore)
    {
        _characterFactory = characterFactory;
        _characterStore = characterStore;
        MarketSize = DEFAULT_MARKETSIZE;

    }
    public List<Character> Characters
    {
        get { return _characters; }
    }

    public void Stock()
    {
        _characters = _characterStore.GetCharacters();
        int iter = MarketSize - _characters.Count;

        for (int i = 0; i < iter ; i++)
        {
            _characters.Add(_characterFactory.Generate);
        }
    }
}