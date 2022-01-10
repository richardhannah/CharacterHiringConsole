using System;
using System.Collections.Generic;
using CharacterHiring.NameGenerator;
using CharacterHiring.NameGenerator.Configuration;
using CharacterHiring.NameGenerator.NameTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CharacterHiringTest.NameGenerator;

[TestClass]
public class NameFactoryTest
{
    private NameFactory<CharacterName>? _characterNameTestSubject;

    private Mock<IConfigFactory> _configFactoryMock;
    private NameFactory<TownName> _townNameTestSubject;

    [TestInitialize]
    public void Setup()
    {
        _configFactoryMock = new Mock<IConfigFactory>();
    }

    [TestMethod]
    public void CharacterNameTest()
    {
        var config =
            new CharacterHiring.NameGenerator.Configuration.Configuration
            {
                ConfigType = typeof(CharacterName),
                NameLists = GetValidCharacterNameLists()
            };
        _configFactoryMock.Setup(c => c.GetConfig<It.IsAnyType>()).Returns(config);

        _characterNameTestSubject = new NameFactory<CharacterName>(_configFactoryMock.Object);

        var result = _characterNameTestSubject.Build();

        var firstname = result.FirstName;
        var lastname = result.LastName;
        var nickname = result.NickName;

        Console.WriteLine($"{firstname} \"{nickname}\" {lastname}");
    }

    [TestMethod]
    public void TownNameTest()
    {
        var config =
            new CharacterHiring.NameGenerator.Configuration.Configuration
            {
                ConfigType = typeof(TownName),
                NameLists = GetValidTownNameLists()
            };

        _configFactoryMock.Setup(c => c.GetConfig<It.IsAnyType>()).Returns(config);

        _townNameTestSubject = new NameFactory<TownName>(_configFactoryMock.Object);

        var result = _townNameTestSubject.Build();

        var firstbit = result.firstBit;
        var secondbit = result.SecondBit;
        var lastbit = result.LastBit;

        Console.WriteLine($"{firstbit} {secondbit} {lastbit}");
    }

    [TestMethod]
    public void ThrowsExceptionWhenInvalidConfigurationSupplied()
    {
        var config =
            new CharacterHiring.NameGenerator.Configuration.Configuration
            {
                ConfigType = typeof(TownName),
                NameLists = GetValidTownNameLists()
            };

        _configFactoryMock.Setup(c => c.GetConfig<It.IsAnyType>()).Returns(config);

        try
        {
            _characterNameTestSubject = new NameFactory<CharacterName>(_configFactoryMock.Object);
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Invalid configuration: CharacterHiring.NameGenerator.NameTypes.CharacterName is required",
                ex.Message);
        }
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