using Autofac;

namespace CharacterHiringDummy;

public class AutofacBindings : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Class1>().As<IClass1>();
    }
}