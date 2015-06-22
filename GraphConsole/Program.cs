using System;
using GraphLibrary;

namespace GraphConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Graph g = new Graph ("../../../GraphLibrary/tinyGraph.txt");
			g.AddEdge (0, 6);
			g.AddEdge (0, 6);

			Console.WriteLine (g.MaxDegree());

			Console.WriteLine (g.ToString ());

			Console.WriteLine ("Hello World!");
		}
	}
}
