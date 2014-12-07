﻿using UnityEditor;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[CustomEditor(typeof(SphereSegment))]
	public class SphereSegmentEditor : SphereElementEditor {

		private SphereSegment vSeg;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void OnEnable() {
			vSeg = (SphereSegment)target;
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
