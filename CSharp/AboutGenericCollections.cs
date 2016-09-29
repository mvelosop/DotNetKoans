using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using System.Linq;

using Assert = Xunit.KoanHelpers.KoanAssert;

namespace DotNetKoans.CSharp
{
	[Trait("Topic", "04 - About Generic Collections")]
	public class AboutGenericCollections : Koan
	{
		[Koan(1, DisplayName = "04.01 - ArrayListSizeIsDynamic")]
		public void ArrayListSizeIsDynamic()
		{
			//When you worked with Array, the fact that Array is fixed size was glossed over.
			//The size of an array cannot be changed after you allocate it. To get around that
			//you need a class from the System.Collections namespace such as ArrayList
			ArrayList list = new ArrayList();

			Assert.Equal(FILL_ME_IN, list.Count);

			list.Add(42);

			Assert.Equal(FILL_ME_IN, list.Count);
		}

		[Koan(2, DisplayName = "04.02 - ArrayListHoldsObjects")]
		public void ArrayListHoldsObjects()
		{
			ArrayList list = new ArrayList();

			System.Reflection.MethodInfo method = list.GetType().GetMethod("Add");

			Assert.Equal(typeof(FillMeIn), method.GetParameters()[0].ParameterType);
		}

		[Koan(3, DisplayName = "04.03 - MustCastWhenRetrieving")]
		public void MustCastWhenRetrieving()
		{
			//There are a few problems with ArrayList holding object references. The first 
			//is that you must cast the items you fetch back to the original type.
			ArrayList list = new ArrayList();

			list.Add(42);

			int x = 0;

			//x = (int)list[0];

			Assert.Equal(x, 42);
		}

		[Koan(4, DisplayName = "04.04 - ArrayListIsNotStronglyTyped")]
		public void ArrayListIsNotStronglyTyped()
		{
			//Having to cast everywhere is tedious. But there is also another issue lurking
			//ArrayList can hold more than one type. 
			ArrayList list = new ArrayList();

			list.Add(42);
			list.Add("fourty two");

			Assert.Equal(FILL_ME_IN, list[0]);
			Assert.Equal(FILL_ME_IN, list[1]);

			//While there are a few cases where it could be nice, instead what it means is that 
			//anytime your code works with an array list you have to check that the element is 
			//of the type you expect.
		}

		[Koan(5, DisplayName = "04.05 - Boxing")]
		public void Boxing()
		{
			short s = 5;
			object os = s;

			Assert.Equal(s.GetType(), os.GetType());
			Assert.NotEqual(s, os); // This should be Equal

			//While this it is true that everything is an object, Not everything is quite as it seems.
			//Under the covers .Net allocates memory for all value type objects (int, double, bool,...) on the stack. This is 
			//considerably more efficient than a heap allocation. .Net also has the ability to put a value type onto the heap.
			//(for calling methods and other reasons). The process of putting stack data into the heap is called "boxing" the 
			//process of taking the value type off the heap is called "unboxing". We won't go into the details (see Jeffrey 
			//Richter's book if you want details). This subject comes up because every time you put a value type into an 
			//ArrayList it must be boxed. Every time you read it from the ArrayList it must be unboxed. This can be a significat
			//cost.
		}

		[Koan(6, DisplayName = "04.06 - ABetterDynamicSizeContainer")]
		public void ABetterDynamicSizeContainer()
		{
			//ArrayList is a .Net 1.0 container. With .Net 2.0 generics were introduced and with it a new set of collections in
			//System.Collections.Generic The array like container is List<T>. List<T> (read "list of T") is a generic class. 
			//The "T" in the definition of List<T> is the type argument. You cannot declare an instace of List<T> without also
			//supplying a type in place of T.
			var list = new List<int>();

			Assert.Equal(FILL_ME_IN, list.Count);

			list.Add(42);

			Assert.Equal(FILL_ME_IN, list.Count);

			//Now just like int[], you can have a type safe dynamic sized container
			//list.Add("fourty two"); //<--Unlike ArrayList this is illegal.

			//List<T> also solves the boxing/unboxing issues of ArrayList. Unfortunately, you'll have to take Microsoft's word for it
			//as I can't find a way to prove it without some ugly MSIL beyond the scope of these Koans.
		}

		public class Widget
		{
		}

		[Koan(7, DisplayName = "04.07 - ListWorksWithAnyType")]
		public void ListWorksWithAnyType()
		{
			//Just as with Array, list will work with any type
			List<Widget> list = new List<Widget>();

			list.Add(new Widget());

			Assert.Equal(FILL_ME_IN, list.Count);
		}

