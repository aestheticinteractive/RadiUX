using System;
using RadiUX.Model.Sphere;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereContainer : MonoBehaviour, ISphereContainer {

		public Vector3 Center;
		public float CenterX;
		public float CenterY;
		public float CenterZ;

		public SphereContainerData Data { get; private set; }
		public ISphereLayout Layout { get; private set; }
		public ISphereContainer Container { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereContainer() {
			Data = new SphereContainerData();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected SphereContainer(SphereContainerData pData) {
			Data = pData;
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
			if ( Application.isPlaying && Layout != null ) {
				return;
			}

			Layout = UnityUtil.FindParentComponent<ISphereLayout>(gameObject);
			Container = UnityUtil.FindParentComponent<ISphereContainer>(gameObject);

			Data.Parent = (Container == null ? null : Container.Data);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Update() {
			FindParentsIfNecessary();

			if ( Layout == null && !IsLayout() ) {
				throw new Exception("This element must be contained within an ISphereLayout.");
			}

			Data.Center.X = Center.x;
			Data.Center.Y = Center.y;
			Data.Center.Z = Center.z;
		}

	}

}
