using RadiUX.Unity.Elements;
using UnityEditor;
using UnityEngine;

namespace RadiUX.Unity.Editors.Elements {

	/*================================================================================================*/
	[CustomEditor(typeof(RadSegment))]
	public class RadSegmentEditor : RadElementEditor {

		private RadSegment vSeg;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void OnEnable() {
			base.OnEnable();
			vSeg = (RadSegment)target;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			base.OnInspectorGUI();

			Undo.RecordObject(vSeg, vSeg.GetType().Name);

			vSeg.Width = EditorGUILayout.Slider("Width", vSeg.Width, 0.1f, 360f);
			vSeg.Height = EditorGUILayout.Slider("Height", vSeg.Height, 0.1f, 180f);

			if ( GUI.changed ) {
				EditorUtility.SetDirty(vSeg);
			}
		}

	}

}