		[Koan(8, DisplayName = "04.08 - InitializingWithValues")]
		public void InitializingWithValues()
		{
			//Like array you can create a list with an initial set of values easily
			var list = new List<int> { 1, 2, 3 };

			Assert.Equal(FILL_ME_IN, list.Count);
		}

		[Koan(9, DisplayName = "04.09 - AddMultipleItems")]
		public void AddMultipleItems()
		{
			//You can add multiple items to a list at once
			List<int> list = new List<int>();

			list.AddRange(new[] { 1, 2, 3 });

			Assert.Equal(FILL_ME_IN, list.Count);
		}

		[Koan(10, DisplayName = "04.10 - RandomAccess")]
		public void RandomAccess()
		{
			//Just as with array, you can use the subscript notation to access any element in a list.
			List<int> list = new List<int> { 5, 6, 7 };

			Assert.Equal(FILL_ME_IN, list[2]);
		}

		[Koan(11, DisplayName = "04.11 - BeyondTheLimits")]
		public void BeyondTheLimits()
		{
			List<int> list = new List<int> { 1, 2, 3 };

			//You cannot attempt to get data that doesn't exist
			Assert.Throws<FillMeInException>(delegate() { int x = list[3]; });
		}

		[Koan(12, DisplayName = "04.12 - ConvertingToFixedSizeArray")]
		public void ConvertingToFixedSizeArray()
		{
			List<int> list = new List<int> { 1, 2, 3 };

			Assert.Equal(FILL_ME_IN, list.ToArray());
		}

		[Koan(13, DisplayName = "04.13 - InsertingInTheMiddle")]
		public void InsertingInTheMiddle()
		{
			List<int> list = new List<int> { 1, 2, 3 };

			list.Insert(1, 6);

			Assert.Equal(FILL_ME_IN, list.ToArray());
		}

		[Koan(14, DisplayName = "04.14 - RemovingItems")]
		public void RemovingItems()
		{
			List<int> list = new List<int> { 2, 1, 2, 3 };

			list.Remove(2);

			Assert.Equal(FILL_ME_IN, list.ToArray());
		}

		[Koan(15, DisplayName = "04.15 - BasicStackPushingAndPopping")]
		public void BasicStackPushingAndPopping()
		{
			var array = new[] { 1, 2 };

			Stack stack = new Stack(array);

			stack.Push("last");

			Assert.Equal(FILL_ME_IN, stack.ToArray());

			var poppedValue = stack.Pop();

			Assert.Equal(FILL_ME_IN, poppedValue);
			Assert.Equal(FILL_ME_IN, stack.ToArray());
		}

		[Koan(16, DisplayName = "04.16 - GenericStackPushPop")]
		public void GenericStackPushPop()
		{
			var stack = new Stack<int>();

			Assert.Equal(FILL_ME_IN, stack.Count);

			stack.Push(42);

			Assert.Equal(FILL_ME_IN, stack.Count);

			int x = stack.Pop();

			Assert.Equal(FILL_ME_IN, x);
			Assert.Equal(FILL_ME_IN, stack.Count);
		}

		[Koan(17, DisplayName = "04.17 - StackOrder")]
		public void StackOrder()
		{
			var stack = new Stack<int>();

			stack.Push(1);
			stack.Push(2);
			stack.Push(3);

			Assert.Equal(FILL_ME_IN, stack.ToArray());
		}

		[Koan(18, DisplayName = "04.18 - PeekingIntoAQueue")]
		public void PeekingIntoAQueue()
		{
			Queue<string> queue = new Queue<string>();

			queue.Enqueue("one");

			Assert.Equal(FILL_ME_IN, queue.Peek());

			queue.Enqueue("two");

			Assert.Equal(FILL_ME_IN, queue.Peek());
		}

		[Koan(19, DisplayName = "04.19 - RemovingItemsFromTheQueue")]
		public void RemovingItemsFromTheQueue()
		{
			Queue<string> queue = new Queue<string>();

			queue.Enqueue("one");
			queue.Enqueue("two");

			Assert.Equal(FILL_ME_IN, queue.Dequeue());
			Assert.Equal(FILL_ME_IN, queue.Count);
		}

		[Koan(20, DisplayName = "04.20 - Shifting")]
		public void Shifting()
		{
			//Shift == Remove First Element
			//Unshift == Insert Element at Beginning
			//C# doesn't provide this natively. You have a couple
			//of options, but we'll use the LinkedList<T> to implement
			var array = new[] { "Hello", "World" };
			var list = new LinkedList<string>(array);

			list.AddFirst("Say");

			Assert.Equal(FILL_ME_IN, list.ToArray());

			list.RemoveLast();

			Assert.Equal(FILL_ME_IN, list.ToArray());

			list.RemoveFirst();

			Assert.Equal(FILL_ME_IN, list.ToArray());

			list.AddAfter(list.Find("Hello"), "World");

			Assert.Equal(FILL_ME_IN, list.ToArray());
		}

