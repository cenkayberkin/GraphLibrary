using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
	public class ColoringProcess
	{
		readonly NonDiGraph graph;
		readonly int v;

		public int[] edgeTo;
		public bool[] visited;
		public bool IsTwoColorable;
		public bool[] colors;

		public ColoringProcess (NonDiGraph graph)
		{
			colors = new bool[graph.V()];
			IsTwoColorable = true;
			this.graph = graph;
			edgeTo = Enumerable.Repeat(-1, graph.V()).ToArray<int>();
			visited = new bool[graph.V ()];

			for (int i = 0; i < graph.V(); i++) {
				dfs (i);	
			}
		}

		void dfs(int v)
		{
			visited [v] = true;

			var adjs = graph.Adj (v);
			foreach (var item in adjs) {
				if (!visited[item]) {
					colors [item] = !colors [v];
					dfs (item);
				}else if (colors[item] == colors[v]) {
					IsTwoColorable = false;
				}
			}

		}
	}
}

