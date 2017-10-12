using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.EntityContracts
{
    public interface IClone<TItem>
        where TItem: class, new()
    {
        TItem GetAClone();
        TItem GetACloneWithoutIdentifier();
    }
}

