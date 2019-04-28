using System;
using System.IO;
using System.Linq.Expressions;
using Proteus.Domain.Foundation.Specifications;

namespace FriendlyFoodFinder.Core.Specification
{
    public class CanAccessFile : Specification<string>
    {
        public override Expression<Func<string, bool>> Predicate
        {
            get { return filepath => File.Exists(filepath); }
        }
    }
}