using RadiUX.Model.Elements;
using UnityEngine;

namespace RadiUX.Unity.Elements {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class RadLayout : RadElement<Layout>, IRadLayout {

		//public float Radius = 4;
		//public float Quality = 0.3f;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RadLayout() {
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
