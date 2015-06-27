using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
	public class WeightedCyclicDetection
	{
		readonly EdgeWeightedGraph graph;
		readonly int v;

		public int[] edgeTo;
		public bool[] visited;
		public bool IsCyclic;

		public WeightedCyclicDetection (EdgeWeightedGraph graph)
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
			foreach (Edge item in adjs) {
				var k = item.Other (s);
				if (!visited[k]) {
					edgeTo [k] = s;
					dfsCyclicHelper (k, v);
				}else if(k == v && edgeTo[s] != v){
					IsCyclic = true;
				}
			}
		}
	}
}

