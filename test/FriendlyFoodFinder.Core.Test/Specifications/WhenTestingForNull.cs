

using FriendlyFoodFinder.Core.Specification;
using NUnit.Framework;

namespace FriendlyFoodFinder.Core.Test.Specifications
{
    [TestFixture]
    public class WhenTestingForNull
    {
        [Test]
        public void CanApproveValidValue()
        {
            Assert.That(new NotNull().IsSatisfiedBy(new object()));
        }
        
        [Test]
        public void CanRejectInvalidValue()
        {
            Assert.That(new NotNull().IsSatisfiedBy(null), Is.False);

        }
    }
}