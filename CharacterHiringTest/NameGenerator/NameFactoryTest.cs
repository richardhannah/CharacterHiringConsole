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
        var result = _characterNameTestSubject.Build();

        var firstname = result.FirstName;
        var lastname = result.LastName;
        var nickname = result.NickName;

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


        _townNameTestSubject.Configuration = configuration;
        var result = _townNameTestSubject.Build();

        var firstbit = result.firstBit;
        var secondbit = result.SecondBit;
        var lastbit = result.LastBit;

        Console.WriteLine($"{firstbit} {secondbit} {lastbit}");
    }
}