		[Koan(21, DisplayName = "04.21 - AddingToADictionary")]
		public void AddingToADictionary()
		{
			//Dictionary<TKey, TValue> is .Net's key value store. The key and the value do not need to be the same types.
			Dictionary<int, string> dictionary = new Dictionary<int, string>();

			Assert.Equal(FILL_ME_IN, dictionary.Count);

			dictionary[1] = "one";

			Assert.Equal(FILL_ME_IN, dictionary.Count);
		}

		[Koan(22, DisplayName = "04.22 - AccessingData")]
		public void AccessingData()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			dictionary["one"] = "uno";
			dictionary["two"] = "dos";

			//The most common way to locate data is with the subscript notation.
			Assert.Equal(FILL_ME_IN, dictionary["one"]);
			Assert.Equal(FILL_ME_IN, dictionary["two"]);
		}

		[Koan(23, DisplayName = "04.23 - AccessingDataNotAdded")]
		public void AccessingDataNotAdded()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			dictionary["one"] = "uno";

			Assert.Throws<FillMeInException>(delegate() { string s = dictionary["two"]; });
		}

		[Koan(24, DisplayName = "04.24 - CatchingMissingData")]
		public void CatchingMissingData()
		{
			//To deal with the throw when data is not there, you could wrap the data access in a try/catch block...
			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			dictionary["one"] = "uno";

			string result;

			try
			{
				result = dictionary["two"];
			}
			catch (Exception ex)
			{
				result = "dos";
			}

			Assert.Equal(FILL_ME_IN, result);
		}

		[Koan(25, DisplayName = "04.25 - KeyExists")]
		public void KeyExists()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			dictionary["one"] = "uno";

			Assert.Equal(FILL_ME_IN, dictionary.ContainsKey("one"));
			Assert.Equal(FILL_ME_IN, dictionary.ContainsKey("two"));
		}

		[Koan(26, DisplayName = "04.26 - ValueExists")]
		public void ValueExists()
		{
			// This should have been at the top
			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			dictionary["one"] = "uno";

			Assert.Equal(FILL_ME_IN, dictionary.ContainsValue("uno"));
			Assert.Equal(FILL_ME_IN, dictionary.ContainsValue("dos"));
		}

		[Koan(27, DisplayName = "04.27 - PreCheckForMissingData")]
		public void PreCheckForMissingData()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			dictionary["one"] = "uno";

			string result;

			if (dictionary.ContainsKey("two"))
			{
				result = dictionary["two"];
			}
			else
			{
				result = "dos";
			}

			Assert.Equal(FILL_ME_IN, result);
		}

		[Koan(28, DisplayName = "04.28 - TryGetValueForMissingData")]
		public void TryGetValueForMissingData()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			dictionary["one"] = "uno";

			string result;

			if (!dictionary.TryGetValue("one", out result))
			{
				result = "is the lonliest number";
			}

			Assert.Equal(FILL_ME_IN, result);

			if (!dictionary.TryGetValue("two", out result))
			{
				result = "dos";
			}

			Assert.Equal(FILL_ME_IN, result);
		}

		[Koan(29, DisplayName = "04.29 - InitializingADictionary")]
		public void InitializingADictionary()
		{
			//Although it is not common, you can initialize a dictionary...
			var dictionary = new Dictionary<string, string> { { "one", "uno" }, { "two", "dos" } };

			Assert.Equal(FILL_ME_IN, dictionary["one"]);
			Assert.Equal(FILL_ME_IN, dictionary["two"]);
		}

		[Koan(30, DisplayName = "04.30 - ModifyingData")]
		public void ModifyingData()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			dictionary["one"] = "uno";
			dictionary["two"] = "dos";
			dictionary["one"] = "ein";

			Assert.Equal(FILL_ME_IN, dictionary["one"]);
		}

		[Koan(31, DisplayName = "04.31 - ForEachKeyValuePair")]
		public void ForEachKeyValuePair()
		{
			Dictionary<string, int> one = new Dictionary<string, int>();

			one["jim"] = 53;
			one["amy"] = 20;
			one["dan"] = 23;

			Dictionary<string, int> two = new Dictionary<string, int>();

			two["jim"] = 54;
			two["jenny"] = 26;

			foreach (KeyValuePair<string, int> item in two)
			{
				one[item.Key] = item.Value;
			}

			Assert.Equal(FILL_ME_IN, one["jim"]);
			Assert.Equal(FILL_ME_IN, one["jenny"]);
			Assert.Equal(FILL_ME_IN, one["amy"]);
		}
	}
}
