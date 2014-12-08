using RadiUX.Model.Structures;
using UnityEngine;

namespace RadiUX.Unity.Elements {

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
			base.Update();

			if ( vColorAnim.Active ) {
				renderer.material.color = vColorAnim.GetProgressValue();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterMeshUpdate() {
			MeshCollider mc = gameObject.GetComponent<MeshCollider>();
			mc.sharedMesh = null;
			mc.sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
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
