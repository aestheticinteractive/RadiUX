using System;

namespace RadiUX.Model.Structures {

	/*================================================================================================*/
	public class DegreeBounds {

		public Vec3 Center { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DegreeBounds() {
			Center = new Vec3();
		}

		/*--------------------------------------------------------------------------------------------*/
		public DegreeBounds(Vec3 pCenter, float pWidth, float pHeight) {
			Center = pCenter;
			Width = pWidth;
			Height = pHeight;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DegreeBounds(DegreeBounds pBounds) {
			Center = pBounds.Center;
			Width = pBounds.Width;
			Height = pBounds.Height;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool IsSameAs(DegreeBounds pBounds) {
			if ( pBounds == null ) {
				return false;
			}

			const float epsilon = 0.001f;

			return (
				Math.Abs(Center.X-pBounds.Center.X) < epsilon &&
				Math.Abs(Center.Y-pBounds.Center.Y) < epsilon &&
				Math.Abs(Center.Z-pBounds.Center.Z) < epsilon &&
				Math.Abs(Width-pBounds.Width) < epsilon &&
				Math.Abs(Height-pBounds.Height) < epsilon
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DegreeBounds NewOffsetCenter(Vec3 pOffset) {
			return new DegreeBounds(
				Center+pOffset,
				Width,
				Height
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		public DegreeBounds NewResized(float pWidth, float pHeight) {
			return new DegreeBounds(
				Center,
				pWidth,
				pHeight
			);
		}

	}

}
