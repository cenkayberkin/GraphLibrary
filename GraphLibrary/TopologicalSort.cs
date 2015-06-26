using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace GraphLibrary
{
	public class TopologicalSort
	{
		readonly DiGraph graph;

		public bool[] visited;
		public Stack<int> stack;

		public TopologicalSort (DiGraph graph)
		{
			this.graph = graph;
			stack = new Stack<int> ();
			visited = new bool[graph.V ()];	

			for (int i = 0; i < graph.V(); i++) {
				if (!visited[i]) {
					depthFirstSearch (i);
				}	
			}
		}

		void depthFirstSearch (int s)
		{
			visited [s] = true;

			var adjs = graph.Adj (s);
			foreach (var item in adjs) {
				if (!visited[item]) {
					depthFirstSearch (item);
				}
			}
			stack.Push (s);
		}

		public void PrintOrderedNodes()
		{
			Console.WriteLine (string.Join (" ", stack.ToList ()));
		}
	}
}

