using RadiUX.Unity.Elements;

namespace RadiUX.Unity.Actions {

	/*================================================================================================*/
	public interface IActionBase {

		IRadSegment Segment { get; }
		IRadContainer Container { get;  }
		IRadLayout Layout { get; }

	}

}
