using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace GraphLibrary
{
	public class DirectedBFS
	{
		readonly DiGraph graph;
		readonly int v;

		public int[] edgeTo;
		public bool[] visited;
		public int[] distTo;

		public DirectedBFS (DiGraph graph,int v)
		{
			this.v = v;
			this.graph = graph;
			edgeTo = Enumerable.Repeat(-1, graph.V()).ToArray<int>();

			visited = new bool[graph.V()];	
			distTo = new int[graph.V()];
			breadthFirstSearch (v);
		}

		void breadthFirstSearch(int s)
		{
			Queue<int> q = new Queue<int> ();
			visited [s] = true;
			q.Enqueue (s);

			while (q.Count > 0) {
				var top = q.Dequeue ();

				foreach (var item in graph.Adj(top)) {
					if (!visited[item]) {
						distTo [item] = distTo [top] + 1;
						edgeTo[item] = top;
						visited [item] = true;
						q.Enqueue(item);
					}
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

