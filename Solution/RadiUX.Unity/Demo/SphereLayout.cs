using RadiUX.Model.Sphere;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereLayout : SphereContainer, ISphereLayout {

		public float Radius = 4;
		public float Quality = 0.3f;

		public new SphereLayoutData Data { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereLayout() {
			Data = new SphereLayoutData(Radius, Quality);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool IsLayout() {
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void FindParentsIfNecessary() {
			//do nothing
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();
			Data.Radius = Radius;
			Data.Quality = Quality;
		}

	}

}
