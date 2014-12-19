using RadiUX.Model.Elements;
using UnityEngine;

namespace RadiUX.Unity.Elements {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class RadLayout : RadElement<Layout>, IRadLayout {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RadLayout() {
			Center.z = Data.Transform.Center.Z;
		}

	}

}
