using System;
using RadiUX.Model.Structures;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class SphereSegmentData : SphereElementData {

		public float Width { get; set; }
		public float Height { get; set; }
		public MeshData MeshData { get; set; }

		private DegreeBounds vCurrBounds;
		private string vCurrState;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool RebuildMeshDataIfNecessary() {
			if ( ParentLayout == null ) {
				throw new ArgumentNullException("Layout");
			}

			var bounds = new DegreeBounds(Center, Width, Height);
			string state = ParentLayout.GetState()+(ParentContainer == null ? "" : "|"+ParentContainer.GetState());

			if ( bounds.IsSameAs(vCurrBounds) && state == vCurrState ) {
				return false;
			}

			vCurrBounds = bounds;
			vCurrState = state;
			
			if ( ParentContainer != null ) {
				Vec3 cont = ParentContainer.CalculateCenter();
				bounds = bounds.NewOffsetCenter(cont);
			}

			MeshData = ParentLayout.GetSquare(bounds);
			return true;
		}

	}

}
