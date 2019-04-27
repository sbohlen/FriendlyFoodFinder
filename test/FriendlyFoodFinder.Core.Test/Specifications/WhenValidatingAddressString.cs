using FriendlyFoodFinder.Core.Specification;
using NUnit.Framework;

namespace FriendlyFoodFinder.Core.Test.Specifications
{
    [TestFixture]
    public class WhenValidatingAddressString
    {
        [Test]
        public void CanApproveValidValue()
        {
            Assert.That(new ValidAddressString().IsSatisfiedBy("I am a non-null string"), Is.True);
        }
        
        [Test]
        public void CanRejectNullValue()
        {
            Assert.That(new ValidAddressString().IsSatisfiedBy(null), Is.False);
        }

        [Test]
        public void CanRejectWhitespaceStringValue()
        {
            Assert.That(new ValidAddressString().IsSatisfiedBy("     "), Is.False);
        }

        [Test]
        public void CanRejectEmptyStringValue()
        {
            Assert.That(new ValidAddressString().IsSatisfiedBy(string.Empty), Is.False);
        }
    }
}