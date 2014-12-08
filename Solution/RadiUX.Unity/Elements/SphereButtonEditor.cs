using UnityEditor;

namespace RadiUX.Unity.Elements {

	/*================================================================================================*/
	[CustomEditor(typeof(SphereButton))]
	public class SphereButtonEditor : SphereSegmentEditor {

		//private SphereButton vButton;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void OnEnable() {
			base.OnEnable();
			//vButton = (SphereButton)target;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			base.OnInspectorGUI();
		}

	}

}
