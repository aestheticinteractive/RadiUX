using System.Diagnostics;
using RadiUX.Unity.Demo;
using UnityEngine;

namespace RadiUX.Unity {

	/*================================================================================================*/
	public class RadiuxBehavior : MonoBehaviour {

		private Stopwatch vTimer;
		private int vFrameCount;
		private float vLastFps;
		private const float RefreshTime = 0.5f;
		private bool vShowFps;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Awake() {
			vTimer = Stopwatch.StartNew();

			var squareTest = new SquareTest();
			squareTest.GameObj.transform.parent = transform;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			if ( Input.GetKeyUp(KeyCode.F) ) {
				vShowFps = !vShowFps;
			}

			if ( vTimer.Elapsed.TotalSeconds < RefreshTime ) {
				vFrameCount++;
			}
			else {
				vLastFps = vFrameCount/(float)vTimer.Elapsed.TotalSeconds;
				vFrameCount = 0;
				vTimer.Reset();
				vTimer.Start();
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OnGUI() {
			if ( vShowFps ) {
				GUI.Label(new Rect(2, 0, 80, 22), (int)vLastFps+" fps");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OnApplicationFocus(bool pIsFocused) {
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void OnApplicationQuit() {
			enabled = false;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OnDestroy() {
			if ( !enabled ) {
				return;
			}
		}

	}

}
