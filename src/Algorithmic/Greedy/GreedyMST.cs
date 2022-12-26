using Algorithmic.DataStructures;

using System;

namespace Algorithmic;

public static partial class Greedy
{
    /// <summary>
    /// Minimum Spanning Tree
    /// </summary>
    /// <param name="graph"></param>
    /// <returns></returns>
    public static int KruskalMST(Graph graph)
    {
        // This will store the
        // resultant MST
        Edge<int>[] result = new Edge<int>[graph.VerticesNo];
        int e = 0; // An index variable, used for result[]
        int i
            = 0; // An index variable, used for sorted edges
        for (i = 0; i < graph.VerticesNo; ++i)
            result[i] = new Edge<int>();

        // Step 1: Sort all the edges in non-decreasing
        // order of their weight. If we are not allowed
        // to change the given graph, we can create
        // a copy of array of edges
        Array.Sort(graph.Edges);

        // Allocate memory for creating V subsets
        Subset[] subsets = new Subset[graph.VerticesNo];
        for (i = 0; i < graph.VerticesNo; ++i)
            subsets[i] = new Subset();

        // Create V subsets with single elements
        for (int v = 0; v < graph.VerticesNo; ++v)
        {
            subsets[v].Parent = v;
            subsets[v].Rank = 0;
        }

        i = 0; // Index used to pick next edge

        // Number of edges to be taken is equal to V-1
        while (e < graph.VerticesNo - 1)
        {
            // Step 2: Pick the smallest edge. And increment
            // the index for next iteration
            Edge<int> next_edge = new Edge<int>();
            next_edge = graph.Edges[i++];

            int x = Subset.Find(subsets, next_edge.Src);
            int y = Subset.Find(subsets, next_edge.Dest);


            // If including this edge doesn't cause cycle,
            // include it in result and increment the index
            // of result for next edge
            if (x != y)
            {
                result[e++] = next_edge;
                Subset.Union(subsets, x, y);
            }
            // Else discard the next_edge
        }

        // print the contents of result[] to display
        // the built MST
        Console.WriteLine("Following are the edges in "
                          + "the constructed MST");

        int minimumCost = 0;
        for (i = 0; i < e; ++i)
        {
            Console.WriteLine(result[i].Src + " -- "
                              + result[i].Dest
                              + " == " + result[i].Weight);
            minimumCost += result[i].Weight;
        }

        Console.WriteLine("Minimum Cost Spanning Tree: "
                          + minimumCost);
        Console.ReadLine();
        return minimumCost;
    }
}
