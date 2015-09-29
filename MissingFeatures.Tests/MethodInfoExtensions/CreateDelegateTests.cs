namespace MissingFeatures.Tests.MethodInfoExtensions
{
    using System;
    using System.IO;
    using System.Reflection;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MissingFeatures.Tests.MethodInfoExtensions.HelperClasses;

    [TestClass]
    public class CreateDelegateTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullMethodInfoShouldThrowException()
        {
            MethodInfo methodInfo = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            methodInfo.CreateDelegate();
        }

        [TestMethod]
        public void TestStaticMethodWithNoReturnValueAndNoParamsShouldCreateCorrectDelegate()
        {
            var methodInfo = typeof(Tester).GetMethod(nameof(Tester.StaticNoReturnValueAndNoParams));

            var @delegate = methodInfo.CreateDelegate();

            Assert.IsNull(@delegate.Target);
            Assert.AreEqual(methodInfo, @delegate.Method);
            Assert.IsInstanceOfType(@delegate, typeof(Action));
        }

        [TestMethod]
        public void TestStaticMethodWithNoReturnValueAndHasParamsShouldCreateCorrectDelegate()
        {
            var methodInfo = typeof(Tester).GetMethod(nameof(Tester.StaticNoReturnValueAndHasParams));

            var @delegate = methodInfo.CreateDelegate();

            Assert.IsNull(@delegate.Target);
            Assert.AreEqual(methodInfo, @delegate.Method);
            Assert.IsInstanceOfType(@delegate, typeof(Action<int>));
        }

        [TestMethod]
        public void TestStaticMethodWhichHasReturnValueAndNoParamsShouldCreateCorrectDelegate()
        {
            var methodInfo = typeof(Tester).GetMethod(nameof(Tester.StaticHasReturnValueAndNoParams));

            var @delegate = methodInfo.CreateDelegate();

            Assert.IsNull(@delegate.Target);
            Assert.AreEqual(methodInfo, @delegate.Method);
            Assert.IsInstanceOfType(@delegate, typeof(Func<DateTime>));
        }

        [TestMethod]
        public void TestStaticMethodWhichHasReturnValueAndHasParamsShouldCreateCorrectDelegate()
        {
            var methodInfo = typeof(Tester).GetMethod(nameof(Tester.StaticHasReturnValueAndHasParams));

            var @delegate = methodInfo.CreateDelegate();

            Assert.IsNull(@delegate.Target);
            Assert.AreEqual(methodInfo, @delegate.Method);
            Assert.IsInstanceOfType(@delegate, typeof(Func<int, string, Tester>));
        }

        [TestMethod]
        public void TestInstanceMethodWithNoReturnValueAndNoParamsShouldCreateCorrectDelegate()
        {
            var tester = new Tester();
            var methodInfo = typeof(Tester).GetMethod(nameof(tester.NoReturnValueAndNoParams));

            var @delegate = methodInfo.CreateDelegate(tester);

            Assert.AreSame(tester, @delegate.Target);
            Assert.AreEqual(methodInfo, @delegate.Method);
            Assert.IsInstanceOfType(@delegate, typeof(Action));
        }

        [TestMethod]
        public void TestInstanceMethodWithNoReturnValueAndHasParamsShouldCreateCorrectDelegate()
        {
            var tester = new Tester();
            var methodInfo = typeof(Tester).GetMethod(nameof(tester.NoReturnValueAndHasParams));

            var @delegate = methodInfo.CreateDelegate(tester);

            Assert.AreSame(tester, @delegate.Target);
            Assert.AreEqual(methodInfo, @delegate.Method);
            Assert.IsInstanceOfType(@delegate, typeof(Action<TimeSpan>));
        }

        [TestMethod]
        public void TestInstanceMethodWhichHasReturnValueAndNoParamsShouldCreateCorrectDelegate()
        {
            var tester = new Tester();
            var methodInfo = typeof(Tester).GetMethod(nameof(tester.HasReturnValueAndNoParams));

            var @delegate = methodInfo.CreateDelegate(tester);

            Assert.AreSame(tester, @delegate.Target);
            Assert.AreEqual(methodInfo, @delegate.Method);
            Assert.IsInstanceOfType(@delegate, typeof(Func<string>));
        }

        [TestMethod]
        public void TestInstanceMethodWhichHasReturnValueAndHasParamsShouldCreateCorrectDelegate()
        {
            var tester = new Tester();
            var methodInfo = typeof(Tester).GetMethod(nameof(tester.HasReturnValueAndHasParams));

            var @delegate = methodInfo.CreateDelegate(tester);

            Assert.AreSame(tester, @delegate.Target);
            Assert.AreEqual(methodInfo, @delegate.Method);
            Assert.IsInstanceOfType(@delegate, typeof(Func<int, string, DateTime, string>));
        }

        [TestMethod]
        public void TestInstanceMethodWhichHasReturnValueAndVariableParamsShouldCreateCorrectDelegate()
        {
            var tester = new Tester();
            var methodInfo = typeof(Tester).GetMethod(nameof(tester.HasReturnValueAndVariableParams));

            var @delegate = methodInfo.CreateDelegate(tester);

            Assert.AreSame(tester, @delegate.Target);
            Assert.AreEqual(methodInfo, @delegate.Method);
            Assert.IsInstanceOfType(@delegate, typeof(Func<int[], FileInfo>));
        }
    }
}
