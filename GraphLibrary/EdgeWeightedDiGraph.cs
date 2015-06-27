using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GraphLibrary
{
	public class EdgeWeightedDiGraph
	{
		private readonly int numOfNodes;
		private int numOfEdges;
		private Dictionary<int,HashSet<DirectedEdge>> dictionary;

		public EdgeWeightedDiGraph (string filePath)
		{
			dictionary = new Dictionary<int, HashSet<DirectedEdge>> ();
			System.IO.StreamReader file = new System.IO.StreamReader(filePath);
			int count = 0;
			string line;

			List<string> edgesInfo = new List<string> ();

			while ((line = file.ReadLine()) != null) 
			{
				if (count == 0) {
					if (!int.TryParse (line, out numOfNodes)) {
						throw new ArgumentException ("Number of nodes is not number");
					}
				}

				else if (count == 1) {
					if (!int.TryParse (line, out numOfEdges)) {
						throw new ArgumentException ("Number of edges is not number");
					}
				} else {
					edgesInfo.Add (line);
				}

				count++;	
			}
			if (count  != numOfEdges + 2) {
				throw new ArgumentOutOfRangeException ("Number of edges and number of lines are not equal");
			}

			generateNodes ();

			addEdgesToGraph (edgesInfo);

		}

		public List<DirectedEdge> Edges()
		{
			List<DirectedEdge> result = new List<DirectedEdge> ();
			for (int i = 0; i < this.numOfNodes; i++) 
			{
				foreach (var item in dictionary[i]) 
				{
					result.Add (item);	
				}
			}
			return result;
		}

		public List<DirectedEdge> Adj(int v)
		{   
			return dictionary [v].ToList ();
		}

		public void AddEdge(int v, int w,double weight){

			DirectedEdge e1 = new DirectedEdge (v,w,weight);

			if (dictionary [v] == null) {
				dictionary [v] = new HashSet<DirectedEdge> (){ e1 };
			}
			else {
				dictionary [v].Add (e1);
			}
		}

		void addEdgesToGraph (List<string> edgesInfo)
		{
			foreach (var item in edgesInfo) {
				var node1 = int.Parse (item.Split (' ') [0]);
				var node2 = int.Parse (item.Split (' ') [1]);
				var weight = double.Parse (item.Split (' ') [2]);
				AddEdge (node1, node2,weight);
			}
		}

		void generateNodes()
		{
			for (int i = 0; i < numOfNodes; i++) {
				dictionary.Add (i, null);
			}
		}

		public int V (){
			return numOfNodes;
		}

		public int E(){
			return numOfEdges;
		}
	}
}

