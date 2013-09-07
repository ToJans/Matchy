using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matchy
{
    public interface IMatch
    {
        IMatched<T> match<T>();
        IMatched<T> match<T>(T what);
        IMatched<T> match<T>(Predicate<T> what);
        dynamic this[dynamic value] { get; }
    }
}
