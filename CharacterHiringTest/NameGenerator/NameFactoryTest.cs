using System;
using System.Collections.Generic;
using CharacterHiring.NameGenerator;
using CharacterHiring.NameGenerator.NameTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterHiringTest.NameGenerator;

[TestClass]
public class NameFactoryTest
{
    private NameFactory<CharacterName> _characterNameTestSubject;
    private NameFactory<TownName> _townNameTestSubject;

    [TestInitialize]
    public void Setup()
    {
    }

    [TestMethod]
    public void CharacterNameTest()
    {
        var config = new Configuration(typeof(CharacterName), GetValidCharacterNameLists());

        _characterNameTestSubject = new NameFactory<CharacterName>(config);

        var result = _characterNameTestSubject.Build();

        var firstname = result.FirstName;
        var lastname = result.LastName;
        var nickname = result.NickName;

        Console.WriteLine($"{firstname} \"{nickname}\" {lastname}");
    }

    [TestMethod]
    public void TownNameTest()
    {
        var config = new Configuration(typeof(TownName), GetValidTownNameLists());
        _townNameTestSubject = new NameFactory<TownName>(config);

        var result = _townNameTestSubject.Build();

        var firstbit = result.firstBit;
        var secondbit = result.SecondBit;
        var lastbit = result.LastBit;

        Console.WriteLine($"{firstbit} {secondbit} {lastbit}");
    }

    private Dictionary<string, List<string>> GetValidCharacterNameLists()
    {
        var firstNames = new List<string>
        {
            "Dave", "Arnold"
        };

        var lastNames = new List<string>
        {
            "Lister", "Rimmer"
        };

        var nickNames = new List<string>
        {
            "SmegHead", "Ace"
        };
        return new Dictionary<string, List<string>>
        {
            {"firstname", firstNames},
            {"lastname", lastNames},
            {"nickname", nickNames}
        };
    }

    private Dictionary<string, List<string>> GetValidTownNameLists()
    {
        var firstbits = new List<string>
        {
            "Little", "New", ""
        };

        var secondbits = new List<string>
        {
            "Hampton", "York"
        };

        var lastbits = new List<string>
        {
            "by the sea", "on the weald", ""
        };

        return new Dictionary<string, List<string>>
        {
            {"firstbit", firstbits},
            {"secondbit", secondbits},
            {"lastbit", lastbits}
        };
    }
}