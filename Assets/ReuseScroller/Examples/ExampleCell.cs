using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReuseScroller
{
	[System.Serializable]
	public struct ExampleItem {
		public string name;
	}

	public class ExampleCell : BaseCell<ExampleItem>
	{
		public Text label;

		public override void UpdateContent(ExampleItem item) {
			label.text = item.name;
		}
	}
}
