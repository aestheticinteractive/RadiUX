using RadiUX.Model.Structures;
using RadiUX.Model.Sphere.Components;
using System;
using System.Collections.Generic;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class Layout : Element {

		public float Radius { get; set; }
		public float Quality { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Layout() {
			Radius = 4;
			Quality = 0.333f;
		}

		/*--------------------------------------------------------------------------------------------* /
		internal override string GetState() {
			return Radius+","+Quality+","+base.GetState();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MeshData GetSquare(DegreeBounds pBounds) {
			int stepsW = (int)Math.Max(2, Math.Round(pBounds.Width*Quality));
			int stepsH = (int)Math.Max(2, Math.Round(pBounds.Height*Quality));
			float incW = pBounds.Width/(stepsW-1);
			float incH = pBounds.Height/(stepsH-1);
			float baseX = pBounds.Center.X-pBounds.Width/2.0f;
			float baseY = pBounds.Center.Y-pBounds.Height/2.0f;
			float baseZ = Radius + pBounds.Center.Z;

			var mesh = new MeshData(pBounds);

			for ( var hi = 0 ; hi < stepsH ; ++hi ) {
				for ( var wi = 0 ; wi < stepsW ; ++wi ) {
					Vec3 v = GetPointOnSphere(incW*wi+baseX, incH*hi+baseY, baseZ);
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
		private static Vec3 GetPointOnSphere(float pHorizDeg, float pVertDeg, float pRadius) {
			float s = (float)(pHorizDeg/180.0*Math.PI);
			float t = (float)(pVertDeg/180.0*Math.PI);

			return new Vec3(
				(float)(pRadius * Math.Cos(s) * Math.Sin(t)),
				(float)(pRadius * Math.Sin(s) * Math.Sin(t)),
				(float)(pRadius * Math.Cos(t))
			);
		}

	}

}
