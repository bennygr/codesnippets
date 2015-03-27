using System.Windows.Forms;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace CustomBootstrapperCore
{
    //WiX -- denotes which class is the Managed Bootstrapper    
    //NOTE:
    //IN addition we have to setup our bootstrapper in the AssemblyInfo.cs file
    public class CustomBootstrapperCore : BootstrapperApplication
    {
        protected override void Run()
        {
            MessageBox.Show("Hello World!");
            this.Engine.Quit(0);
        }
    }
}