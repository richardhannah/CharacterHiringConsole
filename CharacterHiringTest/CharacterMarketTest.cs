using System;
using System.Collections.Generic;
using CharacterHiring;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CharacterHiringTest;


[TestClass]
public class CharacterMarketTest
{
    private CharacterMarket _testSubject;
    private Mock<ICharacterFactory> _characterFactoryMock;
    private Mock<ICharacterStore> _characterStoreMock;

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
        List<Character> chars = new List<Character>();
        for (int i = 0; i < number; i++)
        {
            chars.Add(new Character());
        }

        return chars;
    }
}