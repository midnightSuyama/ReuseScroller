using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace ReuseScroller
{
	[TestFixture]
	public class HorizontalReverseTest
	{
		private GameObject canvas;
		private GameObject scrollView;

		[OneTimeSetUp]
		public void InitAll() {
			canvas = TestHelper.CreateCanvas();
		}

		[SetUp]
		public void Init() {
			scrollView = TestHelper.CreateScrollView(Direction.Horizontal, true);
			scrollView.transform.SetParent(canvas.transform, false);
		}

		[TearDown]
		public void Cleanup() {
			GameObject.Destroy(scrollView);
			scrollView = null;
		}

		[OneTimeTearDown]
		public void CleanupAll() {
			GameObject.Destroy(canvas);
			canvas = null;
		}

		[Test]
		public void ContentAnchor() {
			var rt = scrollView.GetComponent<ScrollRect>().content.GetComponent<RectTransform>();
			Assert.That(rt.anchorMin, Is.EqualTo(Vector2.right));
			Assert.That(rt.anchorMax, Is.EqualTo(Vector2.one));
		}

		[Test]
		public void CellAnchor() {
			var cells = TestHelper.GetCells(scrollView.GetComponent<TestController>());
			var rt = cells.First.Value.GetComponent<RectTransform>();
			Assert.That(rt.anchorMin, Is.EqualTo(Vector2.right));
			Assert.That(rt.anchorMax, Is.EqualTo(Vector2.one));
		}

		[Test]
		public void CellOffset() {
			var cells = TestHelper.GetCells(scrollView.GetComponent<TestController>());
			var rt = cells.First.Value.GetComponent<RectTransform>();
			Assert.That(rt.offsetMin, Is.EqualTo(new Vector2(-102.0f, 4.0f)));
			Assert.That(rt.offsetMax, Is.EqualTo(new Vector2(-2.0f, -3.0f)));
			rt = cells.First.Next.Value.GetComponent<RectTransform>();
			Assert.That(rt.offsetMin, Is.EqualTo(new Vector2(-322.0f, 4.0f)));
			Assert.That(rt.offsetMax, Is.EqualTo(new Vector2(-122.0f, -3.0f)));
		}

		[Test]
		public void CellSize() {
			var cells = TestHelper.GetCells(scrollView.GetComponent<TestController>());
			Assert.That(cells.First.Value.Width, Is.EqualTo(100.0f));
			Assert.That(cells.First.Next.Value.Width, Is.EqualTo(200.0f));
		}

		[Test]
		public void CellContent() {
			var cellObjects = scrollView.GetComponent<ScrollRect>().content.GetComponentsInChildren<TestCell>();
			Assert.That(cellObjects[0].label.text, Is.EqualTo("1"));
			Assert.That(cellObjects[1].label.text, Is.EqualTo("2"));
		}

		[Test]
		public void FillCells() {
			var cellObjects = scrollView.GetComponent<ScrollRect>().content.GetComponentsInChildren<TestCell>();
			Assert.That(cellObjects.Length, Is.EqualTo(7));
		}

		[UnityTest]
		public IEnumerator ReuseCells() {
			var scrollRect = scrollView.GetComponent<ScrollRect>();
			for (int i=0; i<=20; i++) {
				scrollRect.horizontalNormalizedPosition = (i<=10 ? 10-i : i-10) * 0.1f;
				yield return new WaitForFixedUpdate();
				var cellObjects = scrollRect.content.GetComponentsInChildren<TestCell>();
				Assert.That(cellObjects.Length, Is.LessThanOrEqualTo(8));
			}
			yield return null;
		}
	}
}
