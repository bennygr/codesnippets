using System.Windows;
using LightCore;

namespace SimpleLightCoreExample
{
    /// <summary>
    ///     Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {            
            ContainerBuilder builder = new ContainerBuilder();            
            
            //Registering contracts
            Register<IDoSomething,ShowAText>(builder);
            //Change to this line in order to change behavior 
            //Register<IDoSomething,DoNothing>(builder);
            
            IocContainer.Container = builder.Build();
            base.OnStartup(e);
        }

        public static void Register<TContract, TImplementation>(ContainerBuilder container)
        {
            container.Register(typeof (TContract), typeof (TImplementation));
        }
    }
}