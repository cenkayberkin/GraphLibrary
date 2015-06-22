using System;
using GraphLibrary;

namespace GraphConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Graph g = new Graph ("../../../GraphLibrary/tinyGraph.txt");
			Console.WriteLine (g.ToString ());

			Console.WriteLine ("Hello World!");
		}
	}
}
