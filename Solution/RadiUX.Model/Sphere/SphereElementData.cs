using RadiUX.Model.Structures;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class SphereElementData {

		public bool Visible { get; set; }
		public bool Enabled { get; set; }
		public bool Accessible { get; set; } //false when blocked behind a modal/layer

		public Vec3 Center { get; set; }
		
		public SphereLayoutData ParentLayout { get; set; }
		public SphereContainerData ParentContainer { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereElementData() {
			Visible = true;
			Enabled = true;
			Accessible = true;

			Center = new Vec3();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal virtual string GetState() {
			return (ParentContainer == null ? "" : ParentContainer.GetState()+"|")+
				Center.X+","+Center.Y+","+Center.Z;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		internal Vec3 CalculateCenter() {
			var center = Center.Clone();
			
			if ( ParentContainer != null ) {
				center += ParentContainer.CalculateCenter();
			}
			
			return center;
		}

	}

}
