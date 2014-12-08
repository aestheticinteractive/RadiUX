using RadiUX.Model.Structures;
using RadiUX.Model.Elements.Components;
using System;
using System.Collections.Generic;

namespace RadiUX.Model.Elements {

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
