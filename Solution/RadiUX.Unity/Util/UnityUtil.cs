using System;
using System.Linq;
using RadiUX.Model;
using RadiUX.Model.Structures;
using UnityEngine;
using Mesh = UnityEngine.Mesh;

namespace RadiUX.Unity.Util {

	/*================================================================================================*/
	public static class UnityUtil {

		//public const int TransparentRenderQueue = 3000;

		public readonly static Shader ShaderDiff = Shader.Find("Diffuse");
		//public readonly static Shader ShaderTransDiff = Shader.Find("Transparent/Diffuse");
		//public readonly static Shader ShaderAlphaSelfIllum = Shader.Find("Unlit/AlphaSelfIllum");

		//public readonly static Quaternion RotationQuadFaceUp = 
		//	Quaternion.FromToRotation(Vector3.back, Vector3.up);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public static GameObject CreateNonCollisionQuad() {
			GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Quad);
			Object.Destroy(obj.GetComponent<MeshCollider>());
			return obj;
		}

		/*--------------------------------------------------------------------------------------------* /
		public static void SetLayerForHierarchy(GameObject pObj, int pLayer) {
			foreach ( Transform t in pObj.GetComponentsInChildren<Transform>(true) ) {
				t.gameObject.layer = pLayer;
			}
		}

		/*--------------------------------------------------------------------------------------------* /
		public static void SetSharedMaterialForHierarchy(GameObject pObj, Material pMaterial) {
			foreach ( MeshRenderer r in pObj.GetComponentsInChildren<MeshRenderer>(true) ) {
				r.sharedMaterial = pMaterial;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static T FindParentComponent<T>(GameObject pGameObj) {
			Transform par = pGameObj.transform.parent;

			while ( par != null ) {
				object comp = par.GetComponent(typeof(T));

				if ( comp != null ) {
					return (T)comp;
				}

				par = par.parent;
			}

			return default(T);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Mesh ToUnityMesh(this MeshData pMeshData) {
			var m = new Mesh();
			pMeshData.FillUnityMesh(m);
			return m;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void FillUnityMesh(this MeshData pMeshData, Mesh pMesh) {
			pMesh.Clear();
			pMesh.vertices = pMeshData.Vertices.Select(ToUnityVector).ToArray();
			pMesh.uv = pMeshData.UvCoordinates.Select(ToUnityVector).ToArray();
			pMesh.triangles = pMeshData.TriangleIndices.ToArray();
			pMesh.RecalculateNormals();
			pMesh.RecalculateBounds();
			pMesh.Optimize();
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Vector2 ToUnityVector(this Vec2 pVec) {
			return new Vector2(pVec.X, pVec.Y);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Vector3 ToUnityVector(this Vec3 pVec) {
			return new Vector3(pVec.X, pVec.Y, pVec.Z);
		}

	}

}
