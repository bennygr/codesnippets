
using System.Windows;

namespace SimpleLightCoreExample
{
    /// <summary>
    /// Implementation of IDoSomething which shows a Message box
    /// </summary>
    class ShowAText : IDoSomething
    {
        public void DoSomething()
        {
            MessageBox.Show("A Text");
        }
    }
}
