using System;
using RadiUX.Model.Sphere;
using RadiUX.Model.Structures;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereSegment : MonoBehaviour, ISphereSegment {

		public Vector3 Center;
		public float Width = 10;
		public float Height = 10;

		public ISphereLayout Layout { get; private set; }
		public ISphereContainer Container { get; private set; }

		private readonly SphereSegmentData vData;
		private Mesh vMesh;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereSegment() {
			vData = new SphereSegmentData();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Awake() {
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
		public virtual void Start() {
			FindParentsIfNecessary();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void FindParentsIfNecessary() {
			if ( Application.isPlaying && Layout != null ) {
				return;
			}

			Layout = UnityUtil.FindParentComponent<ISphereLayout>(gameObject);
			Container = UnityUtil.FindParentComponent<ISphereContainer>(gameObject);

			vData.Layout = (Layout == null ? null : Layout.Data);
			vData.Container = (Container == null ? null : Container.Data);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Update() {
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void LateUpdate() {
			FindParentsIfNecessary();

			if ( Layout == null ) {
				throw new Exception("This element must be contained within an ISphereLayout.");
			}

			vData.Bounds = new DegreeBounds(Center.ToRadiuxVector(), Width, Height);

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
