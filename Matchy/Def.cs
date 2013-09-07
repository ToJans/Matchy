using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matchy
{
    public class Def : IMatcher
    {
        List<IMatcher> Matchers = new List<IMatcher>();

        public Matched<T> Match<T>()
        {
            var matcher = new Matched<T>(this);
            Matchers.Add(matcher);
            return matcher;
        }

        public Matched<T> Match<T>(T value)
        {
            var matcher = new Matched<T>(this, value);
            Matchers.Add(matcher);
            return matcher;
        }

        public Matched<T> Match<T>(Predicate<T> what)
        {
            var matcher = new Matched<T>(this, what);
            Matchers.Add(matcher);
            return matcher;
        }

        public bool IsMatch(object value)
        {
            return Matchers.Any(x => x.IsMatch(value));
        }

        public dynamic this[dynamic value]
        {
            get { return Matchers.First(x => x.IsMatch(value))[value]; }
        }

        public class Matched<T> : Matchy.IMatcher
        {
            public Def parent;
            private Predicate<T> matchValue;
            private Func<T, dynamic> getResult;

            internal Matched(Def parent)
            {
                this.parent = parent;
                this.matchValue = x => true;
            }

            internal Matched(Def parent, T valueToMatch)
                : this(parent)
            {
                this.matchValue = x => (x == null && valueToMatch == null) || (valueToMatch != null && valueToMatch.Equals(x));
            }

            public Matched(Def def, Predicate<T> matchValue)
                : this(def)
            {
                this.matchValue = matchValue;
            }

            public Def With(T result)
            {
                this.getResult = (x) => result;
                return parent;
            }

            public Def With(Func<T, dynamic> what)
            {
                this.getResult = what;
                return parent;
            }

            public bool IsMatch(object value)
            {
                return (value == null && matchValue((T)value))
                    || (value != null && typeof(T).IsAssignableFrom(value.GetType()) && matchValue((T)value));
            }

            public dynamic this[dynamic value]
            {
                get { return getResult(value); }
            }

        }




    }
}
