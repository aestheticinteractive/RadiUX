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
		public bool RebuildMeshDataIfNecessary(Layout pParentLayout) {
			if ( pParentLayout == null ) {
				throw new ArgumentNullException("ParentLayout");
			}

			if ( Width == vPrevWidth && Height == vPrevHeight && Transform == vPrevTransform &&
			    	InheritedTransform == vPrevInheritedTransform ) {
				return false;
			}

			vPrevWidth = Width;
			vPrevHeight = Height;
			vPrevTransform = Transform;
			vPrevInheritedTransform = InheritedTransform;

			Vec3 absoluteCenter = InheritedTransform.Center+Transform.Center;
			var bounds = new DegreeBounds(absoluteCenter, Width, Height);

			MeshData = pParentLayout.GetSquare(bounds);

			return true;
		}

	}

}
