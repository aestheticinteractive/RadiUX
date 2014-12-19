using System;
using UnityEngine;

namespace RadiUX.Unity.Elements {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class RadCrosshair : MonoBehaviour {

		public Transform LookTransform;

		private GameObject vDot;
		private RadButton vCurrButton;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			if ( LookTransform == null ) {
				throw new Exception("LookTransform must be set.");
			}

			vDot = GameObject.CreatePrimitive(PrimitiveType.Quad);
			vDot.name = "Dot";
			vDot.transform.parent = gameObject.transform;
			vDot.transform.localPosition = Vector3.forward*3;
			vDot.transform.localRotation = Quaternion.identity;
			vDot.transform.localScale = Vector3.one*0.2f;
			vDot.GetComponent<MeshCollider>().enabled = false;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			if ( vDot == null ) {
				return;
			}

			gameObject.transform.position = LookTransform.position;
			gameObject.transform.rotation = LookTransform.rotation;

			UpdateTargetButton();
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void UpdateTargetButton() {
			RadButton btn = FindTargetButton();

			if ( btn != null && btn != vCurrButton ) {
				btn.OnMouseEnter();
			}

			if ( btn == null && vCurrButton != null ) {
				vCurrButton.OnMouseExit();
			}

			vCurrButton = btn;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private RadButton FindTargetButton() {
			Vector3 dir = vDot.transform.position-LookTransform.position;
			var ray = new Ray(LookTransform.position, dir);
			RaycastHit rayHit;

			if ( Physics.Raycast(ray, out rayHit) ) {
				return rayHit.collider.gameObject.GetComponent<RadButton>();
			}

			return null;
		}

	}

}
