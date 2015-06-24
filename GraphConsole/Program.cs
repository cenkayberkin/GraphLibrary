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
//			NonDiGraph g = new NonDiGraph ("../../../GraphLibrary/ACyclicGraph.txt");

//			DFSProcess p = new DFSProcess (g,0);
//			Console.WriteLine (string.Join (" ", p.edgeTo));
//			Console.WriteLine (string.Join (" ", p.visited));
//
//			for (int i = 1; i < g.V(); i++) {
//				if (p.PathTo(i) != null) {
//					Console.WriteLine ("0 => (" + i + ") " +string.Join (" ", p.PathTo (i).ToArray<int> ()));	
//				} else {
//					Console.WriteLine ("Not connected to {0}",i);	
//				}	
//			}

//			BFSProcess bfs = new BFSProcess (g,0);
//			Console.WriteLine (string.Join (" ", bfs.edgeTo));
//			Console.WriteLine (string.Join (" ", bfs.visited));
//
//			for (int i = 1; i < g.V(); i++) {
//				if (bfs.PathTo(i) != null) {
//					Console.WriteLine ("0 => (" + i + ") " +string.Join (" ", bfs.PathTo (i).ToArray<int> ()));	
//				} else {
//					Console.WriteLine ("Not connected to {0}",i);	
//				}	
//			}

//			CCProcess cc = new CCProcess (g);
//			Console.WriteLine (string.Join (" ", cc.CC));
//			Console.WriteLine (cc.Connected (0, 10));
//			cc.PrintComponent ();
		
//			CyclicDetection cd = new CyclicDetection (g);
//			Console.WriteLine (cd.IsCyclic);

			ColoringProcess cp = new ColoringProcess (g);
			Console.WriteLine (cp.IsTwoColorable);
			Console.WriteLine (string.Join(" ", cp.colors));
		}
	}
}
