using RadiUX.Model.Structures;
using RadiUX.Unity.Sphere;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Action {

	/*================================================================================================*/
	public class ActionLayoutCenter : ActionBase {

		public Vector3 Center;
		public bool IsRelativeChange;
		public float Duration;
		public Anim.Ease Ease;
		public float EaseStrength = 1;

		private Anim<Vector3> vAnim;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();

			if ( vAnim != null && vAnim.Active ) {
				ISphereLayout layout = GetLayout();
				Vector3 c = vAnim.GetProgressValue();
				layout.SetCenter(c);
				layout.IsSpinning = vAnim.Active;
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

			vAnim = new Anim<Vector3>(Duration);
			vAnim.ProgressValueFunc = Vector3.Lerp;
			vAnim.From = layout.Data.Center.ToUnityVector();
			vAnim.To = Center+(IsRelativeChange ? vAnim.From : Vector3.zero);
			vAnim.Start(Ease, EaseStrength);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ISphereLayout GetLayout() {
			return (Segment != null ? Segment.Layout : Container.Layout);
		}

	}

}
