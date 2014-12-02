using System;
using RadiUX.Model.Structures;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class SphereSegmentData {

		public DegreeBounds Bounds { get; set; }
		public SphereLayoutData Layout { get; set; }
		public MeshData MeshData { get; set; }

		private DegreeBounds vCurrBounds;
		private string vCurrLayoutState;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool RebuildMeshDataIfNecessary() {
			if ( Bounds == null ) {
				throw new ArgumentNullException("Bounds");
			}

			if ( Layout == null ) {
				throw new ArgumentNullException("Layout");
			}

			string layoutState = Layout.GetState();

			if ( Bounds.IsSameAs(vCurrBounds) && layoutState == vCurrLayoutState ) {
				return false;
			}

			vCurrBounds = new DegreeBounds(Bounds);
			vCurrLayoutState = layoutState;

			MeshData = Layout.GetSquare(Bounds);
			return true;
		}

	}

}
