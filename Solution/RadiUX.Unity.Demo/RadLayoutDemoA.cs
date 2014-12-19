using System.Collections.Generic;
using RadiUX.Model.Structures;
using RadiUX.Unity.Actions;
using RadiUX.Unity.Elements;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	public class RadLayoutDemoA : MonoBehaviour {

		private IList<GameObject> vPanelList;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Awake() {
			RadLayout layout = gameObject.AddComponent<RadLayout>();
			layout.Center.y = 90;

			vPanelList = BuildFourPanels(gameObject);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			gameObject.transform.localRotation = 
				Quaternion.FromToRotation(Vector3.right, Vector3.forward)*
				Quaternion.FromToRotation(Vector3.up, Vector3.forward);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IList<GameObject> BuildFourPanels(GameObject pParent) {
			var list = new List<GameObject>();

			for ( int i = 0 ; i < 4 ; ++i ) {
				var panelObj = BuildPanel(pParent, i*90);

				BuildNavButton(panelObj, true);
				BuildNavButton(panelObj, false);

				for ( int j = 0 ; j <= i ; ++j ) {
					BuildSegment(panelObj, (j-i/2f)*6);
				}

				list.Add(panelObj);
			}

			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static GameObject BuildPanel(GameObject pParent, float pCenterX) {
			var panelObj = new GameObject("Panel"+pCenterX);
			panelObj.transform.parent = pParent.transform;

			RadContainer cont = panelObj.AddComponent<RadContainer>();
			cont.Center.x = pCenterX;

			return panelObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static GameObject BuildNavButton(GameObject pParent, bool pIsLeft) {
			var buttonObj = new GameObject("Button"+(pIsLeft ? "Left" : "Right"));
			buttonObj.transform.parent = pParent.transform;

			RadButton button = buttonObj.AddComponent<RadButton>();
			button.Center.x = 36*(pIsLeft ? -1 : 1);
			button.Width = 10;
			button.Height = 30;

			ActionLayoutRotation layoutRot = buttonObj.AddComponent<ActionLayoutRotation>();
			layoutRot.Event = ActionBase.EventType.Release;
			layoutRot.Rotation = Quaternion.AngleAxis(90*(pIsLeft ? -1 : 1), Vector3.up).eulerAngles;
			layoutRot.IsRelativeChange = true;
			layoutRot.Duration = 2000;
			layoutRot.Ease = Anim.Ease.InOut;
			layoutRot.EaseStrength = 3;

			buttonObj.renderer.material = new Material(UnityUtil.ShaderDiff);

			return buttonObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static GameObject BuildSegment(GameObject pParent, float pCenterX) {
			var segObj = new GameObject("Segment");
			segObj.transform.parent = pParent.transform;
			
			RadSegment seg = segObj.AddComponent<RadSegment>();
			seg.Center.x = pCenterX;
			seg.Center.y = -13;
			seg.Width = 4;
			seg.Height = 4;

			segObj.renderer.material = new Material(UnityUtil.ShaderDiff);
			return segObj;
		}

	}

}
