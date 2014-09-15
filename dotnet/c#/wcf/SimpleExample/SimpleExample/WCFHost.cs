using System;
using System.ServiceModel;
using System.Windows;

namespace SimpleExample
{
    /// <summary>
    ///     Host class of the remote service
    /// </summary>
    internal class WcfHost
    {
        private ServiceHost host;

        public void Start()
        {
            try
            {
                host = new ServiceHost(typeof (RandomFortuneService));

                //tcp binding
                //Uri baseAddress = new Uri("net.tcp://localhost:8999/Fortunes");
                //NetTcpBinding binding = new NetTcpBinding();

                //or use a named pipe binding
                Uri baseAddress = new Uri("net.pipe://localhost/Fortunes");
                NetNamedPipeBinding binding = new NetNamedPipeBinding();

                host.AddServiceEndpoint(typeof (IFortuneService), binding, baseAddress);
                host.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Stop()
        {
            host.Close();
            host = null;
        }
    }
}