using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithmic.DataStructures;

public class Edge : Edge<int> { }

public class Edge<T> : IComparable<Edge<T>>
{
    public T? Src { get; set; }
    public T? Dest { get; set; }
    public int Weight { get; set; }

    public int CompareTo(Edge<T> other)
    {
        return this.Weight - other.Weight;

    }
}