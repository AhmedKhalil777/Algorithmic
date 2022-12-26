using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithmic.DataStructures;



public class Subset
{
    public int Parent { get; set; }
    public int Rank { get; set; }

    public static int Find(Subset[] subsets, int i)
    {
        // find root and make root as
        // parent of i (path compression)
        if (subsets[i].Parent != i)
            subsets[i].Parent
                = Find(subsets, subsets[i].Parent);


        return subsets[i].Parent;
    }

}

