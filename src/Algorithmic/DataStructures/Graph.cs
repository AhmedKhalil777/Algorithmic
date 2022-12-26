namespace Algorithmic.DataStructures;



public class Graph : Graph<int> {
    public Graph(int v, int e) : base(v, e) 
    {

    }
}

public class Graph<T>
{
    public int VerticesNo { get; }
    public int EdgesNo { get; }

    public Edge<T>[]? Edges { private set; get; }

    public Graph(int v, int e)
    {
        VerticesNo = v;
        EdgesNo = e;
        Edges = new Edge<T>[e];
        for (int i = 0; i < e; ++i)
            Edges[i] = new Edge<T>();
    }

    int Find(Subset[] subsets, int i)
    {
        // find root and make root as
        // parent of i (path compression)
        if (subsets[i].parent != i)
            subsets[i].parent
                = Find(subsets, subsets[i].parent);

        return subsets[i].parent;
    }

}
