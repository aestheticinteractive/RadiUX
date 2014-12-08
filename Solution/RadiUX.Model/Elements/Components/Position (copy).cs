using RadiUX.Model.Structures;

namespace RadiUX.Model.Elements.Components {

	/*================================================================================================*/
	public class Position {

		public Vec3 Center { get; set; }
		public bool IsAnimating { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Position() {
			Center = new Vec3();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		internal virtual string GetState() {
			return (ParentContainer == null ? "" : ParentContainer.GetState()+"|")+
				Center.X+","+Center.Y+","+Center.Z;
		}
		
		/*--------------------------------------------------------------------------------------------* /
		internal Vec3 CalculateCenter() {
			var center = Center.Clone();
			
			if ( ParentContainer != null ) {
				center += ParentContainer.CalculateCenter();
			}
			
			return center;
		}*/

	}

}
