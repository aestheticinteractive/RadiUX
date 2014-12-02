using System;

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
		public MeshData BuildSquareMesh(float pCenterX, float pCenterY, float pWidth, float pHeight) {
			int stepsW = (int)Math.Max(2, Math.Round(pWidth*vQuality));
			int stepsH = (int)Math.Max(2, Math.Round(pHeight*vQuality));
			float incW = pWidth/(stepsW-1);
			float incH = pHeight/(stepsH-1);
			float baseX = pCenterX-pWidth/2.0f;
			float baseY = pCenterY-pHeight/2.0f;
			var mesh = new MeshData();

			for ( var hi = 0 ; hi < stepsH ; ++hi ) {
				for ( var wi = 0 ; wi < stepsW ; ++wi ) {
					Vec3 v = GetPointOnSphere(incW*wi+baseX, incH*hi+baseY);
					var uv = new Vec2(wi/(float)stepsW, hi/(float)stepsH);

					mesh.Vertices.Add(v);
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
		private Vec3 GetPointOnSphere(float pDegreesAboutZ, float pDegreesDownZ) {
			float s = (float)(pDegreesAboutZ/180.0*Math.PI);
			float t = (float)(pDegreesDownZ/180.0*Math.PI);

			return new Vec3(
				(float)(vRadius * Math.Cos(s) * Math.Sin(t)),
				(float)(vRadius * Math.Sin(s) * Math.Sin(t)),
				(float)(vRadius * Math.Cos(t))
			);
		}

	}

}
