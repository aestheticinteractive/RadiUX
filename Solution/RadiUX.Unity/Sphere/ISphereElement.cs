using RadiUX.Model.Sphere;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	public interface ISphereElement {

		bool IsSpinning { get; set; }
		
		ISphereLayout ParentLayout { get; }
		ISphereContainer ParentContainer { get; }
		
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		Vector3 GetCenter();

		/*--------------------------------------------------------------------------------------------*/
		void SetCenter(Vector3 pCenter);

	}

	
	/*================================================================================================*/
	public interface ISphereElement<T> : ISphereElement {
		
		T Data { get; }
		
	}

}
