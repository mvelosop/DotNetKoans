using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Assert = Xunit.KoanHelpers.KoanAssert;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", "10 - About Abstract Classes and Interfaces")]
    public class AboutAbstractClassesAndInterfaces : Koan
    {
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

        [Koan(1, DisplayName = "10.01 - You can't instantiate an abstract class")]
        public void YouCantInstantiateAnAbstractClass()
        {
            // Uncommenting the next line generates a compiler error
            // var shape = new Shape();

            var triangle = new Triangle();

            Assert.False(triangle is Triangle); // This must be true

            Assert.True(triangle is FillMeIn); // triangle is also a...

            try
            {
                triangle.GetArea();
            }
            catch (Exception ex)
            {
                Assert.True(ex is NotImplementedException);
                //Assert.True(ex is FillMeInException);
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

        public class Glass : IDescribable // this class, unrelated to Cup, also implements IDecribable
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

        [Koan(2, DisplayName = "10.02 - A interface is a contract the class MUST fulfill")]
        public void AnInterfaceIsAContract()
        {
            var redCup = new Cup("Red");
            var blueGlass = new Glass("Blue", "Plastic");

            Assert.Equal(FILL_ME_IN, redCup.Describe());
            Assert.Equal(FILL_ME_IN, blueGlass.Describe());

            // Since C# is strongly typed if a class is said to implement an interface but does not, compilation will fail
            // try commenting out the whole Describe method in Cup or Glass Classes
        }

        public class Circle : Shape, IDescribable
        {
            public Circle(double diameter)
            {
                Diameter = diameter;
                Type = "Circle";
            }

            public double Diameter { get; private set; }

            public string Type { get; private set; }

            public string Describe()
            {
                return $"{Type}: d={Diameter}; area={GetArea()}";
            }

            public override double GetArea()
            {
                return Math.PI * Math.Pow(Diameter / 2d, 2d);
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
                    description.AppendFormat("  {0}: {1}{2}", ++i, item.Describe(), Environment.NewLine);
                };

                return description.ToString();
            }
        }

        [Koan(3, DisplayName = "10.03 - You can use interfaces to group otherwise unrelated items")]
        public void YoCanUseInterfacesToGroupOtherwiseUnrelatedItems()
        {
            var container = new Container();

            container.Items.Add(new Cup("Red"));
            container.Items.Add(new Circle(10));
            container.Items.Add(new TextContainer("Text context"));

            Assert.Equal(FILL_ME_IN, container.Describe());
        }

    }
}
