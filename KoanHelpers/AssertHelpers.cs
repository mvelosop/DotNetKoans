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

    public class Assert
    {
        private static string _assertMessage = "You have yet to gain the insight from this Koan!";

        public static void Contains(string expected, string actual)
        {
            try
            {
                Xunit.Assert.Contains(expected, actual);
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
                Xunit.Assert.DoesNotThrow(testCode);
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
                Xunit.Assert.Equal(expected, actual);
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
                Xunit.Assert.NotEqual(expected, actual);
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
                Xunit.Assert.NotNull(@object);
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
                Xunit.Assert.Null(@object);
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
                Xunit.Assert.Same(expected, actual);
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
                var ex = Xunit.Assert.Throws<T>(testCode);

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
