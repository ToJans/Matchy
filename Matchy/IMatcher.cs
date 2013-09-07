using System;
namespace Matchy
{
    public interface IMatcher
    {
        bool IsMatch(object value);
        dynamic this[dynamic value] { get; }
    }
}
