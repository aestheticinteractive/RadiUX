using RadiUX.Model.Elements;
using UnityEngine;

namespace RadiUX.Unity.Elements {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class RadLayout : RadElement<Layout>, IRadLayout {

		public Transform LookTransform;

		private GameObject vCrossHold;
		private GameObject vCross;
		private RadButton vCurrButton;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RadLayout() {
			Center.z = Data.Transform.Center.Z;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Awake() {
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Start() {
			base.Start();

			if ( LookTransform != null ) {
				vCrossHold = new GameObject("CrosshairHold");
				vCrossHold.transform.parent = gameObject.transform;

				vCross = GameObject.CreatePrimitive(PrimitiveType.Quad);
				vCross.name = "Crosshair";
				vCross.transform.parent = vCrossHold.transform;
				vCross.transform.localPosition = Vector3.forward*3;
				vCross.transform.localScale = Vector3.one*0.2f;
				vCross.GetComponent<MeshCollider>().enabled = false;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();

			bool hitBtn = false;

			if ( vCrossHold != null ) {
				vCrossHold.transform.position = LookTransform.position;
				vCrossHold.transform.rotation = LookTransform.rotation;

				Vector3 dir = vCross.transform.position-LookTransform.position;
				var ray = new Ray(LookTransform.position, dir);
				RaycastHit rayHit;

				if ( Physics.Raycast(ray, out rayHit) ) {
					RadButton btn = rayHit.collider.gameObject.GetComponent<RadButton>();

					if ( btn != null ) {
						hitBtn = true;

						if ( btn != vCurrButton ) {
							btn.OnMouseEnter();
							vCurrButton = btn;
						}
					}
				}
			}

			if ( !hitBtn && vCurrButton != null ) {
				vCurrButton.OnMouseExit();
				vCurrButton = null;
			}
		}

	}

}
