using System;
using System.Collections.Generic;
using System.Diagnostics;
using RadiUX.Model.Structures;
using RadiUX.Unity.Action;
using RadiUX.Unity.Sphere;
using RadiUX.Unity.Util;
using UnityEngine;
using Random = System.Random;

namespace RadiUX.Unity.Demo {

	/*================================================================================================*/
	public class TerrainDemo : MonoBehaviour {

		private readonly Stopwatch vWatch;

		private GameObject vTerrainObj;
		private GameObject vHeadObj;
		private GameObject vLayoutObj;
		private IList<GameObject> vPanelList;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TerrainDemo() {
			vWatch = Stopwatch.StartNew();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Awake() {
			vTerrainObj = BuildTerrain(gameObject);
			vHeadObj = BuildHead(gameObject);
			vLayoutObj = BuildLayout(vHeadObj);
			vPanelList = BuildFourPanels(vLayoutObj);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void Start() {
			vTerrainObj.transform.localPosition = new Vector3(0, -5, 0);

			vLayoutObj.transform.localRotation = 
				Quaternion.FromToRotation(Vector3.right, Vector3.forward)*
				Quaternion.FromToRotation(Vector3.up, Vector3.forward);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Update() {
			float totSec = (float)vWatch.Elapsed.TotalSeconds;
			float headY = (float)((Math.Cos(totSec/2f)+1)*3);

			vHeadObj.transform.localPosition = new Vector3(0, headY, 0);
			vHeadObj.transform.localRotation = Quaternion.AngleAxis(totSec, Vector3.up);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static GameObject BuildTerrain(GameObject pParent) {
			var terrObj = new GameObject("Terrain");
			terrObj.transform.parent = pParent.transform;

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

			MeshFilter meshFilt = terrObj.AddComponent<MeshFilter>();
			meshFilt.mesh = meshData.ToUnityMesh();

			MeshRenderer meshRend = terrObj.AddComponent<MeshRenderer>();
			meshRend.material = new Material(UnityUtil.ShaderDiff);
			meshRend.material.color = Color.green;

			return terrObj;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static GameObject BuildHead(GameObject pParent) {
			var headObj = new GameObject("Head");
			headObj.transform.parent = pParent.transform;

			var cameraObj = new GameObject("Camera");
			cameraObj.transform.parent = headObj.transform;

			var camera = cameraObj.AddComponent<Camera>();

			return headObj;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static GameObject BuildLayout(GameObject pParent) {
			var layoutObj = new GameObject("Layout");
			layoutObj.transform.parent = pParent.transform;

			SphereLayout layout = layoutObj.AddComponent<SphereLayout>();
			layout.Center.y = 90;

			return layoutObj;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private static IList<GameObject> BuildFourPanels(GameObject pParent) {
			var list = new List<GameObject>();

			for ( int i = 0 ; i < 4 ; ++i ) {
				var panelObj = BuildPanel(pParent, i*90);

				BuildNavButton(panelObj, true);
				BuildNavButton(panelObj, false);

				for ( int j = 0 ; j <= i ; ++j ) {
					BuildSegment(panelObj, (j-i/2f)*6);
				}

				list.Add(panelObj);
			}

			return list;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static GameObject BuildPanel(GameObject pParent, float pCenterX) {
			var panelObj = new GameObject("Panel"+pCenterX);
			panelObj.transform.parent = pParent.transform;

			SphereContainer cont = panelObj.AddComponent<SphereContainer>();
			cont.Center.x = pCenterX;

			return panelObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static GameObject BuildNavButton(GameObject pParent, bool pIsLeft) {
			var buttonObj = new GameObject("Button"+(pIsLeft ? "Left" : "Right"));
			buttonObj.transform.parent = pParent.transform;

			SphereButton button = buttonObj.AddComponent<SphereButton>();
			button.Center.x = 36*(pIsLeft ? -1 : 1);
			button.Width = 10;
			button.Height = 30;

			ActionLayoutRotation layoutRot = buttonObj.AddComponent<ActionLayoutRotation>();
			layoutRot.Event = ActionBase.EventType.Release;
			layoutRot.Rotation = Quaternion.AngleAxis(90*(pIsLeft ? -1 : 1), Vector3.up).eulerAngles;
			layoutRot.IsRelativeChange = true;
			layoutRot.Duration = 2000;
			layoutRot.Ease = Anim.Ease.InOut;
			layoutRot.EaseStrength = 3;

			buttonObj.renderer.material = new Material(UnityUtil.ShaderDiff);

			return buttonObj;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static GameObject BuildSegment(GameObject pParent, float pCenterX) {
			var segObj = new GameObject("Segment");
			segObj.transform.parent = pParent.transform;
			
			SphereSegment seg = segObj.AddComponent<SphereSegment>();
			seg.Center.x = pCenterX;
			seg.Center.y = -13;
			seg.Width = 4;
			seg.Height = 4;

			segObj.renderer.material = new Material(UnityUtil.ShaderDiff);
			return segObj;
		}

	}

}
