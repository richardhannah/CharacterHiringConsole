using CharacterHiring;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterHiringTest;

[TestClass]
public class CharacterFactoryTest
{
    private CharacterFactory _testSubject;

    [TestInitialize]
    public void Setup()
    {
        _testSubject = new CharacterFactory();
    }

    [TestMethod]
    public void generateReturnsCharacterType()
    {
        var result = _testSubject.Generate;

        Assert.IsInstanceOfType(result,typeof(Character));
    }
}