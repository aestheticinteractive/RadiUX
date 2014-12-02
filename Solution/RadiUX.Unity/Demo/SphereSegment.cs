using RadiUX.Model.Sphere;
using RadiUX.Model.Structures;
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

		private readonly SphereSegmentData vData;

		private ISphereLayout vLayout;
		private Mesh vMesh;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereSegment() {
			vData = new SphereSegmentData();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			var meshFilt = gameObject.GetComponent<MeshFilter>();

			if ( meshFilt == null ) {
				meshFilt = gameObject.AddComponent<MeshFilter>();
			}

			if ( gameObject.GetComponent<MeshRenderer>() == null ) {
				gameObject.AddComponent<MeshRenderer>();
			}

			vMesh = new Mesh();
			vMesh.hideFlags = HideFlags.DontSave;
			meshFilt.sharedMesh = vMesh;

			FindLayout();
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			if ( vLayout == null && !FindLayout() ) {
				return;
			}

			vData.Bounds = new DegreeBounds(CenterX, CenterY, Width, Height);
			vData.Layout = vLayout.Data;

			if ( vData.RebuildMeshDataIfNecessary() ) {
				vData.MeshData.FillUnityMesh(vMesh);
			}
		}

	}

}
