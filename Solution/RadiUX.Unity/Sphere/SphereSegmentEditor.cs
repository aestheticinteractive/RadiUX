using UnityEditor;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[CustomEditor(typeof(SphereSegment))]
	public class SphereSegmentEditor : Editor {

		private SphereSegment vItem;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void OnEnable() {
			vItem = (SphereSegment)target;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			Undo.RecordObject(vItem, vItem.GetType().Name);

			vItem.CenterX = EditorGUILayout.Slider("Center X", vItem.CenterX, -180f, 180f);
			vItem.CenterY = EditorGUILayout.Slider("Center Y", vItem.CenterY, -180f, 180f);
			vItem.CenterZ = EditorGUILayout.Slider("Center Z", vItem.CenterZ, -10f, 10f);
			vItem.Width = EditorGUILayout.Slider("Width", vItem.Width, 0.1f, 360f);
			vItem.Height = EditorGUILayout.Slider("Height", vItem.Height, 0.1f, 180f);

			if ( GUI.changed ) {
				EditorUtility.SetDirty(vItem);
			}
		}

	}

}
