using UnityEditor;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[CustomEditor(typeof(SphereLayout))]
	public class SphereLayoutEditor : Editor {

		private SphereLayout vItem;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OnEnable() {
			vItem = (SphereLayout)target;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			Undo.RecordObject(vItem, vItem.GetType().Name);

			vItem.Radius = EditorGUILayout.Slider("Radius", vItem.Radius, 1f, 10f);
			vItem.Quality = EditorGUILayout.Slider("Quality", vItem.Quality, 0.1f, 2f);

			if ( GUI.changed ) {
				EditorUtility.SetDirty(vItem);
			}
		}

	}

}
