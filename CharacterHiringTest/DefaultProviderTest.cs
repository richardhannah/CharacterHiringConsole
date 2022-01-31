using CharacterHiring;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterHiringTest;

[TestClass]
public class DefaultProviderTest
{
    private DefaultConfigProvider _testSubject;

    [TestInitialize]
    public void Setup()
    {
        _testSubject = new DefaultConfigProvider();
    }

    [TestMethod]
    public void LoadConfigurationReturnsAnObject()
    {
        var result = _testSubject.LoadConfiguration();
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(CharacterHiring.domain.NameGenerator.Configuration.Configuration));
        Assert.IsNotNull(result.NameLists);
        Assert.IsNotNull(result.ConfigType);
    }
}