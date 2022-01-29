namespace CharacterHiring;

public interface ICharacterStore
{
    List<Character> GetCharacters();
    void SaveCharacters(List<Character> characterList);
}

internal class CharacterStore : ICharacterStore
{
    public List<Character> GetCharacters()
    {
        return new List<Character>();
    }

    public void SaveCharacters(List<Character> characterList)
    {
        Console.WriteLine("saving characters");
    }
}