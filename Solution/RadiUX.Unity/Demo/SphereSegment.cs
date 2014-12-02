using System;
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
		private ISphereContainer vContain;
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

			////

			vLayout = UnityUtil.FindParentComponent<ISphereLayout>(gameObject);
			vContain = UnityUtil.FindParentComponent<ISphereContainer>(gameObject);

			if ( vLayout == null ) {
				throw new Exception("This element must be contained within an ISphereLayout.");
			}

			vData.Layout = vLayout.Data;

			if ( vContain != null ) {
				vData.Container = vContain.Data;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LateUpdate() {
			vData.Bounds = new DegreeBounds(CenterX, CenterY, Width, Height);

			if ( vData.RebuildMeshDataIfNecessary() ) {
				vData.MeshData.FillUnityMesh(vMesh);
			}
		}

	}

}
