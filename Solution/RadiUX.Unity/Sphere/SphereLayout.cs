using RadiUX.Model.Sphere;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereLayout : SphereElement<Layout>, ISphereLayout {

		//public float Radius = 4;
		//public float Quality = 0.3f;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereLayout() {
			Center.z = Data.Transform.Center.Z;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();

			//Data.Radius = Radius;
			//Data.Quality = Quality;
		}

	}

}
