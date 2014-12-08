using RadiUX.Model.Structures;

namespace RadiUX.Model.Elements.Components {

	/*================================================================================================*/
	public struct State {

		public bool Visible;
		public bool Enabled;
		public bool Accessible; //false when blocked behind a modal/layer
		public bool Still; //false when in motion
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static State Apply(State pInheritedState, State pState) {
			var s = new State();
			s.Visible = (pInheritedState.Visible && pState.Visible);
			s.Enabled = (pInheritedState.Enabled && pState.Enabled);
			s.Accessible = (pInheritedState.Accessible && pState.Accessible);
			s.Still = (pInheritedState.Still && pState.Still);
			return s;
		}

	}

}
