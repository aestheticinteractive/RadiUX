using System;

namespace RadiUX.Model.Structures {

	/*================================================================================================*/
	public class DegreeBounds {

		public float CenterX { get; set; }
		public float CenterY { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DegreeBounds() {
		}

		/*--------------------------------------------------------------------------------------------*/
		public DegreeBounds(float pCenterX, float pCenterY, float pWidth, float pHeight) {
			CenterX = pCenterX;
			CenterY = pCenterY;
			Width = pWidth;
			Height = pHeight;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DegreeBounds(DegreeBounds pBounds) {
			CenterX = pBounds.CenterX;
			CenterY = pBounds.CenterY;
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
				Math.Abs(CenterX-pBounds.CenterX) < epsilon &&
				Math.Abs(CenterY-pBounds.CenterY) < epsilon &&
				Math.Abs(Width-pBounds.Width) < epsilon &&
				Math.Abs(Height-pBounds.Height) < epsilon
			);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DegreeBounds NewOffsetCenter(float pCenterXDiff, float pCenterYDiff) {
			return new DegreeBounds(
				CenterX+pCenterXDiff,
				CenterY+pCenterYDiff,
				Width,
				Height
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		public DegreeBounds NewResized(float pWidth, float pHeight) {
			return new DegreeBounds(
				CenterX,
				CenterY,
				pWidth,
				pHeight
			);
		}

	}

}
