using UnityEditor;
using UnityEngine;

namespace RadiUX.Unity.Elements {

	/*================================================================================================*/
	[CustomEditor(typeof(SphereContainer))]
	public class SphereElementEditor : Editor {

		private SphereElement vElem;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void OnEnable() {
			vElem = (SphereElement)target;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			Undo.RecordObject(vElem, vElem.GetType().Name);

			vElem.Center = EditorGUILayout.Vector3Field("Center", vElem.Center);

			if ( GUI.changed ) {
				EditorUtility.SetDirty(vElem);
			}
		}

	}

}
