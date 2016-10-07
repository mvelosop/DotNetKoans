using System;
using Xunit;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", @"02 - About ""null""")]
    public class AboutNull : Koan
    {
        [Koan(1, DisplayName = @"02.01 - ""null"" is not an object")]
        public void NullIsNotAnObject()
        {
            var simpleObject = new object(); // this is the simplest object, not very useful though

            Assert.True(null is object); //not everything is an object
        }

        [Koan(2, DisplayName = "02.02 - You get null reference exception when calling methods on null")]
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
            catch (Exception ex)
            {
                Assert.Contains(FILL_ME_IN as string, ex.Message);
            }
        }

        [Koan(3, DisplayName = "02.03 - You can handle null objects gracefully in C# 6")]
        public void YouCanHandleNullObjectsGracefullyInC6()
        {
            //By using the C# 6 "Null-conditional operator" you can avoid NullReferenceException
            //Don't be confused by the code below. It is using Anonymous Delegates which we will
            //cover later on. 
            object nothing = null;

            Assert.DoesNotThrow(delegate () { nothing?.ToString(); });

            object value = nothing?.ToString();

            Assert.Equal(FILL_ME_IN, value);
        }

        [Koan(4, DisplayName = "02.04 - Checking that an object is null")]
        public void CheckingThatAnObjectIsNull()
        {
            object obj = null;

            Assert.True(obj == FILL_ME_IN);
        }

        [Koan(5, DisplayName = "02.05 - A better way to check that an object is null")]
        public void ABetterWayToCheckThatAnObjectIsNull()
        {
            object obj = null;

            Assert.Null(FILL_ME_IN);
        }

        [Koan(6, DisplayName = "02.06 - A way not to check that an object is null")]
        public void AWayNotToCheckThatAnObjectIsNull()
        {
            object obj = null;

            Assert.True(obj.Equals(null));
        }
    }
}
