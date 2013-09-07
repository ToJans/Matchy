using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matchy
{
    public class Def:IMatcher
    {
        List<IMatcher> Matchers = new List<IMatcher>();

        public Matched<T> match<T>() 
        {
            var matcher = new Matched<T>(this);
            Matchers.Add(matcher);
            return matcher;
        }

        public Matched<T> match<T>(T value) 
        {
            var matcher = new Matched<T>(this,value);
            Matchers.Add(matcher);
            return matcher;
        }

        public Matched<T> match<T>(Predicate<T> what) 
        {
            throw new NotImplementedException();
        }

        public bool IsMatch(object value)
        {
            return Matchers.Any(x=>x.IsMatch(value));
        }

        public dynamic this[dynamic value]
        {
            get { return Matchers.First(x=>x.IsMatch(value))[value]; }
        }

        public class Matched<T>:Matchy.IMatcher 
        {
            public Def parent;
            private T value;
            private dynamic result;
            bool type_only = true;

            internal Matched(Def parent)
            {
                this.parent = parent;
            }

            internal Matched(Def parent, T valueToMatch):this(parent)
            {
                this.type_only = false;
                this.value = valueToMatch;
            }

            public Def with(T result)
            {
                this.result = result;
                return parent;
            }

            public Def with(Func<T, dynamic> what)
            {
                return parent;
            }

            public bool IsMatch(object value)
            {
                dynamic self = this;
                dynamic dvalue = value;
                return self.IsMatchInternal(dvalue);
            }

            bool IsMatchInternal(T value)
            {
                return type_only || (this.value==null && value == null) || (this.value!=null && this.value.Equals(value));
            }

            bool IsMatchInternal(object value)
            {
                return (this.value == null && value == null) || (this.value != null && this.value.Equals(value));
            }

            public dynamic this[dynamic value]
            {
                get { return result; }
            }

        }




    }
}
