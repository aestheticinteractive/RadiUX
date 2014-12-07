﻿using System;
using RadiUX.Model.Sphere;
using RadiUX.Model.Structures;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereSegment : SphereElement<SphereSegmentData>, ISphereSegment {

		public float Width = 10;
		public float Height = 10;

		private Mesh vMesh;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Awake() {
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
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();

			Data.Width = Width;
			Data.Height = Height;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void LateUpdate() {
			base.LateUpdate();

			if ( Data.RebuildMeshDataIfNecessary() ) {
				Data.MeshData.FillUnityMesh(vMesh);
				AfterMeshUpdate();
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void AfterMeshUpdate() {
		}

	}

}
