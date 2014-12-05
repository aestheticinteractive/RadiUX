using RadiUX.Model.Structures;

namespace RadiUX.Unity.Action {

	/*================================================================================================*/
	public abstract class ActionAnimBase<T> : ActionBase {

		public bool IsRelativeChange;
		public float Duration;
		public Anim.Ease Ease;
		public float EaseStrength = 1;

		protected Anim<T> vAnim;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();

			if ( vAnim != null && vAnim.Active ) {
				UpdateWithAnimValue(vAnim.GetProgressValue());
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected abstract void UpdateWithAnimValue(T pValue);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void HandleActiveEvent() {
			if ( vAnim != null && vAnim.Active ) {
				return;
			}

			vAnim = new Anim<T>(Duration);
			vAnim.ProgressValueFunc = CalcProgressValue;
			vAnim.From = GetAnimFromValue();
			vAnim.To = GetAnimToValue(vAnim.From);
			vAnim.Start(Ease, EaseStrength);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract T CalcProgressValue(T pFrom, T pTo, float pProgress);

		/*--------------------------------------------------------------------------------------------*/
		protected abstract T GetAnimFromValue();

		/*--------------------------------------------------------------------------------------------*/
		protected abstract T GetAnimToValue(T pFromValue);

	}

}
