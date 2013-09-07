using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matchy
{
    public interface IMatched<T>
    {
        IMatch with(T what);
        IMatch with(Func<T, dynamic> what);
    }
}
