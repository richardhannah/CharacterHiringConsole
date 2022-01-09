using System.Collections.Generic;
using CharacterHiring;
using CharacterHiring.NameGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CharacterHiringTest;

[TestClass]
public class CharacterFactoryTest
{
    private Mock<INameFactory> _nameFactoryMock;
    private CharacterFactory _testSubject;

    [TestInitialize]
    public void Setup()
    {
        _nameFactoryMock = new Mock<INameFactory>();
        _testSubject = new CharacterFactory(_nameFactoryMock.Object);
    }

    [TestMethod]
    public void generateHasCorrectCharacterName()
    {
        var firstname = "firstname";
        var lastname = "lastname";
        var nickname = "nickname";


        _nameFactoryMock.Setup(ng => ng.GenerateName()).Returns(new NameData
        {
            NameDict = new Dictionary<string, string>
            {
                {nameof(firstname), firstname},
                {nameof(lastname), lastname},
                {nameof(nickname), nickname}
            }
        });

        var result = _testSubject.Generate;


        Assert.IsInstanceOfType(result, typeof(Character));
        Assert.AreEqual(firstname, result.FirstName);
        Assert.AreEqual(lastname, result.LastName);
        Assert.AreEqual(nickname, result.NickName);
        Assert.AreEqual($"{firstname} \"{nickname}\" {lastname}", result.FullName);
    }
}