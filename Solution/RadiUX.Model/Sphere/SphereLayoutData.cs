using System;
using RadiUX.Model.Structures;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class SphereLayoutData {

		public float Radius { get; set; }
		public float Quality { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereLayoutData(float pRadius, float pQuality) {
			Radius = pRadius;
			Quality = pQuality;
		}

		/*--------------------------------------------------------------------------------------------*/
		internal string GetState() {
			return Radius+"|"+Quality;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MeshData GetSquare(DegreeBounds pBounds) {
			int stepsW = (int)Math.Max(2, Math.Round(pBounds.Width*Quality));
			int stepsH = (int)Math.Max(2, Math.Round(pBounds.Height*Quality));
			float incW = pBounds.Width/(stepsW-1);
			float incH = pBounds.Height/(stepsH-1);
			float baseX = pBounds.CenterX-pBounds.Width/2.0f;
			float baseY = pBounds.CenterY-pBounds.Height/2.0f;

			var mesh = new MeshData(pBounds);

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
				(float)(Radius * Math.Cos(s) * Math.Sin(t)),
				(float)(Radius * Math.Sin(s) * Math.Sin(t)),
				(float)(Radius * Math.Cos(t))
			);
		}

	}

}
