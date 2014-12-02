using UnityEngine;
using Random = System.Random;

namespace RadiUX.Unity.Util {

	/*================================================================================================*/
	public static class MathUtil {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static float ClampFloat(float pValue, float pMin, float pMax) {
			return (pValue < pMin ? pMin : (pValue > pMax ? pMax : pValue));
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Vector3 GetRandomVector(Random pRand) {
			return new Vector3(
				(float)pRand.NextDouble()*2-1,
				(float)pRand.NextDouble()*2-1,
				(float)pRand.NextDouble()*2-1
			);
		}

	}

}
