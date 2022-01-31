namespace CharacterHiring.domain.Attributes;

public interface IAttributeFactory
{
    List<Attribute> GetAttributes();
}

public class AttributeFactory : IAttributeFactory
{
    public List<Attribute> GetAttributes()
    {
        var rng = new Random();

        return new List<Attribute>
        {
            new() {Name = "Strength", Value = rng.Next(1, 10)},
            new() {Name = "Intelligence", Value = rng.Next(1, 10)},
            new() {Name = "Wisdom", Value = rng.Next(1, 10)},
            new() {Name = "Constitution", Value = rng.Next(1, 10)},
            new() {Name = "Dexterity", Value = rng.Next(1, 10)},
            new() {Name = "Charisma", Value = rng.Next(1, 10)}
        };
    }
}