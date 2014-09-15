// ------------------------------------------------------------------
// SimpleExampleClient  - MainWindow.xaml.cs 
// Created on: 2014-06-24 - 13:41
//   
// Copyright © 2014 Open-Xchange Inc.
// All rights reserved.
// ------------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Threading;
using System.Windows;
using SimpleExample;
using System.Windows.Threading;

namespace SimpleExampleClient
{
    /// <summary>
    ///     Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Dispatcher uiDispatcher = Dispatcher.CurrentDispatcher;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //tcp binding
                //Uri baseAddress = new Uri("net.tcp://localhost:8999/Fortunes");
                //NetTcpBinding binding = new NetTcpBinding();

                //or use a namened pipe binding 
                Uri baseAddress = new Uri("net.pipe://localhost/Fortunes");
                NetNamedPipeBinding binding = new NetNamedPipeBinding();

                EndpointAddress address = new EndpointAddress(baseAddress);
                //ChannelFactory<IFortuneService> factory = new ChannelFactory<IFortuneService>(binding, address);

                var callbackObject = new InstanceContext(new MyCallbackImplementation());

                DuplexChannelFactory<IFortuneService> factory =
                    new DuplexChannelFactory<IFortuneService>(callbackObject, binding, address);

                //In order to prevent deadlocks we create the channel in a different thread
                IFortuneService host;
                ThreadPool.QueueUserWorkItem(delegate
                                             {
                                                 host = factory.CreateChannel();
                                                 
                                                 host.AddCookie(new FortuneCookie
                                                                {
                                                                    Author = "Superman",
                                                                    Message = "I am super"
                                                                });

                                                 FortuneCookie fortuneCookie = host.GetACookie();
                                                 ShowCookie("Yiippey...I Got a fortune cookie", fortuneCookie);
                                             });
                
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ShowCookie(string additionalMessage,FortuneCookie fortuneCookie)
        {            
            if (!uiDispatcher.CheckAccess())
            {
                uiDispatcher.BeginInvoke(new Action<string, FortuneCookie>(ShowCookie), additionalMessage, fortuneCookie);
                return;
            }
            MessageBox.Show(string.Format("{0} - {1} says: \"{2}\"", additionalMessage, fortuneCookie.Author, fortuneCookie.Message));
        }
    }
}