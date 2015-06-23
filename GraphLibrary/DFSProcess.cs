using System;
using System.Linq;

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
			edgeTo = Enumerable.Repeat(int.MinValue, graph.V()).ToArray<int>();

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
		public bool Marked(int s)
		{
			return visited [s];
		}


	}
}

