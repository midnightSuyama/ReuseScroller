using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReuseScroller
{
	public class TestController : BaseController<TestItem>
	{
		protected override void Start() {
			base.Start();
			var items = new List<TestItem>();
			for (int i=1; i<=20; i++) {
				items.Add(new TestItem { name=i.ToString("d") });
			}
			CellData = items;
		}

		protected override float GetCellSize(int index) {
			return index == 0 ? 100.0f : defaultCellSize;
		}
	}
}
