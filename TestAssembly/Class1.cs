namespace TestAssembly;

public interface IClass1
{
    void HelloWorld();
}

public class Class1 : IClass1
{
    public void HelloWorld()
    {
        Console.WriteLine("helloWorld");
    }
}