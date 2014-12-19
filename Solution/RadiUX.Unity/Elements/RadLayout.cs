using RadiUX.Model.Elements;
using UnityEngine;

namespace RadiUX.Unity.Elements {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class RadLayout : RadElement<Layout>, IRadLayout {

		public Transform LookTransform;

		private GameObject vCrossHold;
		private GameObject vCross;


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

			if ( vCrossHold != null ) {
				vCrossHold.transform.position = LookTransform.position;
				vCrossHold.transform.rotation = LookTransform.rotation;

				Vector3 dir = vCross.transform.position-LookTransform.position;
				var ray = new Ray(LookTransform.position, dir);
				RaycastHit rayHit;

				if ( Physics.Raycast(ray, out rayHit) ) {
					Debug.Log("HIT: "+rayHit.collider.gameObject.name);
				}
			}
		}

	}

}
