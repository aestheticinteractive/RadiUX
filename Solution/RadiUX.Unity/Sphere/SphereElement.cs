using System;
using RadiUX.Model.Sphere;
using RadiUX.Model.Structures;
using RadiUX.Unity.Util;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace RadiUX.Unity.Sphere {
	
	/*================================================================================================*/
	[ExecuteInEditMode]
	public abstract class SphereElement : MonoBehaviour {

		public Vector3 Center;
		
	}


	/*================================================================================================*/
	[ExecuteInEditMode]
	public abstract class SphereElement<T> : SphereElement, ISphereElement<T> where T : Element, new(){
				
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
		public Vector3 GetCenter() {
			return Center+Vector3.zero;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetCenter(Vector3 pCenter) {
			Center = pCenter+Vector3.zero;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public Element GetElementData() {
			return Data;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Start() {
			FindChildren();
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void Update() {
			if ( !Application.isPlaying ) { //TODO: auto-update if the list of children changes (?)
				FindChildren();
			}

			var t = Data.Transform;
			t.Center = Center.ToRadiuxVector();
			Data.UpdateTransform(t);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void FindChildren() {
			IList<ISphereElement> children = UnityUtil.FindChildComponents<ISphereElement>(gameObject);

			Data.UpdateChildren(children.Select(x => x.GetElementData()).ToList());

			foreach ( ISphereElement se in children ) {
				se.FindChildren();
			}
		}

	}

}
