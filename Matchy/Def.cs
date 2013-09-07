using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matchy
{
    public class Def:IMatch
    {

        public IMatched<T> match<T>()
        {
            return new Matched<T>(this);
        }

        public IMatched<T> match<T>(T what)
        {
            return new Matched<T>(this);
        }

        public IMatched<T> match<T>(Predicate<T> what)
        {
            throw new NotImplementedException();
        }

        public dynamic this[dynamic value]
        {
            get { return 0; }
        }

        class Matched<T>:IMatched<T>
        {
            public IMatch parent;

            public Matched(IMatch parent)
            {
                this.parent = parent;
            }

            public IMatch with(T what)
            {
                return parent;
            }

            public IMatch with(Func<T, dynamic> what)
            {
                return parent;
            }
        }


    }
}
