namespace CharacterHiring;

public interface ICharacterFactory
{
    Character Generate { get; }
}

public class CharacterFactory : ICharacterFactory
{
    


    public Character Generate
    {
        get { return new Character(); }
    }
}