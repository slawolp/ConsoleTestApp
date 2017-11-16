using System;
using System.Collections.Generic;

namespace ConsoleTestApp
{
	class Program
	{
		static List<int> myList = new List<int>();

		static void Main(string[] args)
		{
			string name = "Sławek";
			Console.WriteLine($"Hello World! My name is {name}");

			#region ActionFuncPredic

			// TestFunc(4, 5);
			// TestAction();
			// TestPredicate(DateTime.Now.Year.ToString());
			#endregion

			#region Yield

			FillList(10);

			foreach (var item in Total())
			{
				Console.WriteLine(item);
			}

			#endregion

			Console.ReadKey();
		}

		#region Yield

		static void FillList(int i)
		{
			myList.Clear();

			for (int j = 0; j < i; j++)
			{
				myList.Add(j);
			}
		}

		// Custom iteration
		static IEnumerable<int> Filter()
		{
			foreach (var item in myList)
			{
				if (item > 4)
					yield return item;
			}
		}

		static IEnumerable<int> Total()
		{
			int total = 0;

			foreach (var item in myList)
			{
				total += item;
				yield return total;
			}
		}

		#endregion

		#region FuncActionPredicate

		static void TestFunc(int a, int b)
		{
			Func<int, int, double> Triangle = (x, y) => (a * b) / 2;

			Console.WriteLine(Triangle(a, b));
		}

		static void TestAction()
		{
			Action<string> Name = s => Console.WriteLine(s);

			Name(DateTime.Now.ToString());
		}

		static void TestPredicate(string text)
		{
			Predicate<string> Pred5 = s => s.Length > 5;
			Console.WriteLine(Pred5(text));
		}
		#endregion
	}
}