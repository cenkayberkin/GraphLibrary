using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
	public class CCProcess
	{
		readonly NonDiGraph graph;

		public bool[] visited;
		public int count;
		public int[] CC;

		public CCProcess (NonDiGraph graph)
		{
			this.graph = graph;
			CC = Enumerable.Repeat(-1, graph.V()).ToArray<int>();
			visited = new bool[graph.V ()];	

			findConnectedComponents ();
		}

		void findConnectedComponents()
		{
			int ccIndex = 0;

			for (int i = 0; i < graph.V(); i++) {
				if (CC[i] == -1) {
					depthFirstSearchCC (ccIndex, i);
					ccIndex++;
				}
			}
		}

		public bool Connected(int s, int v)
		{
			return CC [s] == CC [v];
		}

		void depthFirstSearchCC(int index, int s)
		{
			visited [s] = true;
			CC [s] = index;
		
			var adjs = graph.Adj (s);

			foreach (var item in adjs) {
				if (visited [item] == false) {
					depthFirstSearchCC (index,item);
				}
			}
		}
	}
}

