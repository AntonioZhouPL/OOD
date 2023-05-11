using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    public interface Iterator
    {
        void Next();
        bool IsDone { get; }
        double GetValue { get; }
    }
    public interface IAgregate
    {
        Iterator GetIterator();
    }
}
