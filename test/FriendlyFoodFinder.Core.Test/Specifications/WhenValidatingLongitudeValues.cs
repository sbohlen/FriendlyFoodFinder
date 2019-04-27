using FriendlyFoodFinder.Core.Specification;
using NUnit.Framework;

namespace FriendlyFoodFinder.Core.Test.Specifications
{
    [TestFixture]
    public class WhenValidatingLongitudeValues
    {
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(180)]
        [TestCase(-180)]
        public void CanApproveValidValue(double testLongitude)
        {
            Assert.That(new ValidLongitude().IsSatisfiedBy(testLongitude), Is.True);
        }
        
        [TestCase(200)]
        [TestCase(-200)]
        public void CanRejectInvalidValue(double testLongitude)
        {
            Assert.That(new ValidLongitude().IsSatisfiedBy(testLongitude), Is.False);

        }
    }
}