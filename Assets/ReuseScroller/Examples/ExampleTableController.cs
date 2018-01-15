using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReuseScroller
{
	public class ExampleTableController : BaseController<ExampleItem>
	{
		public ExampleTable table;

		protected override void Start() {
			base.Start();
			CellData = table.items;
		}
	}
}
