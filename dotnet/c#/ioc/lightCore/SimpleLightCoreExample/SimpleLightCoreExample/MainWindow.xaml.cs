using System.Windows;

namespace SimpleLightCoreExample
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            IocContainer.Container.Resolve<IDoSomething>().DoSomething();
        }
    }
}
