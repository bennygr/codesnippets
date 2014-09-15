using System.ServiceModel;
using System.Windows;
using SimpleExample;

namespace SimpleExampleClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    class MyCallbackImplementation : IFortuneCallback
    {
        public void OnCookieAdded(FortuneCookie cookie)
        {
            MessageBox.Show("A new cookie has been added: {0}", cookie.Message);
        }
    }
}
