namespace SimpleExample
{
    /// <summary>
    ///     A simple implementation to create a static "Hello World" fortune cookie
    /// </summary>
    public class StaticFortuneService : IFortuneService
    {
        private FortuneCookie fortuneCookie;

        public FortuneCookie GetACookie()
        {
            if (fortuneCookie == null)
                AddCookie(new FortuneCookie
                          {
                              Author = "Max Mustermann",
                              Message = "Hello World",
                          });
            return fortuneCookie;
        }

        public void AddCookie(FortuneCookie cookie)
        {
            this.fortuneCookie = cookie;
        }
    }
}