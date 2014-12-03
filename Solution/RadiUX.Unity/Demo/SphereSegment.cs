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
		public float CenterY = 0;
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
		public virtual void Start() {
			MeshFilter meshFilt = gameObject.GetComponent<MeshFilter>();

			if ( meshFilt == null ) {
				meshFilt = gameObject.AddComponent<MeshFilter>();
			}

			if ( gameObject.GetComponent<MeshRenderer>() == null ) {
				gameObject.AddComponent<MeshRenderer>();
			}
			
			vMesh = new Mesh();
			vMesh.hideFlags = HideFlags.DontSave;
			meshFilt.sharedMesh = vMesh;

			FindParentsIfNecessary();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void FindParentsIfNecessary() {
			if ( vLayout != null ) {
				return;
			}

			vLayout = UnityUtil.FindParentComponent<ISphereLayout>(gameObject);
			vContain = UnityUtil.FindParentComponent<ISphereContainer>(gameObject);

			vData.Layout = (vLayout == null ? null : vLayout.Data);
			vData.Container = (vContain == null ? null : vContain.Data);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Update() {
			FindParentsIfNecessary();

			if ( vLayout == null ) {
				throw new Exception("This element must be contained within an ISphereLayout.");
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void LateUpdate() {
			vData.Bounds = new DegreeBounds(CenterX, CenterY, Width, Height);

			if ( vData.RebuildMeshDataIfNecessary() ) {
				vData.MeshData.FillUnityMesh(vMesh);
				AfterMeshUpdate();
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void AfterMeshUpdate() {
		}

	}

}
