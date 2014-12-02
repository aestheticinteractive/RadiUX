using RadiUX.Model.Sphere;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereLayout : MonoBehaviour, ISphereLayout {

		public float Radius = 4;
		public float Quality = 0.3f;

		public SphereLayoutData Data { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereLayout() {
			Data = new SphereLayoutData(Radius, Quality);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			Data.Radius = Radius;
			Data.Quality = Quality;
		}

	}

}
