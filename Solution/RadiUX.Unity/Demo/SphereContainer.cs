using RadiUX.Model.Sphere;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereContainer : MonoBehaviour, ISphereContainer {

		public float CenterX = 0;
		public float CenterY = 0;

		public SphereContainerData Data { get; private set; }

		private ISphereContainer vContain;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereContainer() {
			Data = new SphereContainerData();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			vContain = UnityUtil.FindParentComponent<ISphereContainer>(gameObject);

			if ( vContain != null ) {
				Data.Parent = vContain.Data;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			Data.CenterX = CenterX;
			Data.CenterY = CenterY;
		}

	}

}
