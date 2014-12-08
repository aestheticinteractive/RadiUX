using RadiUX.Unity.Elements;
using UnityEditor;
using UnityEngine;

namespace RadiUX.Unity.Editors.Elements {

	/*================================================================================================*/
	[CustomEditor(typeof(RadLayout))]
	public class RadLayoutEditor : RadElementEditor {

		private RadLayout vLayout;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void OnEnable() {
			base.OnEnable();
			vLayout = (RadLayout)target;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			base.OnInspectorGUI();

			Undo.RecordObject(vLayout, vLayout.GetType().Name);

			//vLayout.Radius = EditorGUILayout.Slider("Radius", vLayout.Radius, 1f, 10f);
			//vLayout.Quality = EditorGUILayout.Slider("Quality", vLayout.Quality, 0.1f, 2f);

			if ( GUI.changed ) {
				EditorUtility.SetDirty(vLayout);
			}
		}

	}

}
