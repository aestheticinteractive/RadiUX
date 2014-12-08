using RadiUX.Unity.Elements;
using UnityEditor;

namespace RadiUX.Unity.Editors.Elements {

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
