

using FriendlyFoodFinder.Core.Specification;
using NUnit.Framework;

namespace FriendlyFoodFinder.Core.Test.Specifications
{
    [TestFixture]
    public class WhenValidatingLatitudeValues
    {
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(90)]
        [TestCase(-90)]
        public void CanApproveValidValue(double testLatitude)
        {
            Assert.That(new ValidLatitude().IsSatisfiedBy(testLatitude), Is.True);
        }
        
        [TestCase(100)]
        [TestCase(-100)]
        public void CanRejectInvalidValue(double testLatitude)
        {
            Assert.That(new ValidLatitude().IsSatisfiedBy(testLatitude), Is.False);

        }
    }
}