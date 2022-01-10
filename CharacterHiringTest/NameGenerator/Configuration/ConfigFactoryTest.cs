using System.Collections.Generic;
using CharacterHiring.NameGenerator.Configuration;
using CharacterHiring.NameGenerator.Configuration.Providers;
using CharacterHiring.NameGenerator.NameTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CharacterHiringTest.NameGenerator.Configuration;

[TestClass]
public class ConfigFactoryTest
{
    private Mock<IConfigProvider> _configProviderMock;
    private ConfigFactory _testSubject;

    [TestInitialize]
    public void Setup()
    {
        _configProviderMock = new Mock<IConfigProvider>();
        _testSubject = new ConfigFactory(_configProviderMock.Object);
    }

    [TestMethod]
    public void ConfigFactoryGetsConfig()
    {
        _configProviderMock.Setup(c => c.LoadConfiguration())
            .Returns(new CharacterHiring.NameGenerator.Configuration.Configuration
            {
                ConfigType = typeof(CharacterName),
                NameLists = new Dictionary<string, List<string>>
                {
                    {"testkey", new List<string> {"testval1", "testval2"}}
                }
            });

        var result = _testSubject.GetConfig<CharacterName>();

        Assert.AreEqual(typeof(CharacterName), result.ConfigType);
        Assert.IsTrue(result.NameLists.ContainsKey("testkey"));
        CollectionAssert.AreEquivalent(new List<string> {"testval1", "testval2"}, result.NameLists["testkey"]);
    }
}