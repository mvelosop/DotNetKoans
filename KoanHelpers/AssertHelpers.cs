using System;
using Xunit.Sdk;
using static Xunit.Assert;

// Start namespace with "Xunit" so it gets filtered from the stack trace on error test result
namespace Xunit.KoanHelpers
{
    // This class substitutes xUnit's Assert for the Koans in order to hide actual value from the message

    /* To change references to this class include the following line at the end of test classes' file's usings

    using Assert = Xunit.KoanHelpers.Assert;

    */

    public class KoanAssert
    {
        private static string _assertMessage = "You have yet to gain the insight from this Koan!";

		public static object False { get; set; }

		public static void Contains(string expected, string actual)
        {
            try
            {
                Assert.Contains(expected, actual);
            }
            catch
            {
                throw new AssertException(_assertMessage);
            }
        }

        public static void DoesNotThrow(ThrowsDelegate testCode)
        {
            try
            {
                Assert.DoesNotThrow(testCode);
            }
            catch
            {
                throw new AssertException(_assertMessage);
            }
        }

        public static void Equal<T>(T expected, T actual)
        {
            try
            {
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new AssertException(_assertMessage);
            }
        }

        public static void NotEqual<T>(T expected, T actual)
        {
            try
            {
                Assert.NotEqual(expected, actual);
            }
            catch
            {
                throw new AssertException(_assertMessage);
            }
        }

        public static void NotNull(object @object)
        {
            try
            {
                Assert.NotNull(@object);
            }
            catch
            {
                throw new AssertException(_assertMessage);
            }
        }

        public static void Null(object @object)
        {
            try
            {
                Assert.Null(@object);
            }
            catch
            {
                throw new AssertException(_assertMessage);
            }
        }

        public static void Same(object expected, object actual)
        {
            try
            {
                Assert.Same(expected, actual);
            }
            catch
            {
                throw new AssertException(_assertMessage);
            }
        }

        public static T Throws<T>(ThrowsDelegate testCode) where T : Exception
        {
            try
            {
                var ex = Assert.Throws<T>(testCode);

                return ex;
            }
            catch
            {
                throw new AssertException(_assertMessage);
            }
        }

        public static void True(bool condition, string message = null)
        {
            if (!condition)
            {
                throw new AssertException(_assertMessage);
            }
        }
    }
}
