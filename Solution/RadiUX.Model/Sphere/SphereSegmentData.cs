using System;
using RadiUX.Model.Structures;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class SphereSegmentData {

		public DegreeBounds Bounds { get; set; }
		public SphereLayoutData Layout { get; set; }
		public SphereContainerData Container { get; set; }
		public MeshData MeshData { get; set; }

		private DegreeBounds vCurrBounds;
		private string vCurrState;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool RebuildMeshDataIfNecessary() {
			if ( Bounds == null ) {
				throw new ArgumentNullException("Bounds");
			}

			if ( Layout == null ) {
				throw new ArgumentNullException("Layout");
			}

			string state = Layout.GetState();

			if ( Container != null ) {
				state += "*"+Container.GetState();
			}

			if ( Bounds.IsSameAs(vCurrBounds) && state == vCurrState ) {
				return false;
			}

			vCurrBounds = new DegreeBounds(Bounds);
			vCurrState = state;

			float contX = Container.CalculateCenterX();
			float contY = Container.CalculateCenterY();
			DegreeBounds b = Bounds.NewOffsetCenter(contX, contY);

			MeshData = Layout.GetSquare(b);
			return true;
		}

	}

}
