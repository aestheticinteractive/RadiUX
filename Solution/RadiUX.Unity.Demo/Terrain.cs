using System;
using RadiUX.Model.Structures;
using RadiUX.Unity.Util;
using UnityEngine;
using Random = System.Random;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	public class Terrain : MonoBehaviour {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Awake() {
			var meshData = new MeshData(null);
			var rand = new Random();

			const int size = 40;
			const int halfSize = size/2;

			for ( int xi = 0 ; xi < size ; ++xi ) {
				for ( int zi = 0 ; zi < size ; ++zi ) {
					float x = (xi-halfSize)*12;
					float z = (zi-halfSize)*12;

					float y = (Math.Abs(x)+Math.Abs(z))/6f;
					y -= (float)rand.NextDouble()*6;

					Vec3 v = new Vec3(x, y, z);
					var uv = new Vec2(zi/(float)size, xi/(float)size);

					meshData.Vertices.Add(v);
					meshData.UvCoordinates.Add(uv);

					if ( xi > 0 && zi > 0 ) {
						meshData.AddSquareFace(
							(xi-1)*size+zi-1,
							(xi-1)*size+zi,
							xi*size+zi-1,
							xi*size+zi
						);
					}
				}
			}

			////

			MeshFilter meshFilt = gameObject.GetComponent<MeshFilter>();
			MeshRenderer meshRend = gameObject.GetComponent<MeshRenderer>();

			if ( meshFilt == null ) {
				meshFilt = gameObject.AddComponent<MeshFilter>();
			}

			if ( meshRend == null ) {
				meshRend = gameObject.AddComponent<MeshRenderer>();
				meshRend.sharedMaterial = new Material(UnityUtil.ShaderDiff);
			}

			meshFilt.mesh = meshData.ToUnityMesh();
			meshRend.material.color = Color.green;
		}

	}

}
