using System.Diagnostics;
using RadiUX.Model;
using RadiUX.Unity.Test;
using UnityEngine;

namespace RadiUX.Unity {

	/*================================================================================================*/
	public class RadiuxBehavior : MonoBehaviour {

		private App vApp;

		private Stopwatch vTimer;
		private int vFrameCount;
		private float vLastFps;
		private const float RefreshTime = 0.5f;
		private bool vShowFps;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Awake() {
			vApp = new App();
			vTimer = Stopwatch.StartNew();

			var camHold = new GameObject("Camera");
			var cam = camHold.AddComponent<Camera>();

			camHold.transform.LookAt(new Vector3(0, 0, 1));

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

			vApp.Destroy();
		}

	}

}
