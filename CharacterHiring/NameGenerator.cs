namespace CharacterHiring;


public class NameObj
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NickName { get; set; }
}

public interface INameGenerator
{
    NameObj GenerateName();
}

public class NameGenerator : INameGenerator
{
    private List<string> _firstNames;
    private List<string> _lastNames;
    private List<string> _nickNames;

    public NameGenerator()
    {
        _firstNames = new List<string>()
        {
            "Dave", "Arnold"
        };

        _lastNames = new List<string>()
        {
            "Lister", "Rimmer"
        };

        _nickNames = new List<string>()
        {
            "SmegHead", "Ace"
        };
    }

    public NameObj GenerateName()
    {
        Random rand = new Random();
        return new NameObj()
        {
            FirstName = _firstNames[rand.Next(0, _firstNames.Count)],
            LastName = _lastNames[rand.Next(0, _lastNames.Count)],
            NickName = _nickNames[rand.Next(0, _nickNames.Count)],

        };
    }



}