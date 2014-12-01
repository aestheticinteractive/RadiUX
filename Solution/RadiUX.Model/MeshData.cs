using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RadiUX.Model {

	/*================================================================================================*/
	public class MeshData {

		public IList<Vector3> Vertices { get; private set; }
		public IList<Vector2> UvCoordinates { get; private set; }
		public IList<int> TriangleIndices { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MeshData() {
			Vertices = new List<Vector3>();
			UvCoordinates = new List<Vector2>();
			TriangleIndices = new List<int>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddSquareFace(int pIndexA, int pIndexB, int pIndexC, int pIndexD) {
			TriangleIndices.Add(pIndexA);
			TriangleIndices.Add(pIndexB);
			TriangleIndices.Add(pIndexC);

			TriangleIndices.Add(pIndexB);
			TriangleIndices.Add(pIndexD);
			TriangleIndices.Add(pIndexC);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Mesh ToUnityMesh() {
			var m = new Mesh();
			m.Clear();
			m.vertices = Vertices.ToArray();
			m.uv = UvCoordinates.ToArray();
			m.triangles = TriangleIndices.ToArray();
			m.RecalculateNormals();
			m.RecalculateBounds();
			m.Optimize();
			return m;
		}

	}

}
