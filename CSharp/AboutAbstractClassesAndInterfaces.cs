using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Assert = Xunit.KoanHelpers.KoanAssert;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", "13 - About Classes, Objects, Types and Interfaces")]
    public class AboutClassesObjectsTypesAndInterfaces : Koan
    {
        public class RubberBall
        {
            public string Color { get; set; }
        }

        [Koan(1, DisplayName = "13.01 - Classes, objects and instances")]
        public void ClassesObjectsAndInstances()
        {
            // A class is like a mold and instances are each individual object created from the mold 
            var redBall = new RubberBall { Color = "Red" };
            var blueBall = new RubberBall { Color = "Dark Blue" };

            // Each instance (or object) is independent from each other
            blueBall.Color = "Light Blue";

            // Instance and objects are synonyms

            Assert.Equal(FILL_ME_IN, redBall.Color);

            Assert.Equal(FILL_ME_IN, blueBall.Color);
        }

        [Koan(2, DisplayName = "13.02 - \"Type\" class gets information about any type")]
        public void TypeClassGetsInformationAboutAnyType()
        {
            var rubberBall = new RubberBall();

            Type rubberBallTypeFromClass = typeof(RubberBall);
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

        [Koan(3, DisplayName = "13.03 - Classes can have several constructors to simplify object creation")]
        public void ClassesCanHaveSeveralConstructorsToSimplifyObjectCreation()
        {
            var ball = new Ball();
            var redBall = new Ball("Red");
            var bluePlasticBall = new Ball("Dark Blue", "Plastic");

            Assert.Equal(FILL_ME_IN, ball.Color);

            Assert.Equal(FILL_ME_IN, bluePlasticBall.Color);

            Assert.Equal(FILL_ME_IN, redBall.Material);
        }

        public abstract class Shape
        {
            public abstract double GetArea();

            // Abstract methods don't have any code, but MUST be implemented by derived classes
        }

        public class Triangle : Shape
        {
            // Derived classes MUST implement parent's abstract methods
            public override double GetArea()
            {
                // Even if they don't do anything yet
                throw new NotImplementedException();
            }
        }

        [Koan(4, DisplayName = "13.04 - Abstract classes can only be used to inherit from")]
        public void AbstractClassesCanOnlyBeUsedToInheritFrom()
        {
            // Uncommenting the next line generates a compiler error
            // var shape = new Shape();

            var triangle = new Triangle();

            Assert.Equal(FILL_ME_IN, triangle is Triangle);

            Assert.Equal(FILL_ME_IN, triangle is Shape);

            // A triangle is a shape
            Assert.Equal(FILL_ME_IN, typeof(Shape).IsAssignableFrom(typeof(Triangle)));

            // The above means: whenever I need a Shape, I can use a Triangle

            Assert.Equal(FILL_ME_IN, typeof(Triangle).IsAssignableFrom(typeof(Shape)));

            try
            {
                triangle.GetArea();
            }
            catch (Exception ex)
            {
                Assert.True(ex is FillMeInException);
            }
        }

        public interface IDescribable
        {
            // Requieres a readonly string property called Type
            string Type { get; }

            // Requires a method called Describe that returns a string without any parameters
            string Describe();

            // Interfaces are abstract, they specify "what", don't care about "how", MUST be implemented by the classes
        }

        public class Cup : IDescribable // this means class Cup implements interface IDescribable or "Cup implements IDescribable" for short
        {
            public Cup(string color)
            {
                Color = color;
                Type = "Cup";
            }

            public string Color { get; set; }

            public string Type { get; private set; }

            // It's the class's bussiness to resolve "how" to fulfill the interface
            public string Describe()
            {
                return $"{Type}: ({Color})";
            }
        }

        public class Glass : IDescribable // this class, unrelated to Cup, also implements IDescribable
        {
            public Glass(string color, string material)
            {
                Color = color;
                Material = material;
                Type = "Glass";
            }

            public string Color { get; set; }

            public string Material { get; set; }

            public string Type { get; private set; }

            // If you comment out this method the compiler will alert (try it!)
            public string Describe()
            {
                return $"{Type}: ({Color}, {Material})";
            }
        }

        [Koan(5, DisplayName = "13.05 - A interface is a contract the class MUST fulfill")]
        public void AnInterfaceIsAContractTheClassMustFulfill()
        {
            var redCup = new Cup("Red");
            var blueGlass = new Glass("Blue", "Plastic");

            Assert.Equal(FILL_ME_IN, redCup.Describe());

            Assert.Equal(FILL_ME_IN, blueGlass.Describe());

            // Since C# is strongly typed if a class is said to implement an interface but does not, compilation will fail
            // try commenting out the whole Describe method in Cup or Glass Classes
        }

        [Koan(6, DisplayName = "13.06 - You can also check at rutime if an instance implements an interface")]
        public void YouCanAlsoCheckAtRutimeIfAnInstanceImplementsAnInterface()
        {
            var rubberBall = new RubberBall();
            var cup = new Cup("Red");

            Assert.Equal(FILL_ME_IN, rubberBall is IDescribable);

            Assert.Equal(FILL_ME_IN, cup is IDescribable);

            // If you don't have an instance can also check the Types

            Assert.Equal(FILL_ME_IN, typeof(IDescribable).IsAssignableFrom(typeof(RubberBall)));

            Assert.Equal(FILL_ME_IN, typeof(IDescribable).IsAssignableFrom(typeof(Cup)));

            // Remember: "whenever I need an IDescribable I can use a Cup"
        }

        public class Rectangle : Shape, IDescribable
        {
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
                Type = "Rectangle";
            }

            public double Width { get; private set; }

            public double Height { get; private set; }

            public string Type { get; private set; }

            public string Describe()
            {
                return $"{Type}: w={Width}; h={Height}";
            }

            public override double GetArea()
            {
                return Width * Height;
            }
        }

        public class TextContainer : IDescribable
        {
            public TextContainer(string content)
            {
                Content = content;
                Type = "TextContainer";
            }

            public string Content { get; set; }

            public string Type { get; private set; }

            public string Describe()
            {
                return $@"{Type}: ""{Content}""";
            }
        }

        public class Container : IDescribable
        {
            public Container()
            {
                Items = new List<IDescribable>();
                Type = "Container";
            }

            public string Type { get; private set; }

            public List<IDescribable> Items { get; set; }

            public string Describe()
            {
                var description = new StringBuilder();

                description.AppendLine($"{Type}:");

                int i = 0;

                foreach (var item in Items)
                {
                    description.AppendFormat("{0}: {1}{2}", ++i, item.Describe(), Environment.NewLine);
                };

                return description.ToString();
            }
        }

        [Koan(7, DisplayName = "13.07 - You can use interfaces to group otherwise unrelated items")]
        public void YoCanUseInterfacesToGroupOtherwiseUnrelatedItems()
        {
            var container = new Container();

            container.Items.Add(new Cup("Red"));
            container.Items.Add(new Rectangle(5, 10));
            container.Items.Add(new TextContainer("Text content"));

            string expected = FILL_ME_IN as string;

            Assert.Equal(expected , container.Describe());
        }

        [Koan(8, DisplayName = "13.08 - You can use check types in linq queries")]
        public void YouCanCheckTypesInLinqQueries()
        {
            var container = new Container();

            container.Items.Add(new Cup("Red"));
            container.Items.Add(new Rectangle(5, 10));
            container.Items.Add(new Rectangle(5, 20));
            container.Items.Add(new TextContainer("Text context"));

            var shapes = container.Items.Where(i => i is Shape).Select(i => i.Describe());

            Assert.Equal(FILL_ME_IN, String.Join(", ", shapes));
        }
    }
}
