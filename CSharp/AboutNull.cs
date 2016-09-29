using System;
using Xunit;

using Assert = Xunit.KoanHelpers.KoanAssert;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", "02 - About Null")]
    public class AboutNull : Koan
    {
        [Koan(1, DisplayName = "02.01 - NullIsNotAnObject")]
        public void NullIsNotAnObject()
        {
            Assert.True(typeof(object).IsAssignableFrom(null)); //not everything is an object
        }

        [Koan(2, DisplayName = "02.02 - YouGetNullReferenceExceptionWhenCallingMethodsOnNull")]
        public void YouGetNullReferenceExceptionWhenCallingMethodsOnNull()
        {
            //What is the Exception that is thrown when you call a method on a null object?
            //Don't be confused by the code below. It is using Anonymous Delegates which we will
            //cover later on. 
            object nothing = null;

            Assert.Throws<FillMeInException>(delegate () { nothing.ToString(); });

            //What's the message of the exception? What substring or pattern could you test
            //against in order to have a good idea of what the string is?
            try
            {
                nothing.ToString();
            }
            catch (System.Exception ex)
            {
                Assert.Contains(FILL_ME_IN as string, ex.Message);
            }
        }

        [Koan(3, DisplayName = "02.03 - YouCanNowHandleNullObjectsGracefully")]
        public void YouCanNowHandleNullObjectsGracefully()
        {
            //By using the C# 6 "Null-conditional operator" you can avoid NullReferenceException
            //Don't be confused by the code below. It is using Anonymous Delegates which we will
            //cover later on. 
            object nothing = null;

            Assert.DoesNotThrow(delegate () { nothing?.ToString(); });

            object value = nothing?.ToString();

            Assert.Equal(FILL_ME_IN, value);
        }

        [Koan(4, DisplayName = "02.04 - CheckingThatAnObjectIsNull")]
        public void CheckingThatAnObjectIsNull()
        {
            object obj = null;

            Assert.True(obj == FILL_ME_IN);
        }

        [Koan(5, DisplayName = "02.05 - ABetterWayToCheckThatAnObjectIsNull")]
        public void ABetterWayToCheckThatAnObjectIsNull()
        {
            object obj = null;

            Assert.Null(FILL_ME_IN);
        }

        [Koan(6, DisplayName = "02.06 - AWayNotToCheckThatAnObjectIsNull")]
        public void AWayNotToCheckThatAnObjectIsNull()
        {
            object obj = null;

            Assert.True(obj.Equals(null));
        }
    }
}
