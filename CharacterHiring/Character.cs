using Newtonsoft.Json;
using Attribute = CharacterHiring.domain.Attributes.Attribute;

namespace CharacterHiring;

public class Character
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NickName { get; set; }

    public string FullName { get; set; }

    public List<Attribute> Attributes { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}