using RadiUX.Model.Structures;
using RadiUX.Model.Sphere.Components;
using System;
using System.Collections.Generic;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class Segment : Element {
		
		public float Width { get; set; }
		public float Height { get; set; }
		public MeshData MeshData { get; set; }

		private float vPrevWidth;
		private float vPrevHeight;
		private Transform vPrevTransform;
		private Transform vPrevInheritedTransform;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Segment() {
			Width = 10;
			Height = 10;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool RebuildMeshDataIfNecessary() {
			if ( Width == vPrevWidth && Height == vPrevHeight && Transform == vPrevTransform &&
			    	InheritedTransform == vPrevInheritedTransform ) {
				return false;
			}

			vPrevWidth = Width;
			vPrevHeight = Height;
			vPrevTransform = Transform;
			vPrevInheritedTransform = InheritedTransform;

			Vec3 absoluteCenter = InheritedTransform.Center+Transform.Center;
			MeshData = GetSquare(new DegreeBounds(absoluteCenter, Width, Height));

			return true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static MeshData GetSquare(DegreeBounds pBounds) {
			float quality = 0.333f;
			int stepsW = (int)Math.Max(2, Math.Round(pBounds.Width*quality));
			int stepsH = (int)Math.Max(2, Math.Round(pBounds.Height*quality));
			float incW = pBounds.Width/(stepsW-1);
			float incH = pBounds.Height/(stepsH-1);
			float baseX = pBounds.Center.X-pBounds.Width/2.0f;
			float baseY = pBounds.Center.Y-pBounds.Height/2.0f;
			float baseZ = pBounds.Center.Z;
			
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
