using System;
using Xunit;

using Assert = Xunit.KoanHelpers.KoanAssert;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", @"02 - About ""null""")]
    public class AboutNull : Koan
    {
        [Koan(1, DisplayName = @"02.01 - ""null"" is not an object")]
        public void NullIsNotAnObject()
        {
            var simpleObject = new object(); // this is the simplest object, not very usefull though

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

        public class RubberBallClass
        {
            public string Color { get; set; }
        }

        [Koan(7, DisplayName = "02.07 - Classes, objects and instances")]
        public void ClassesObjectsAndInstances()
        {
            // A class is like a mold and instances are each individual object created from the mold 
            var redBall = new RubberBallClass { Color = "Red" };
            var blueBall = new RubberBallClass { Color = "Dark Blue" };

            // Each instance (or object) is independent from each other
            blueBall.Color = "Light Blue";

            // Instance and objects are synonyms

            Assert.Equal(FILL_ME_IN, blueBall.Color);
            Assert.Equal(FILL_ME_IN, redBall.Color);
        }

        public class Ball
        {
            public Ball() // This is THE DEFAULT CONSTRUCTOR, without parameters
            {
                Color = "invisible";
                Material = "none (virtual)";
            }

            public Ball(string color)
            {
                Color = color;
                Material = "none (virtual)";
            }

            public Ball(string color, string material)
            {
                Color = color;
                Material = material;
            }

            public string Color { get; private set; }

            public string Material { get; private set; }
        }

        [Koan(8, DisplayName = "02.08 - Classes can have several constructors to simplify object creation")]
        public void ClassesCanHaveSeveralConstructorsToSimplifyObjectCreation()
        {
            var ball = new Ball();
            var redBall = new Ball("Red");
            var bluePlasticBall = new Ball("Dark Blue", "Plastic");

            Assert.Equal(FILL_ME_IN, bluePlasticBall.Color);
            Assert.Equal(FILL_ME_IN, redBall.Material);
        }
    }
}
