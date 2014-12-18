using RadiUX.Unity.Elements;
using UnityEditor;

namespace RadiUX.Unity.Editors.Elements {

	/*================================================================================================*/
	[CustomEditor(typeof(RadButton))]
	public class RadButtonEditor : RadSegmentEditor {

		//private RadButton vButton;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void OnEnable() {
			base.OnEnable();
			//vButton = (RadButton)target;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			base.OnInspectorGUI();
		}

	}

}
