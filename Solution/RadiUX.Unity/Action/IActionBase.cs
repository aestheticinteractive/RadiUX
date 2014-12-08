using RadiUX.Unity.Elements;

namespace RadiUX.Unity.Action {

	/*================================================================================================*/
	public interface IActionBase {

		ISphereSegment Segment { get; }
		ISphereContainer Container { get;  }
		ISphereLayout Layout { get; }

	}

}
