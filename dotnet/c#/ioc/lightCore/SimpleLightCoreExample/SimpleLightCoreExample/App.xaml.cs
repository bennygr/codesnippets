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
            builder.Register<IDoSomething,ShowAText>();
            //Change to this line in order to change behavior 
            //Register<IDoSomething,DoNothing>(builder);
            
            IocContainer.Container = builder.Build();
            base.OnStartup(e);
        }        
    }
}