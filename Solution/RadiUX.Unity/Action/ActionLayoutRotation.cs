using RadiUX.Model.Structures;
using RadiUX.Unity.Sphere;
using UnityEngine;

namespace RadiUX.Unity.Action {

	/*================================================================================================*/
	public class ActionLayoutRotation : ActionBase {

		public Vector3 Rotation;
		public bool IsRelativeChange;
		public float Duration;
		public Anim.Ease Ease;
		public float EaseStrength = 1;

		private Anim<Quaternion> vAnim;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();

			if ( vAnim != null && vAnim.Active ) {
				ISphereLayout layout = GetLayout();
				Quaternion q = vAnim.GetProgressValue();
				(layout as MonoBehaviour).gameObject.transform.localRotation = q;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void HandleActiveEvent() {
			if ( vAnim != null && vAnim.Active ) {
				return;
			}

			ISphereLayout layout = GetLayout();

			if ( layout.IsSpinning ) {
				return;
			}

			vAnim = new Anim<Quaternion>(Duration);
			vAnim.ProgressValueFunc = Quaternion.Slerp;
			vAnim.From = (layout as MonoBehaviour).gameObject.transform.localRotation;
			vAnim.To = Quaternion.Euler(Rotation)*(IsRelativeChange ? vAnim.From : Quaternion.identity);
			vAnim.Start(Ease, EaseStrength);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ISphereLayout GetLayout() {
			return (Segment != null ? Segment.Layout : Container.Layout);
		}

	}

}
