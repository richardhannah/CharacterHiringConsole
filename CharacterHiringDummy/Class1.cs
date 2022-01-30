namespace CharacterHiringDummy;

public interface IClass1
{
    void SayHello();
}

public class Class1 : IClass1
{
    public void SayHello()
    {
        Console.WriteLine("Hello world");
    }
}