namespace Algorithms.Tests;

public class MergeSortTest
{
    /* [Test] */
    /* public void ShouldRecursivelySortArray() */
    /* { */
    /*     // Arrange */
    /*     var array = new int[] { 12, 11, 13, 5, 6, 7 }; */
    /*  */
    /*     // Act */
    /*     var result = Merge.RecursiveSort(array); */
    /*  */
    /*     // Assert */
    /*     Assert.That(result, Is.EqualTo(new int[] { 5, 6, 7, 11, 12, 13 })); */
    /* } */

	[Test]
	public void ShouldSortArray()
	{
		// Arrange
		var array = new int[] { 12, 11, 13, 5, 6, 7 };

		// Act
		var result = Merge.Sort(array);

		// Assert
		Assert.That(result, Is.EqualTo(new int[] { 5, 6, 7, 11, 12, 13 }));
	}
}
