using System;
using UnityEngine;

namespace RadiUX.Unity.Shared {

	/*================================================================================================*/
	public class UiBase {

		public GameObject GameObj { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UiBase(bool pBuildGameObject=true) {
			if ( pBuildGameObject ) {
				GameObj = new GameObject(GetName());
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected string GetName() {
			return GetType().Name;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void AddChild(UiBase pChild) {
			pChild.GameObj.transform.parent = GameObj.transform;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void AddChild(GameObject pChild) {
			pChild.transform.parent = GameObj.transform;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected void SetGameObject(GameObject pGameObj) {
			if ( GameObj != null ) {
				throw new Exception("GameObj is already set.");
			}

			GameObj = pGameObj;
		}

	}

}
