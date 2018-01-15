using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace ReuseScroller
{
	public class TestHelper
	{
		public static GameObject CreateCanvas() {
			GameObject canvasObject = new GameObject("Canvas");
			canvasObject.layer = 5;
			Canvas canvas = canvasObject.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			canvasObject.AddComponent<CanvasScaler>();
			canvasObject.AddComponent<GraphicRaycaster>();
			return canvasObject;
		}

		public static GameObject CreateScrollView(Direction direction, bool reverse=false) {
			GameObject prefab = null;
			if (direction == Direction.Vertical) {
				prefab = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/ReuseScroller/Tests/Fixtures/ScrollViewVertical.prefab");
			} else if (direction == Direction.Horizontal) {
				prefab = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/ReuseScroller/Tests/Fixtures/ScrollViewHorizontal.prefab");
			}
			prefab.GetComponent<TestController>().scrollReverse = reverse;
			return GameObject.Instantiate(prefab);
		}

		public static LinkedList<BaseCell<TestItem>> GetCells(BaseController<TestItem> controller) {
			return typeof(BaseController<TestItem>).InvokeMember("cells", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, controller, null) as LinkedList<BaseCell<TestItem>>;
		}
	}
}
