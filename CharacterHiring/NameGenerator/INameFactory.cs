namespace CharacterHiring.NameGenerator;

public interface INameFactory<T>
{
    T Build();
}