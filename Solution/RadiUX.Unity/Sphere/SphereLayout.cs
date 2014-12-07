using RadiUX.Model.Sphere;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereLayout : SphereContainer<SphereLayoutData>, ISphereLayout {

		public float Radius = 4;
		public float Quality = 0.3f;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereLayout() {
			Data.Radius = Radius;
			Data.Quality = Quality;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();

			Data.Radius = Radius;
			Data.Quality = Quality;
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool FindParentsIfNecessary(bool pRequire) {
			return false;
		}

	}

}
