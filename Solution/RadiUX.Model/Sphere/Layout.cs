using RadiUX.Model.Structures;
using RadiUX.Model.Sphere.Components;
using System;
using System.Collections.Generic;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class Layout : Element {

		//public float Quality { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Layout() {
			//Quality = 0.333f;

			Transform t = Transform;
			t.Center.Z = 4f;
			UpdateTransform(t);
		}

	}

}
