
namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class SphereElementData {

		public bool Visible { get; set; }
		public bool Enabled { get; set; }
		public bool Accessible { get; set; } //false when blocked behind a modal/layer


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereElementData() {
			Visible = true;
			Enabled = true;
			Accessible = true;
		}

	}

}
