using UnityEditor;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[CustomEditor(typeof(SquareTest))]
	public class SquareTestEditor : Editor {

		private SquareTest vComponent;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OnEnable() {
			vComponent = (SquareTest)target;
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void OnInspectorGUI() {
			vComponent.GridButtonSize = EditorGUILayout.Slider("Grid Button Size", 
				vComponent.GridButtonSize, 1.5f, 11.5f);
		}

	}

}
