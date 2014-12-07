using RadiUX.Model.Sphere;

namespace RadiUX.Unity.Sphere {

	/*================================================================================================*/
	public interface ISphereContainer {

	}

	
	/*================================================================================================*/
	public interface ISphereContainer<T> : ISphereContainer, ISphereElement<T> {
		
	}

}
