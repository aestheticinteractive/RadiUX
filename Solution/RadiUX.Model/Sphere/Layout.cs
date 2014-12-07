using RadiUX.Model.Structures;
using RadiUX.Model.Sphere.Components;
using System;
using System.Collections.Generic;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public class Layout : Element {

		public float Radius { get; set; }
		public float Quality { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Layout() {
			Radius = 4;
			Quality = 0.333f;
		}

	}

}
