namespace CharacterHiring.domain.NameGenerator;

public interface INameFactory<T>
{
    T Build();
}