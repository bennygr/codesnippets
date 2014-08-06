using System;
using System.ServiceModel;

namespace SimpleExample
{
    /// <summary>
    /// A POCO class used by the service
    /// </summary>
    public class FortuneCookie
    {
        public string Message { get; set; }
        public string Author { get; set; }
    }

    /// <summary>
    /// A simple Callback contract which is used by the "Server" to callback a client
    /// </summary>
    public interface IFortuneCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnCookieAdded(FortuneCookie cookie);
    }

    /// <summary>
    ///     An simple service which should be accessible by a client
    /// </summary>    
    [ServiceContract(CallbackContract = typeof(IFortuneCallback))]
    public interface IFortuneService
    {
        [OperationContract]
        FortuneCookie GetACookie();

        [OperationContract]
        void AddCookie(FortuneCookie cookie);
    }
}