internal class RBTree<T1,T2> where T1:IComparable
{
    internal Node<T1,T2> Put(Node<T1,T2> node,T1 key,T2 value)
    {
        if (node == null) return new Node<T1, T2>(key, value, Color.Red);
        int comp = key.CompareTo(node.Key);
        if (comp < 0) node.Left = Put(node.Left, key, value);
        else if (comp > 0) node.Right = Put(node.Right, key, value);
        else if (comp == 0) node.Value = value;

        if (IsRed(node.Right) && !IsRed(node.Left)) node = RotateLeft(node);
        if (IsRed(node.Left) && IsRed(node.Left.Left)) node = RotateRight(node);
        if (IsRed(node.Left) && IsRed(node.Right)) FlipColors(node);

        return node;
    }

    internal void PrintInOrder(Node<string,string> root)
    {
        if (root == null)
            return;

        /* first recur on left child */
        PrintInOrder(root.Left);

        /* then print the data of node */
        Console.Write(root.Key + " Color:" + root.Color);

        /* now recur on right child */
        PrintInOrder(root.Right);
    }

    internal void PrintPreOrder(Node<string, string> root)
    {
        if (root == null)
            return;

        /* then print the data of node */
        Console.Write(root.Key + " Color:" + root.Color);

        /* first recur on left child */
        PrintPreOrder(root.Left);

        /* now recur on right child */
        PrintPreOrder(root.Right);
    }

    private bool IsRed(Node<T1, T2> node)
    {
        if (node == null) return false;
        return node.Color == Color.Red;
    }

    private Node<T1, T2> RotateLeft(Node<T1, T2> h)
    {
        Node<T1, T2> x = h.Right;
        h.Right = x.Left;
        x.Left = h;
        x.Color = h.Color;
        h.Color = Color.Red;
        return x;
    }
    private Node<T1, T2> RotateRight(Node<T1, T2> h)
    {
        Node<T1, T2> x = h.Left;
        h.Left = x.Right;
        x.Right = h;
        x.Color = h.Color;
        h.Color = Color.Red;
        return x;
    }
    private void FlipColors(Node<T1, T2> node)
    {
        node.Color = Color.Red;
        node.Left.Color = Color.Black;
        node.Right.Color = Color.Black;
    }
}
class Node<T1,T2>
{
    internal T1 Key { get; set; }
    internal T2 Value { get; set; }
    internal Node<T1,T2> Left, Right;
    internal Color Color;

    public Node(T1 key,T2 value,Color color)
    {
        this.Key = key;
        this.Value = value;
        this.Color = color;
    }
}

enum Color : byte
{
    Red,
    Black
}
