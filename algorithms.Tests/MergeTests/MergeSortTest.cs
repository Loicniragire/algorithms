namespace Algorithms.Tests;

public class MergeSortTest
{
	[Test]
	public void ShouldSortArray()
	{
		// Arrange
		var array = new int[] { 12, 11, 13, 5, 6, 7 };

		// Act
		Merge.Sort(array);

		// Assert
		Assert.That(array, Is.EqualTo(new int[] { 5, 6, 7, 11, 12, 13 }));
	}
}
