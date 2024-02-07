namespace MyTestApp.Helpers
{
    internal class App
    {
        public static User CurrentUser { get; internal set; }
        public static string LogFile { get; internal set; }
        public static EventService Service { get; internal set; }
    }
}