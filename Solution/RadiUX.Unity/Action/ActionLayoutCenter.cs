using RadiUX.Unity.Sphere;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Action {

	/*================================================================================================*/
	public class ActionLayoutCenter : ActionAnimBase<Vector3> {

		public Vector3 Center;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void HandleActiveEvent() {
			ISphereLayout layout = GetLayout();

			if ( layout.IsSpinning ) {
				return;
			}

			base.HandleActiveEvent();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void UpdateWithAnimValue(Vector3 pValue) {
			ISphereLayout layout = GetLayout();
			layout.SetCenter(pValue);
			layout.IsSpinning = vAnim.Active;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Vector3 CalcProgressValue(Vector3 pFrom, Vector3 pTo, float pProgress) {
			return Vector3.Lerp(pFrom, pTo, pProgress);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Vector3 GetAnimFromValue() {
			return GetLayout().Data.Center.ToUnityVector();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Vector3 GetAnimToValue(Vector3 pFromValue) {
			return Center+(IsRelativeChange ? pFromValue : Vector3.zero);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private ISphereLayout GetLayout() {
			return (Segment != null ? Segment.ParentLayout : Container.ParentLayout);
		}

	}

}
