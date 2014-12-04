using RadiUX.Model.Sphere;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	public interface ISphereLayout {

		SphereLayoutData Data { get; }
		bool IsSpinning { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetCenter(Vector3 pCenter);

	}

}
