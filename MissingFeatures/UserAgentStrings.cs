namespace MissingFeatures
{
    using System;
    using System.Reflection;

    public static class UserAgentStrings
    {
        public const string GoogleBot = "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)";

        public static string AssemblyUserAgent => string.Format(
            "{0}/{1} ({2}; {3}; .NET CLR {4}; {5}; {6}.{7})",
            Assembly.GetExecutingAssembly().GetName().Name,
            Assembly.GetExecutingAssembly().GetName().Version,
            Environment.OSVersion,
            Environment.Is64BitOperatingSystem ? "x64" : "x86",
            Environment.Version,
            Environment.MachineName,
            Environment.UserName,
            Environment.ProcessorCount);
    }
}
