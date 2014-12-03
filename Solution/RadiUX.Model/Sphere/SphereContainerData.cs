using RadiUX.Model.Structures;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class SphereContainerData {

		public SphereContainerData Parent { get; set; }
		public float CenterX { get; set; }
		public float CenterY { get; set; }
		public float CenterZ { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal string GetState() {
			return (Parent == null ? "" : Parent.GetState()+"|")+CenterX+","+CenterY+","+CenterZ;
		}

		/*--------------------------------------------------------------------------------------------*/
		internal Vec3 CalculateCenter() {
			var center = new Vec3(CenterX, CenterY, CenterZ);

			if ( Parent != null ) {
				center += Parent.CalculateCenter();
			}

			return center;
		}

	}

}
