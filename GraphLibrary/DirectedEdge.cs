using System;

namespace GraphLibrary
{
	public class DirectedEdge : IComparable<DirectedEdge>
	{
		readonly int V, W;
		readonly double edgeWeight;

		#region IComparable implementation

		public int CompareTo (DirectedEdge other)
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

		public DirectedEdge (int v, int w , double weight)
		{
			this.V = v;
			this.W = w;
			this.edgeWeight = weight;
		}

		public double Weight()
		{
			return this.edgeWeight;
		}

		public int From()
		{
			return this.V;
		}

		public int To()
		{
			return W;
		}
		public override string ToString ()
		{
			return String.Format ("{0} {1} {2} |",V,W,edgeWeight);
		}
	}
}

