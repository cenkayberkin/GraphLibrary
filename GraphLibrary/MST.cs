using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
	/*
		Kruskal's Minimum Spanning Tree algorithm.
	*/

	public class MST
	{
		readonly EdgeWeightedGraph graph;

		public MST (EdgeWeightedGraph g)
		{
			this.graph = g;
		}

		public List<Edge> Edges()
		{
			return null;
		}

		public double Weight()
		{
			return 0;	
		}
	}
}

