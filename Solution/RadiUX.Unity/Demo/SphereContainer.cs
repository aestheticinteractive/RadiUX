using System;
using RadiUX.Model.Sphere;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereContainer : MonoBehaviour, ISphereContainer {

		public float CenterX = 0;
		public float CenterY = 0;
		public float CenterZ = 0;

		public SphereContainerData Data { get; private set; }

		private ISphereLayout vLayout;
		private ISphereContainer vContain;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereContainer() {
			Data = new SphereContainerData();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			FindParentsIfNecessary();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void FindParentsIfNecessary() {
			if ( vLayout != null ) {
				return;
			}

			vLayout = UnityUtil.FindParentComponent<ISphereLayout>(gameObject);
			vContain = UnityUtil.FindParentComponent<ISphereContainer>(gameObject);

			Data.Parent = (vContain == null ? null : vContain.Data);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			FindParentsIfNecessary();

			if ( vLayout == null ) {
				throw new Exception("This element must be contained within an ISphereLayout.");
			}

			Data.CenterX = CenterX;
			Data.CenterY = CenterY;
			Data.CenterZ = CenterZ;
		}

	}

}
