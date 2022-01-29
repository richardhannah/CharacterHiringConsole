namespace CharacterHiringConsole;

public class DefaultConfigProvider
{
    public static Dictionary<string, List<string>> GetValidCharacterNameLists()
    {
        var firstNames = new List<string>
        {
            "Michael", "Christopher", "Jessica", "Matthew", "Ashley", "Jennifer", "Joshua", "Amanda", "Daniel", "David",
            "Aamanda"
        };

        var lastNames = new List<string>
        {
            "Chung", "Chen", "Melton", "Hill", "Puckett", "Song", "Hamilton", "Bender", "Wagner", "McLaughlin",
            "McNamara"
        };

        var nickNames = new List<string>
        {
            "Aardvark", "Abide", "Able", "Abnormal", "Abuse", "Abyss", "Acc", "Aces", "Acker", "Acme", "Acrobat"
        };
        return new Dictionary<string, List<string>>
        {
            {"firstname", firstNames},
            {"lastname", lastNames},
            {"nickname", nickNames}
        };
    }
}