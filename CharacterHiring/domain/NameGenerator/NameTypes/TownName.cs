namespace CharacterHiring.domain.NameGenerator.NameTypes;

public class TownName : BaseName
{
    public TownName(NameData nameData) : base(nameData)
    {
    }

    public TownName()
    {
        _nameData = new NameData();
    }

    public string firstBit => _nameData.NameDict["firstbit"];
    public string SecondBit => _nameData.NameDict["secondbit"];
    public string LastBit => _nameData.NameDict["lastbit"];

    public void Deconstruct(out string firstbit, out string secondbit, out string lastbit)
    {
        firstbit = _nameData.NameDict[nameof(firstbit)];
        secondbit = _nameData.NameDict[nameof(secondbit)];
        lastbit = _nameData.NameDict[nameof(lastbit)];
    }
}