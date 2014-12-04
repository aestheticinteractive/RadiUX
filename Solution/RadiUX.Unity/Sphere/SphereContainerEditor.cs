using UnityEditor;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[CustomEditor(typeof(SphereContainer))]
	public class SphereContainerEditor : Editor {

		private SphereContainer vContain;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void OnEnable() {
			vContain = (SphereContainer)target;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			Undo.RecordObject(vContain, vContain.GetType().Name);

			vContain.Center = EditorGUILayout.Vector3Field("Center", vContain.Center);

			if ( GUI.changed ) {
				EditorUtility.SetDirty(vContain);
			}
		}

	}

}
