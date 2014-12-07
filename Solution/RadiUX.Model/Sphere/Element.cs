using RadiUX.Model.Sphere.Components;
using RadiUX.Model.Structures;
using System.Collections.Generic;

namespace RadiUX.Model.Sphere {

	/*================================================================================================*/
	public abstract class Element {

		public State InheritedState { get; internal set; }
		public Transform InheritedTransform { get; internal set; }

		public State State { get; private set; }
		public Transform Transform { get; private set; }

		public IList<Element> Children { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Element() {
			var state = new State();
			state.Visible = true;
			state.Enabled = true;
			state.Accessible = true;
			state.Still = true;
			State = state;

			var trans = new Transform();
			trans.Center = new Vec3();
			Transform = trans;

			Children = new List<Element>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void UpdateChildren(IList<Element> pChildren) {
			Children = pChildren;
			SendInheritedState();
			SendInheritedTransform();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateState(State pState) {
			State = pState;
			SendInheritedState();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateTransform(Transform pTransform) {
			Transform = pTransform;
			SendInheritedTransform();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal void SendInheritedState() {
			State state = State.Apply(InheritedState, State);

			foreach ( Element e in Children ) {
				e.InheritedState = state;
				e.SendInheritedState();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		internal void SendInheritedTransform() {
			Transform trans = Transform.Apply(InheritedTransform, Transform);
			
			foreach ( Element e in Children ) {
				e.InheritedTransform = trans;
				e.SendInheritedTransform();
			}
		}

	}

}
