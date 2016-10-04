using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotNetKoans.CSharp
{
	[Trait("Topic", "10 - About Interfaces [RENUMBER REST]")]
	public class AboutInterfaces
	{
		public abstract class Shape
		{
			public abstract double GetArea();

			public abstract double GetPerimeter();
		}

		public interface IDescribable
		{
			string Describe();
		}

		public class Circle : Shape, IDescribable
		{
			public Circle(double diameter)
			{
				Diameter = diameter;
			}

			public double Diameter { get; private set; }

			public string Describe()
			{
				return $"Circle: d={Diameter}; area={GetArea()}; perimeter={GetPerimeter()}";
			}

			public override double GetArea()
			{
				return Math.PI * Math.Pow(Diameter / 2d, 2d);
			}

			public override double GetPerimeter()
			{
				return Math.PI * Diameter;
			}
		}

		public class Rectangle : Shape, IDescribable
		{
			public Rectangle(double width, double height)
			{
				Width = width;
				Height = height;
			}

			public double Width { get; set; }

			public double Height { get; set; }

			public string Describe()
			{
				return $@"Rectangle: w={Width}; h={Height}; area={GetArea()}; perimeter={GetPerimeter()}";
			}

			public override double GetArea()
			{
				return Width * Height;
			}

			public override double GetPerimeter()
			{
				return Width * 2 + Height * 2;
			}

		}

		public class TextContainer : IDescribable
		{
			public TextContainer(string content)
			{
				Content = content;
			}

			public string Content { get; set; }

			public string Describe()
			{
				return $@"TextContainer: ""{Content}""";
			}
		}

		public class Container : IDescribable
		{
			public Container()
			{
				Items = new List<IDescribable>();
			}

			public ICollection<IDescribable> Items { get; set; }

			public string Describe()
			{
				var result = new StringBuilder();

				result.AppendLine("Container for IDescribables:");

				int i = 0;

				foreach (var item in Items)
				{
					result.AppendFormat("  {0}: {1}\n", ++i, item.Describe());
				};

				return result.ToString();
			}
		}

		[Koan(0)]
		public void ToDo()
		{
			throw new NotImplementedException();
		}
	}
}
