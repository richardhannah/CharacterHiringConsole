using System.Collections.Generic;
using CharacterHiring;
using CharacterHiring.domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CharacterHiringTest;

[TestClass]
public class CharacterMarketTest
{
    private Mock<ICharacterFactory> _characterFactoryMock;
    private Mock<ICharacterStore> _characterStoreMock;
    private CharacterMarket _testSubject;

    [TestInitialize]
    public void Setup()
    {
        _characterFactoryMock = new Mock<ICharacterFactory>();
        _characterStoreMock = new Mock<ICharacterStore>();
        _testSubject = new CharacterMarket(_characterFactoryMock.Object, _characterStoreMock.Object);
    }

    [TestMethod]
    public void MarketContainsCharactersWhenStocked()
    {
        _characterFactoryMock.SetupGet(cf => cf.Generate).Returns(new Character());
        _characterStoreMock.Setup(cs => cs.GetCharacters()).Returns(CreateCharList(0));

        _testSubject.Stock();

        Assert.AreEqual(10, _testSubject.Characters.Count);
    }

    [TestMethod]
    public void MarketCreatesNewCharactersUpToMarketLimit()
    {
        _testSubject.MarketSize = 20;
        _characterFactoryMock.SetupGet(cf => cf.Generate).Returns(new Character());
        _characterStoreMock.Setup(cs => cs.GetCharacters()).Returns(CreateCharList(5));

        _testSubject.Stock();

        Assert.AreEqual(20, _testSubject.Characters.Count);
    }

    private List<Character> CreateCharList(int number)
    {
        var chars = new List<Character>();
        for (var i = 0; i < number; i++)
        {
            chars.Add(new Character());
        }

        return chars;
    }
}