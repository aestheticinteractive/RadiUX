using RadiUX.Model;
using RadiUX.Unity.Shared;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	public class SquareTest : UiBase {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SquareTest() {
			var meshBuild = new SphereMeshBuilder(4);
			var px = 0;
			var py = 90;

			AddElement("Grid-0-0", meshBuild.BuildSquareMesh(px-12, py-12, 10, 10));
			AddElement("Grid-1-0", meshBuild.BuildSquareMesh(px,    py-12, 10, 10));
			AddElement("Grid-2-0", meshBuild.BuildSquareMesh(px+12, py-12, 10, 10));

			AddElement("Grid-0-1", meshBuild.BuildSquareMesh(px-12, py, 10, 10));
			AddElement("Grid-1-1", meshBuild.BuildSquareMesh(px,    py, 10, 10));
			AddElement("Grid-2-1", meshBuild.BuildSquareMesh(px+12, py, 10, 10));

			AddElement("Grid-0-2", meshBuild.BuildSquareMesh(px-12, py+12, 10, 10));
			AddElement("Grid-1-2", meshBuild.BuildSquareMesh(px,    py+12, 10, 10));
			AddElement("Grid-2-2", meshBuild.BuildSquareMesh(px+12, py+12, 10, 10));

			AddElement("Bot", meshBuild.BuildSquareMesh(px, py-24, 34, 10));
			AddElement("Top", meshBuild.BuildSquareMesh(px, py+24, 34, 10));

			AddElement("Bot2", meshBuild.BuildSquareMesh(px, py-46, 142, 30));
			AddElement("Top2", meshBuild.BuildSquareMesh(px, py+46, 142, 30));

			AddElement("R", meshBuild.BuildSquareMesh(px-24, py, 10, 58));
			AddElement("L", meshBuild.BuildSquareMesh(px+24, py, 10, 58));

			AddElement("R2", meshBuild.BuildSquareMesh(px-51, py, 40, 58));
			AddElement("L2", meshBuild.BuildSquareMesh(px+51, py, 40, 58));

			GameObj.transform.localRotation = 
				Quaternion.FromToRotation(Vector3.up, Vector3.forward)*
				Quaternion.FromToRotation(Vector3.right, Vector3.up);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddElement(string pName, MeshData pMesh) {
			var g = new GameObject(pName);
			g.AddComponent<MeshFilter>().mesh = pMesh.ToUnityMesh();
			g.AddComponent<MeshRenderer>();
			g.renderer.sharedMaterial = new Material(UnityUtil.ShaderDiff);
			AddChild(g);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
		}

	}

}
