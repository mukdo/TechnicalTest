using System;
using System.Collections.Generic;
using System.Text;

namespace TT.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
