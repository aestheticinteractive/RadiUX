using UnityEngine;

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
		/*--------------------------------------------------------------------------------------------*/
		public static GameObject CreateNonCollisionQuad() {
			GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Quad);
			Object.Destroy(obj.GetComponent<MeshCollider>());
			return obj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetLayerForHierarchy(GameObject pObj, int pLayer) {
			foreach ( Transform t in pObj.GetComponentsInChildren<Transform>(true) ) {
				t.gameObject.layer = pLayer;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetSharedMaterialForHierarchy(GameObject pObj, Material pMaterial) {
			foreach ( MeshRenderer r in pObj.GetComponentsInChildren<MeshRenderer>(true) ) {
				r.sharedMaterial = pMaterial;
			}
		}

	}

}
