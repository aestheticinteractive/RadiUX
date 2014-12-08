using RadiUX.Unity.Elements;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Actions {

	/*================================================================================================*/
	public class ActionElementCenter : ActionAnimBase<Vector3> {

		public GameObject TargetElement;
		public Vector3 Center;

		private IRadElement vElement;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();
			vElement = UnityUtil.FindSiblingComponent<IRadElement>(TargetElement);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void UpdateWithAnimValue(Vector3 pValue) {
			vElement.SetCenter(pValue);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Vector3 CalcProgressValue(Vector3 pFrom, Vector3 pTo, float pProgress) {
			return Vector3.Lerp(pFrom, pTo, pProgress);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Vector3 GetAnimFromValue() {
			return vElement.GetCenter();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Vector3 GetAnimToValue(Vector3 pFromValue) {
			return Center+(IsRelativeChange ? pFromValue : Vector3.zero);
		}

	}

}
