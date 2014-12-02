using RadiUX.Model;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereLayout1 : MonoBehaviour, ISphereLayout {

		public SphereMeshBuilder MeshBuild { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereLayout1() {
			MeshBuild = new SphereMeshBuilder(4);
		}

	}

}
