using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
	public class CyclicDetection
	{
		readonly NonDiGraph graph;
		readonly int v;

		public int[] edgeTo;
		public bool[] visited;
		public bool IsCyclic;

		public CyclicDetection (NonDiGraph graph)
		{
			this.graph = graph;
			edgeTo = Enumerable.Repeat(-1, graph.V()).ToArray<int>();
			visited = new bool[graph.V ()];	
			dfsCyclic ();
		}

		void dfsCyclic()
		{
			for (int i = 0; i < graph.V(); i++) {
				if (IsCyclic) {
					break;
				}
				dfsCyclicHelper (i,i);	
			}
		}

		void dfsCyclicHelper(int s, int v)
		{
			visited [s] = true;
			var adjs = graph.Adj (s);
			foreach (var item in adjs) {
				if (!visited[item]) {
					edgeTo [item] = s;
					dfsCyclicHelper (item, v);
				}else if(item == v && edgeTo[s] != v){
					IsCyclic = true;
				}
			}
		}
	}
}

