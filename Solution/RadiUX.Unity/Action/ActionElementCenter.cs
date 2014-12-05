using RadiUX.Unity.Sphere;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Action {

	/*================================================================================================*/
	public class ActionElementCenter : ActionAnimBase<Vector3> {

		public GameObject Element;
		public Vector3 Center;

		private SphereContainer vContain;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();
			vContain = UnityUtil.FindSiblingComponent<SphereContainer>(Element);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void UpdateWithAnimValue(Vector3 pValue) {
			vContain.Center = pValue;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Vector3 CalcProgressValue(Vector3 pFrom, Vector3 pTo, float pProgress) {
			return Vector3.Lerp(pFrom, pTo, pProgress);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Vector3 GetAnimFromValue() {
			return vContain.Center;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Vector3 GetAnimToValue(Vector3 pFromValue) {
			return Center+(IsRelativeChange ? pFromValue : Vector3.zero);
		}

	}

}
