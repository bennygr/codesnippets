namespace SimpleLightCoreExample
{
    /// <summary>
    /// Implementation of IDoSomething which does nothing
    /// </summary>
    class DoNothing : IDoSomething
    {
        public void DoSomething()
        {            
            return;
        }
    }
}
