using System;

namespace GraphLibrary
{
	public class Edge : IComparable<Edge>
	{
		readonly int V, W;
		readonly double edgeWeight;

		#region IComparable implementation

		public int CompareTo (Edge other)
		{
			if (this.edgeWeight > other.Weight()) {
				return 1;
			}
			if (this.edgeWeight < other.Weight()) {
				return -1;
			} else {
				return 0;
			}
		}

		#endregion

		public Edge (int v, int w , double weight)
		{
			this.V = v;
			this.W = w;
			this.edgeWeight = weight;
		}

		public double Weight()
		{
			return this.edgeWeight;
		}

		public int Either()
		{
			return this.V;
		}

		public int Other(int vertex)
		{
			if (vertex == this.W) {
				return V;
			} else {
				return W;
			}
		}
		public override string ToString ()
		{
			return String.Format ("{0} {1} {2} |",V,W,edgeWeight);
		}
	}
}

