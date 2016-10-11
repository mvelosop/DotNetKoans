using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotNetKoans.CSharp
{
    [Trait("Language", "C#")]
    [Trait("Topic", "C#-03 - About Classes, Objects and Types")]
    public class AboutClassesObjectsAndTypes : Koan
    {
        public class RubberBall
        {
            // This class only has the default constructor, hence, no need to code it.

            public string Color { get; set; }
        }

        [Koan(1, DisplayName = "03.01 - Classes, objects and instances")]
        public void ClassesObjectsAndInstances()
        {
            // A class is like a mold and instances are each individual object created from the mold 
            // The constructor creates a new instance of any class

            var redBall = new RubberBall { Color = "Red" };
            var blueBall = new RubberBall { Color = "Dark Blue" };

            // Each instance (or object) is independent from each other
            blueBall.Color = "Light Blue";

            // Instance and objects are synonyms

            Assert.Equal(FILL_ME_IN, redBall.Color);

            Assert.Equal(FILL_ME_IN, blueBall.Color);
        }

        [Koan(2, DisplayName = "03.02 - \"Type\" class gets information about any type")]
        public void TypeClassGetsInformationAboutAnyType()
        {
            var rubberBall = new RubberBall();

            // Use typeof to get Type info for a Class
            Type rubberBallTypeFromClass = typeof(RubberBall);

            // Use .GetType() to get Type info for an instance
            Type rubberBallTypeFromInstance = rubberBall.GetType();

            Assert.Equal(FILL_ME_IN, rubberBallTypeFromClass.Name);

            Assert.Equal(FILL_ME_IN, rubberBallTypeFromInstance.Name);

            Assert.Equal(FILL_ME_IN, rubberBallTypeFromClass == rubberBallTypeFromInstance);

            Assert.Equal(FILL_ME_IN, rubberBall.GetType() == typeof(RubberBall));

            // The line above compares references so both are the same instance

            // If we have to evaluate an instance we can use the "is" operator
            Assert.Equal(FILL_ME_IN, rubberBall is RubberBall);
        }

        public class Ball
        {
            // If you need a default constructor and also have special ones, you MUST code the DEFAULT CONSTRUCTOR, or else...
            // it will not exist.

            public Ball() // This is THE DEFAULT CONSTRUCTOR, without parameters
            {
                Color = "invisible";
                Material = "none (virtual)";
            }

            // Try commenting out the default constructor

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

            public string Color { get; set; }

            public string Material { get; set; }
        }

        [Koan(3, DisplayName = "03.03 - Classes can have several constructors to simplify object creation")]
        public void ClassesCanHaveSeveralConstructorsToSimplifyObjectCreation()
        {
            var ball = new Ball();
            var redBall = new Ball("Red");
            var bluePlasticBall = new Ball("Dark Blue", "Plastic");

            Assert.Equal(FILL_ME_IN, ball.Color);

            Assert.Equal(FILL_ME_IN, bluePlasticBall.Color);

            Assert.Equal(FILL_ME_IN, redBall.Material);
        }

        public class SportBall : Ball
        {
            public string Sport { get; set; }
        }

        [Koan(4, DisplayName = "There are several ways to check types")]
        public void ThereAreSeveralWaysToCheckTypes()
        {
            var tennisBall = new SportBall { Color = "Yellow", Material = "Compressed air, Rubber", Sport = "Tennis" };
            var rubberBall = new RubberBall { Color = "Red" };
            var demolitionBall = new Ball("Black", "Iron");

            Assert.Equal(FILL_ME_IN, tennisBall is SportBall);

            Assert.Equal(FILL_ME_IN, tennisBall is Ball);

            Assert.Equal(FILL_ME_IN, tennisBall is RubberBall);

            Assert.Equal(FILL_ME_IN, rubberBall is RubberBall);

            Assert.Equal(FILL_ME_IN, rubberBall is Ball);

            Assert.Equal(FILL_ME_IN, demolitionBall.GetType() == typeof(Ball));

            Assert.Equal(FILL_ME_IN, rubberBall.GetType() == typeof(Ball));

            Assert.Equal(FILL_ME_IN, tennisBall.GetType() == typeof(SportBall));

            Assert.Equal(FILL_ME_IN, typeof(SportBall).IsAssignableFrom(tennisBall.GetType()));

            Assert.Equal(FILL_ME_IN, typeof(Ball).IsAssignableFrom(tennisBall.GetType()));

            Assert.Equal(FILL_ME_IN, typeof(SportBall).IsAssignableFrom(demolitionBall.GetType()));

            Assert.Equal(FILL_ME_IN, typeof(Ball).IsAssignableFrom(typeof(SportBall)));

            Assert.Equal(FILL_ME_IN, typeof(SportBall).IsAssignableFrom(typeof(Ball)));
        }
    }
}
