using RadiUX.Model.Sphere;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereLayout1 : MonoBehaviour, ISphereLayout {

		public SphereLayoutData Data { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereLayout1() {
			Data = new SphereLayoutData(4f, 0.3f);
		}

	}

}
