using RadiUX.Model.Structures;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereButton : SphereSegment {

		private readonly Anim<Color> vColorAnim;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereButton() {
			vColorAnim = new Anim<Color>(250);
			vColorAnim.ProgressValueFunc = Color.Lerp;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Start() {
			base.Start();

			if ( gameObject.GetComponent<MeshCollider>() == null ) {
				gameObject.AddComponent<MeshCollider>();
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			if ( vColorAnim.Active ) {
				renderer.material.color = vColorAnim.GetProgressValue();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterMeshUpdate() {
			gameObject.GetComponent<MeshCollider>().sharedMesh = 
				gameObject.GetComponent<MeshFilter>().sharedMesh;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void OnMouseEnter() {
			vColorAnim.From = renderer.material.color;
			vColorAnim.To = Color.red;
			vColorAnim.Start(Anim.Ease.Out);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void OnMouseExit() {
			vColorAnim.From = renderer.material.color;
			vColorAnim.To = Color.white;
			vColorAnim.Start(Anim.Ease.Out);
		}

	}

}
