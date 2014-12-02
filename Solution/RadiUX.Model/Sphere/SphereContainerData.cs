namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class SphereContainerData {

		public SphereContainerData Parent { get; set; }
		public float CenterX { get; set; }
		public float CenterY { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal string GetState() {
			return (Parent == null ? "" : Parent.GetState())+"#"+CenterX+"|"+CenterY;
		}

		/*--------------------------------------------------------------------------------------------*/
		internal float CalculateCenterX() {
			return (Parent == null ? 0 : Parent.CalculateCenterX())+CenterX;
		}

		/*--------------------------------------------------------------------------------------------*/
		internal float CalculateCenterY() {
			return (Parent == null ? 0 : Parent.CalculateCenterY())+CenterY;
		}

	}

}
