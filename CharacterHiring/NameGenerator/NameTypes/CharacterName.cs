namespace CharacterHiring.NameGenerator.NameTypes;

public class CharacterName : BaseName
{
    public CharacterName(NameData nameData) : base(nameData)
    {
    }

    public CharacterName()
    {
        _nameData = new NameData();
    }

    public string FirstName => _nameData.NameDict["firstname"];
    public string LastName => _nameData.NameDict["lastname"];
    public string NickName => _nameData.NameDict["nickname"];

    public void Deconstruct(out string firstname, out string lastname, out string nickname)
    {
        firstname = _nameData.NameDict[nameof(firstname)];
        lastname = _nameData.NameDict[nameof(lastname)];
        nickname = _nameData.NameDict[nameof(nickname)];
    }
}