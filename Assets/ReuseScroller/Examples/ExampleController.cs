using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReuseScroller
{
	public class ExampleController : BaseController<ExampleItem>
	{
		protected override void Start() {
			base.Start();
			var items = new List<ExampleItem>();
			for (int i=1; i<=20; i++) {
				items.Add(new ExampleItem { name=i.ToString("d") });
			}
			CellData = items;
		}

		//protected override float GetCellSize(int index) {
		//	return defaultCellSize;
		//}
	}
}
