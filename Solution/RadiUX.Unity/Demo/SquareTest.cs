using System.Collections.Generic;
using RadiUX.Model;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SquareTest : MonoBehaviour {

		public float GridButtonSize = 10;

		private SphereMeshBuilder vMeshBuild;
		private IList<MeshData> vGridMeshes;
		private IList<GameObject> vGridButtons;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			vMeshBuild = new SphereMeshBuilder(4);

			const float px = 0;
			const float py = 90;
			var b = new DegreeBounds(px, py, 10, 10);

			vGridMeshes = new List<MeshData>();
			vGridButtons = new List<GameObject>();

			AddGridElement("Grid-0-0", vMeshBuild.GetSquare(b.NewOffsetCenter(-12, -12)));
			AddGridElement("Grid-1-0", vMeshBuild.GetSquare(b.NewOffsetCenter(0, -12)));
			AddGridElement("Grid-2-0", vMeshBuild.GetSquare(b.NewOffsetCenter(12, -12)));

			AddGridElement("Grid-0-1", vMeshBuild.GetSquare(b.NewOffsetCenter(-12, 0)));
			AddGridElement("Grid-1-1", vMeshBuild.GetSquare(b.NewOffsetCenter(0, 0)));
			AddGridElement("Grid-2-1", vMeshBuild.GetSquare(b.NewOffsetCenter(12, 0)));

			AddGridElement("Grid-0-2", vMeshBuild.GetSquare(b.NewOffsetCenter(-12, 12)));
			AddGridElement("Grid-1-2", vMeshBuild.GetSquare(b.NewOffsetCenter(0, 12)));
			AddGridElement("Grid-2-2", vMeshBuild.GetSquare(b.NewOffsetCenter(12, 12)));

			AddElement("Bot", vMeshBuild.GetSquare(new DegreeBounds(px, py-24, 34, 10)));
			AddElement("Top", vMeshBuild.GetSquare(new DegreeBounds(px, py+24, 34, 10)));

			AddElement("Bot2", vMeshBuild.GetSquare(new DegreeBounds(px, py-46, 142, 30)));
			AddElement("Top2", vMeshBuild.GetSquare(new DegreeBounds(px, py+46, 142, 30)));

			AddElement("R", vMeshBuild.GetSquare(new DegreeBounds(px-24, py, 10, 58)));
			AddElement("L", vMeshBuild.GetSquare(new DegreeBounds(px+24, py, 10, 58)));

			AddElement("R2", vMeshBuild.GetSquare(new DegreeBounds(px-51, py, 40, 58)));
			AddElement("L2", vMeshBuild.GetSquare(new DegreeBounds(px+51, py, 40, 58)));

			transform.localRotation = 
				Quaternion.FromToRotation(Vector3.up, Vector3.forward)*
				Quaternion.FromToRotation(Vector3.right, Vector3.up);
		}

		/*--------------------------------------------------------------------------------------------*/
		private GameObject AddGridElement(string pName, MeshData pMesh) {
			var g = AddElement(pName, pMesh);
			vGridMeshes.Add(pMesh);
			vGridButtons.Add(g);
			return g;
		}

		/*--------------------------------------------------------------------------------------------*/
		private GameObject AddElement(string pName, MeshData pMesh) {
			var g = new GameObject(pName);
			g.AddComponent<MeshFilter>().mesh = pMesh.ToUnityMesh();
			g.AddComponent<MeshRenderer>();
			g.renderer.sharedMaterial = new Material(UnityUtil.ShaderDiff);
			g.transform.parent = transform;
			return g;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			for ( int i = 0 ; i < vGridButtons.Count ; i++ ) {
				GameObject g = vGridButtons[i];
				MeshData md = vGridMeshes[i];
				md = vMeshBuild.GetSquare(md.Bounds.NewResized(GridButtonSize, GridButtonSize));
				g.GetComponent<MeshFilter>().mesh = md.ToUnityMesh();
			}
		}

	}

}
