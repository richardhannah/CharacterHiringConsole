using Ninject.Modules;
using TestAssembly;

namespace CharacterHiringConsole;

public class TestAssemblyBindings : NinjectModule
{
    public override void Load()
    {
        Bind<IClass1>().To<Class1>();
    }
}