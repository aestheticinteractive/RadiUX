using RadiUX.Unity.Elements;
using UnityEditor;
using UnityEngine;

namespace RadiUX.Unity.Editors.Elements {

	/*================================================================================================*/
	[CustomEditor(typeof(SphereContainer))]
	public class SphereContainerEditor : SphereElementEditor {

		//private SphereContainer vContain;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void OnEnable() {
			base.OnEnable();
			//vContain = (SphereContainer)target;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			base.OnInspectorGUI();
		}

	}

}
