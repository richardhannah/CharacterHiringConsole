using System.Collections.Generic;
using CharacterHiring;
using CharacterHiring.NameGenerator.NameTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterHiringTest.NameGenerator.NameTypes;

[TestClass]
public class TownNameTest
{
    private NameData _nameData;
    private TownName testSubject;


    [TestInitialize]
    public void Setup()
    {
        _nameData = new NameData
        {
            NameDict = new Dictionary<string, string>
            {
                {"firstbit", "test_firstbit"},
                {"secondbit", "test_secondbit"},
                {"lastbit", "test_lastbit"}
            }
        };

        testSubject = new TownName(_nameData);
    }

    [TestMethod]
    public void DeconstructTownName()
    {
        var (firstbit, secondbit, lastbit) = testSubject;

        Assert.AreEqual(firstbit, "test_firstbit");
        Assert.AreEqual(secondbit, "test_secondbit");
        Assert.AreEqual(lastbit, "test_lastbit");
    }
}