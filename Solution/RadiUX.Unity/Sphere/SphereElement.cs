using System;
using RadiUX.Model.Sphere;
using RadiUX.Model.Structures;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Sphere {
	
	/*================================================================================================*/
	[ExecuteInEditMode]
	public abstract class SphereElement : MonoBehaviour, ISphereElement {

		public Vector3 Center;

		public bool IsSpinning { get; set; }
		
		public ISphereLayout ParentLayout { get; private set; }
		public ISphereContainer ParentContainer { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Vector3 GetCenter() {
			return Center+Vector3.zero;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetCenter(Vector3 pCenter) {
			Center = pCenter+Vector3.zero;
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual bool FindParentsIfNecessary(bool pRequire) {
			if ( Application.isPlaying && ParentLayout != null ) {
				return false;
			}
			
			ParentLayout = UnityUtil.FindParentComponent<ISphereLayout>(gameObject);
			ParentContainer = UnityUtil.FindParentComponent<ISphereContainer>(gameObject);

			if ( pRequire && ParentLayout == null ) {
				throw new Exception(typeof(ISphereElement).Name+" must be contained within "+
					typeof(ISphereLayout).Name+".");
			}
			
			return true;
		}

	}


	/*================================================================================================*/
	[ExecuteInEditMode]
	public abstract class SphereElement<T> : SphereElement, ISphereElement<T> 
																where T : SphereElementData, new() {

		public T Data { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected SphereElement() {
			Data = new T();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected SphereElement(T pData) {
			Data = pData;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Start() {
			FindParentsIfNecessary(false);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void Update() {
			Data.Center.X = Center.x;
			Data.Center.Y = Center.y;
			Data.Center.Z = Center.z;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void LateUpdate() {
			FindParentsIfNecessary(true);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool FindParentsIfNecessary(bool pRequire) {
			bool found = base.FindParentsIfNecessary(pRequire);

			if ( found ) {
				Data.ParentLayout = (ParentLayout == null ? null : ParentLayout.Data);
				Data.ParentContainer = (ParentContainer == null ? null : ParentContainer.Data);
			}

			return found;
		}

	}

}
