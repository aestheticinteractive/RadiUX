using System;
using RadiUX.Model.Sphere;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	[ExecuteInEditMode]
	public class SphereContainer : SphereElement<SphereContainerData>, ISphereContainer {


	}


	/*================================================================================================*/
	[ExecuteInEditMode]
	public abstract class SphereContainer<T> : SphereElement<T>, ISphereContainer<T>
																where T : SphereContainerData, new() {
		
		
	}

}
