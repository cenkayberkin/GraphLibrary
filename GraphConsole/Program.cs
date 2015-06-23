using System;
using GraphLibrary;
using System.Linq;

namespace GraphConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			NonDiGraph g = new NonDiGraph ("../../../GraphLibrary/tinyGraph.txt");

			DFSProcess p = new DFSProcess (g,0);
			Console.WriteLine (string.Join (" ", p.edgeTo));
			Console.WriteLine (string.Join (" ", p.visited));
			Console.WriteLine (string.Format("{0} nodes could be reached from {1}",p.count,0));

			Console.WriteLine ("Hello World!");
		}
	}
}
