using System;
using RadiUX.Model.Elements;
using RadiUX.Model.Structures;
using RadiUX.Unity.Util;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace RadiUX.Unity.Elements {
	
	/*================================================================================================*/
	[ExecuteInEditMode]
	public abstract class RadElement : MonoBehaviour {

		public Vector3 Center;
		
	}


	/*================================================================================================*/
	[ExecuteInEditMode]
	public abstract class RadElement<T> : RadElement, IRadElement<T> where T : Element, new(){
				
		public T Data { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected RadElement() {
			Data = new T();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected RadElement(T pData) {
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
			IList<IRadElement> children = UnityUtil.FindChildComponents<IRadElement>(gameObject);

			Data.UpdateChildren(children.Select(x => x.GetElementData()).ToList());

			foreach ( IRadElement se in children ) {
				se.FindChildren();
			}
		}

	}

}
