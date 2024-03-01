namespace Algorithms.Tests
{
    public class MaxSubArrayTests
    {
        [Test]
        public void ShouldReturnAnArrayWhoseSumIsTheMaximum()
        {
            // Arrange
            var input = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

			// expected starting index, ending ingex, and sum as a tupple
			var expected = (3, 6, 6);

            // Act
            var result = SubArray.FindMaximumSubarray(input, 0, input.Length - 1);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

