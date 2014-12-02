namespace RadiUX.Model {

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
