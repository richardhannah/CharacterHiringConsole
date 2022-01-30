using System.Collections.Generic;
using CharacterHiring;
using CharacterHiring.domain;
using CharacterHiring.domain.NameGenerator;
using CharacterHiring.domain.NameGenerator.NameTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CharacterHiringTest;

[TestClass]
public class CharacterFactoryTest
{
    private Mock<INameFactory<CharacterName>> _nameFactoryMock;
    private CharacterFactory _testSubject;

    [TestInitialize]
    public void Setup()
    {
        _nameFactoryMock = new Mock<INameFactory<CharacterName>>();
        _testSubject = new CharacterFactory(_nameFactoryMock.Object);
    }

    [TestMethod]
    public void generateHasCorrectCharacterName()
    {
        var firstname = "firstname";
        var lastname = "lastname";
        var nickname = "nickname";


        _nameFactoryMock.Setup(ng => ng.Build()).Returns(new CharacterName(
            new NameData
            {
                NameDict = new Dictionary<string, string>
                {
                    {nameof(firstname), firstname},
                    {nameof(lastname), lastname},
                    {nameof(nickname), nickname}
                }
            }
        ));

        var result = _testSubject.Generate;

        Assert.IsInstanceOfType(result, typeof(Character));
        Assert.AreEqual(firstname, result.FirstName);
        Assert.AreEqual(lastname, result.LastName);
        Assert.AreEqual(nickname, result.NickName);
        Assert.AreEqual($"{firstname} \"{nickname}\" {lastname}", result.FullName);
    }
}