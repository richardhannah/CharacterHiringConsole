using System.Collections.Generic;
using CharacterHiring.NameGenerator;
using CharacterHiring.NameGenerator.NameTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterHiringTest.NameGenerator.NameTypes;

[TestClass]
public class CharacterNameTest
{
    private NameData _nameData;
    private CharacterName testSubject;


    [TestInitialize]
    public void Setup()
    {
        _nameData = new NameData
        {
            NameDict = new Dictionary<string, string>
            {
                {"firstname", "test_firstname"},
                {"lastname", "test_lastname"},
                {"nickname", "test_nickname"}
            }
        };

        testSubject = new CharacterName(_nameData);
    }

    [TestMethod]
    public void DeconstructCharacterName()
    {
        var (firstname, lastname, nickname) = testSubject;

        Assert.AreEqual(firstname, "test_firstname");
        Assert.AreEqual(lastname, "test_lastname");
        Assert.AreEqual(nickname, "test_nickname");
    }
}