using CharacterHiring.domain.NameGenerator.Configuration.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterHiringTest.NameGenerator.Configuration.Providers;

[TestClass]
public class JsonConfigProviderTest
{
    private JsonConfigProvider _testSubject;

    [TestInitialize]
    public void Setup()
    {
        _testSubject = new JsonConfigProvider();
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