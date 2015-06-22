using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GraphLibrary
{
	public class Graph
	{
		private readonly int numOfNodes;
		private int numOfEdges;
		private Dictionary<int,List<int>> dictionary;

		public int V (){
			return numOfNodes;
		}

		public int E(){
			return numOfEdges;
		}

		public Graph (int v)
		{
			numOfNodes = v;
			numOfEdges = 0;
			generateNodes ();
		}

		public Graph (string filePath)
		{
			dictionary = new Dictionary<int, List<int>> ();
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

		public List<int> Adj(int v)
		{   
			return dictionary [v];
		}

		public void AddEdge(int v, int w){
			if (dictionary [v] == null) {
				dictionary [v] = new List<int> (){ w };
			}
			else {
				dictionary [v].Add (w);
			}

			if (dictionary [w] == null) {
				dictionary [w] = new List<int> (){ v };
			}
			else {
				dictionary [w].Add (v);
			}
		}

		void addEdgesToGraph (List<string> edgesInfo)
		{
			foreach (var item in edgesInfo) {
				var node1 = int.Parse (item.Split (null) [0]);
				var node2 = int.Parse (item.Split (null) [1]);
				AddEdge (node1, node2);
			}
		}

		void generateNodes()
		{
			for (int i = 0; i < numOfNodes; i++) {
				dictionary.Add (i, null);
			}
		}

		public override string ToString ()
		{
			string result = string.Format ("Graph: {0} nodes and {1} edges \n",numOfNodes,numOfEdges);
			foreach (var key in dictionary.Keys) {
				if (dictionary [key] != null) {
					var edgesArray = dictionary [key].Select (a => a.ToString ()).ToArray ();
					string edges = string.Join (" ", edgesArray);
					result += key + " => " + edges + "\n";
				} else {
					result += key + "\n";
				}
			}

			return result;
		}

	}
}

