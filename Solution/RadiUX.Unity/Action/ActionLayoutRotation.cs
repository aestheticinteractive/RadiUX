using RadiUX.Unity.Sphere;
using UnityEngine;

namespace RadiUX.Unity.Action {

	/*================================================================================================*/
	public class ActionLayoutRotation : ActionAnimBase<Quaternion> {

		public Vector3 Rotation;


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
		protected override void UpdateWithAnimValue(Quaternion pValue) {
			ISphereLayout layout = GetLayout();
			(layout as MonoBehaviour).gameObject.transform.localRotation = pValue;
			layout.IsSpinning = vAnim.Active;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override Quaternion CalcProgressValue(Quaternion pFrom, Quaternion pTo, float pProgress) {
			return Quaternion.Slerp(pFrom, pTo, pProgress);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Quaternion GetAnimFromValue() {
			return (GetLayout() as MonoBehaviour).gameObject.transform.localRotation;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Quaternion GetAnimToValue(Quaternion pFromValue) {
			return Quaternion.Euler(Rotation)*(IsRelativeChange ? pFromValue : Quaternion.identity);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private ISphereLayout GetLayout() {
			return (Segment != null ? Segment.Layout : Container.Layout);
		}

	}

}
