using System;
using System.Diagnostics;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	public class FloatAnim : MonoBehaviour {

		private readonly Stopwatch vWatch;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FloatAnim() {
			vWatch = Stopwatch.StartNew();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			float totSec = (float)vWatch.Elapsed.TotalSeconds;
			float headY = (float)((Math.Cos(totSec/2f)+1)*3);

			gameObject.transform.localPosition = new Vector3(0, headY, 0);
			gameObject.transform.localRotation = Quaternion.AngleAxis(totSec, Vector3.up);
		}

	}

}
