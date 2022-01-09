using System;
using System.Reflection;
using CharacterHiring;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharacterHiringTest;

[TestClass]
public class NameGeneratorTest
{
    private NameGenerator _testSubject;


    [TestInitialize]
    public void Setup()
    {
        _testSubject = new NameGenerator();
    }

    [TestMethod]
    public void devTest1()
    {
        var result = _testSubject.GenerateName();

        Console.WriteLine($"{result.FirstName} \"{result.NickName}\" {result.LastName}");


    }
}