using RadiUX.Model;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereSegment : MonoBehaviour {

		public float CenterX = 0;
		public float CenterY = 90;
		public float Width = 10;
		public float Height = 10;

		private ISphereLayout vLayout;
		private Mesh vMesh;
		private DegreeBounds vCurrBounds;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			var meshFilt = gameObject.GetComponent<MeshFilter>();
			var meshRend = gameObject.GetComponent<MeshRenderer>();

			if ( meshFilt == null ) {
				meshFilt = gameObject.AddComponent<MeshFilter>();
			}

			if ( meshRend == null ) {
				gameObject.AddComponent<MeshRenderer>();
			}

			vMesh = new Mesh();
			vMesh.hideFlags = HideFlags.DontSave;
			meshFilt.sharedMesh = vMesh;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			if ( vLayout == null && !FindLayout() ) {
				return;
			}

			var b = new DegreeBounds(CenterX, CenterY, Width, Height);

			if ( !b.IsSameAs(vCurrBounds) ) {
				vCurrBounds = b;
				MeshData md = vLayout.MeshBuild.GetSquare(b);
				md.FillUnityMesh(vMesh);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private bool FindLayout() {
			Transform par = gameObject.transform.parent;

			while ( par != null ) {
				vLayout = (par.GetComponent(typeof(ISphereLayout)) as ISphereLayout);

				if ( vLayout != null ) {
					return true;
				}

				par = par.parent;
			}

			Debug.LogError("This element must be a child of a GameObject with an ISphereLayout.");
			return false;
		}

	}

}
