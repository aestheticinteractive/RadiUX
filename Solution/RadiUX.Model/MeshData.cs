using System.Collections.Generic;

namespace RadiUX.Model {

	/*================================================================================================*/
	public class MeshData {

		public DegreeBounds Bounds { get; private set; }
		public IList<Vec3> Vertices { get; private set; }
		public IList<Vec2> UvCoordinates { get; private set; }
		public IList<int> TriangleIndices { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MeshData() : this(new DegreeBounds()) {
		}

		/*--------------------------------------------------------------------------------------------*/
		public MeshData(DegreeBounds pBounds) {
			Bounds = pBounds;
			Vertices = new List<Vec3>();
			UvCoordinates = new List<Vec2>();
			TriangleIndices = new List<int>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddSquareFace(int pIndexA, int pIndexB, int pIndexC, int pIndexD) {
			TriangleIndices.Add(pIndexA);
			TriangleIndices.Add(pIndexB);
			TriangleIndices.Add(pIndexC);

			TriangleIndices.Add(pIndexB);
			TriangleIndices.Add(pIndexD);
			TriangleIndices.Add(pIndexC);
		}

	}

}
