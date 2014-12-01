using System;
using UnityEngine;

namespace RadiUX.Model {

	/*================================================================================================*/
	public class SphereMeshBuilder {

		private readonly float vRadius;
		private readonly float vQuality;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereMeshBuilder(float pRadius) {
			vRadius = pRadius;
			vQuality = 0.3f;
		}

		/*--------------------------------------------------------------------------------------------*/
		public MeshData BuildSquareMesh(float pWidthDegrees, float pHeightDegrees) {
			int stepsW = (int)Math.Max(2, Math.Round(pWidthDegrees*vQuality));
			int stepsH = (int)Math.Max(2, Math.Round(pHeightDegrees*vQuality));
			float incW = pWidthDegrees/(stepsW-1);
			float incH = pHeightDegrees/(stepsH-1);
			float halfW = pWidthDegrees/2.0f;
			float halfH = pHeightDegrees/2.0f;

			var mesh = new MeshData();
			var rot = Quaternion.FromToRotation(Vector3.up, Vector3.forward)*
				Quaternion.FromToRotation(Vector3.right, Vector3.up);

			for ( var hi = 0 ; hi < stepsH ; ++hi ) {
				for ( var wi = 0 ; wi < stepsW ; ++wi ) {
					Vector3 v = GetPointOnSphere(incW*wi-halfW, incH*hi-halfH+90);
					var uv = new Vector2(wi/(float)stepsW, hi/(float)stepsH);

					mesh.Vertices.Add(rot*v);
					mesh.UvCoordinates.Add(uv);

					if ( hi > 0 && wi > 0 ) {
						mesh.AddSquareFace(
							(hi-1)*stepsW+wi-1,
							(hi-1)*stepsW+wi,
							hi*stepsW+wi-1,
							hi*stepsW+wi
						);
					}
				}
			}

			return mesh;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Vector3 GetPointOnSphere(float pDegreesAboutZ, float pDegreesDownZ) {
			float s = (float)(pDegreesAboutZ/180.0*Math.PI);
			float t = (float)(pDegreesDownZ/180.0*Math.PI);

			return new Vector3(
				(float)(vRadius * Math.Cos(s) * Math.Sin(t)),
				(float)(vRadius * Math.Sin(s) * Math.Sin(t)),
				(float)(vRadius * Math.Cos(t))
			);
		}

	}

}
