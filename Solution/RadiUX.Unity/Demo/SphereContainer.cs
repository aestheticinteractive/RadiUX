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

		/*--------------------------------------------------------------------------------------------*/
		protected virtual bool IsLayout() {
			return false;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			FindParentsIfNecessary();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void FindParentsIfNecessary() {
			if ( Application.isPlaying && vLayout != null ) {
				return;
			}

			vLayout = UnityUtil.FindParentComponent<ISphereLayout>(gameObject);
			vContain = UnityUtil.FindParentComponent<ISphereContainer>(gameObject);

			Data.Parent = (vContain == null ? null : vContain.Data);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Update() {
			FindParentsIfNecessary();

			if ( vLayout == null && !IsLayout() ) {
				throw new Exception("This element must be contained within an ISphereLayout.");
			}

			Data.Center.X = CenterX;
			Data.Center.Y = CenterY;
			Data.Center.Z = CenterZ;
		}

	}

}
