using RadiUX.Model.Structures;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class SphereContainerData : SphereElementData {

		public SphereContainerData Parent { get; set; }
		public Vec3 Center { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereContainerData() {
			Center = new Vec3();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal virtual string GetState() {
			return (Parent == null ? "" : Parent.GetState()+"|")+Center.X+","+Center.Y+","+Center.Z;
		}

		/*--------------------------------------------------------------------------------------------*/
		internal Vec3 CalculateCenter() {
			var center = Center.Clone();

			if ( Parent != null ) {
				center += Parent.CalculateCenter();
			}

			return center;
		}

	}

}
