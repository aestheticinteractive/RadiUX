using RadiUX.Unity.Elements;
using UnityEditor;
using UnityEngine;

namespace RadiUX.Unity.Editors.Elements {

	/*================================================================================================*/
	[CustomEditor(typeof(RadContainer))]
	public class RadElementEditor : Editor {

		private RadElement vElem;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void OnEnable() {
			vElem = (RadElement)target;
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
