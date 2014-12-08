using RadiUX.Model.Structures;

namespace RadiUX.Model.Elements.Components {

	/*================================================================================================*/
	public struct Transform {

		public Vec3 Center;
		public Vec3 Scale;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool operator ==(Transform pA, Transform pB) {
			if ( pA.Center != pB.Center ) {
				return false;
			}

			if ( pA.Scale != pB.Scale ) {
				return false;
			}

			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static bool operator !=(Transform pA, Transform pB) {
			return !(pA == pB);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static Transform Apply(Transform pInheritedTransform, Transform pTransform) {
			var p = new Transform();
			p.Center = pInheritedTransform.Center+pTransform.Center;
			p.Scale = pInheritedTransform.Scale+pTransform.Scale;
			return p;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		internal virtual string GetState() {
			return (ParentContainer == null ? "" : ParentContainer.GetState()+"|")+
				Center.X+","+Center.Y+","+Center.Z;
		}
		
		/*--------------------------------------------------------------------------------------------* /
		internal Vec3 CalculateCenter() {
			var center = Center.Clone();
			
			if ( ParentContainer != null ) {
				center += ParentContainer.CalculateCenter();
			}
			
			return center;
		}*/

	}

}
