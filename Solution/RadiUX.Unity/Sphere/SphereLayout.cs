using RadiUX.Model.Sphere;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereLayout : SphereContainer, ISphereLayout {

		public float Radius = 4;
		public float Quality = 0.3f;

		public new SphereLayoutData Data {
			get {
				return (SphereLayoutData)base.Data;
			}
		}

		public bool IsSpinning { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SphereLayout() : base(new SphereLayoutData(0, 0)) {
			Data.Radius = Radius;
			Data.Quality = Quality;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetCenter(Vector3 pCenter) {
			Center = pCenter;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override bool IsLayout() {
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void FindParentsIfNecessary() {
			//do nothing
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Update() {
			base.Update();
			Data.Radius = Radius;
			Data.Quality = Quality;
		}

	}

}
