using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace GraphLibrary
{
	public class DFSProcess
	{
		readonly NonDiGraph graph;
		readonly int v;

		public int[] edgeTo;
		public bool[] visited;
		public int count;

		public DFSProcess (NonDiGraph graph,int v)
		{
			this.v = v;
			this.graph = graph;
			edgeTo = Enumerable.Repeat(-1, graph.V()).ToArray<int>();

			visited = new bool[graph.V ()];	

			depthFirstSearch (v);
		}

		private void depthFirstSearch(int s)
		{
			visited [s] = true;
			count++;

			var adjs = graph.Adj (s);

			foreach (var item in adjs) {
				if (visited [item] == false) {
					edgeTo [item] = s;
					depthFirstSearch (item);
				}
			}
		}

		public List<int> PathTo(int s)
		{
			if (!HasPathTo(s)) {
				return null;
			}
			Stack<int> stack = new Stack<int> ();
			stack.Push (s);
			int temp = s;
			while (v != edgeTo[temp]) {
				stack.Push (edgeTo[temp]);
				temp = edgeTo [temp];
			}
			stack.Push (v);

			return stack.ToList();
		}

		public bool HasPathTo(int s)
		{
			return visited [s];
		}


	}
}

