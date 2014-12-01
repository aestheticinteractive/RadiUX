using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Shared {

	/*================================================================================================*/
	public class UiQuadLine : UiBase {

		private readonly Quaternion vQuadRotation;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UiQuadLine(bool pFlipped=false) : base(false) {
			vQuadRotation = Quaternion.identity; //UnityUtil.RotationQuadFaceUp;

			if ( pFlipped ) {
				vQuadRotation *= Quaternion.FromToRotation(Vector3.up, Vector3.down);
			}

			SetGameObject(UnityUtil.CreateNonCollisionQuad());
			GameObj.name = GetType().Name;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Configure(Vector3 pFrom, Vector3 pTo, float pThickness) {
			Vector3 diff = pTo-pFrom;
			float len = diff.magnitude;

			GameObj.transform.localRotation = 
				Quaternion.FromToRotation(Vector3.right, diff)*vQuadRotation;

			GameObj.transform.localPosition = pFrom+diff*0.5f;
			GameObj.transform.localScale = new Vector3(len, pThickness, 1);
		}

	}

}
