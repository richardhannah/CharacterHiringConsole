using Ninject.Modules;

namespace CharacterHiringDummy;

public class NinjectBindings : NinjectModule
{
    public override void Load()
    {
        Bind<IClass1>().To<Class1>();
    }
}