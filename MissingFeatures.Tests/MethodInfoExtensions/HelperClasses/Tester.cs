namespace MissingFeatures.Tests.MethodInfoExtensions.HelperClasses
{
    using System;
    using System.IO;

    internal class Tester
    {
        public static void StaticNoReturnValueAndNoParams()
        {
        }

        public static void StaticNoReturnValueAndHasParams(int a)
        {
        }

        public static DateTime StaticHasReturnValueAndNoParams() => DateTime.Now;

        public static Tester StaticHasReturnValueAndHasParams(int a, string b) => null;

        public void NoReturnValueAndNoParams()
        {
        }

        public void NoReturnValueAndHasParams(TimeSpan a)
        {
        }

        public string HasReturnValueAndNoParams() => null;

        public string HasReturnValueAndHasParams(int a, string b, DateTime c) => string.Empty;

        public FileInfo HasReturnValueAndVariableParams(params int[] value) => new FileInfo("test.txt");
    }
}
