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
        _characterNameTestSubject = new NameFactory<CharacterName>();
        _townNameTestSubject = new NameFactory<TownName>();
    }

    [TestMethod]
    public void CharacterNameTest()
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
        var configuration = new Dictionary<string, List<string>>();
        configuration.Add("firstname", firstNames);
        configuration.Add("lastname", lastNames);
        configuration.Add("nickname", nickNames);


        _characterNameTestSubject.Configuration = configuration;
        var result = _characterNameTestSubject.GenerateName();

        var firstname = result.NameDict["firstname"];
        var lastname = result.NameDict["lastname"];
        var nickname = result.NameDict["nickname"];

        Console.WriteLine($"{firstname} \"{nickname}\" {lastname}");
    }

    [TestMethod]
    public void TownNameTest()
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
        var configuration = new Dictionary<string, List<string>>();
        configuration.Add("firstbit", firstbits);
        configuration.Add("secondbit", secondbits);
        configuration.Add("lastbit", lastbits);


        _characterNameTestSubject.Configuration = configuration;
        var result = _characterNameTestSubject.GenerateName();

        var firstbit = result.NameDict["firstbit"];
        var secondbit = result.NameDict["secondbit"];
        var lastbit = result.NameDict["lastbit"];

        Console.WriteLine($"{firstbit} {secondbit} {lastbit}");
    }
}