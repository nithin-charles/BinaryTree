using BinaryTree;

var treeNode = new TreeNode(1)
{
    Left = new TreeNode(2),
    Right = new TreeNode(3)
};
treeNode.Left.Left = new TreeNode(4);
treeNode.Left.Right = new TreeNode(5);
treeNode.Right.Left = new TreeNode(6);
treeNode.Right.Right = new TreeNode(7);
Console.ForegroundColor=ConsoleColor.Cyan;

// Console.WriteLine("Pre-Order Traversal");
// PreOrder(treeNode);
// Console.WriteLine("\n");
//
// Console.WriteLine("Post-Order Traversal");
// PostOrder(treeNode);
// Console.WriteLine("\n");
//
// Console.WriteLine("In-Order Traversal");
// InOrder(treeNode);
// Console.WriteLine("\n");

var values = BreadthFirstSearch(treeNode);

#region DFS - Recursive

static void PreOrder(TreeNode root)
{
    if (root == null) return;
    Console.Write($"{root.Value} -> ");
    PreOrder(root.Left);
    PreOrder(root.Right);
}

static void PostOrder(TreeNode root)
{
    if (root == null) return;
    PostOrder(root.Left);
    PostOrder(root.Right);
    Console.Write($"{root.Value} -> ");
}

static void InOrder(TreeNode root)
{
    if (root == null) return;
    InOrder(root.Left);
    Console.Write($"{root.Value} -> ");
    InOrder(root.Right);
}
#endregion

#region Breadth First Search
static List<int> BreadthFirstSearch(TreeNode root)
{
    if (root == null)
    {
        return new List<int>()
        {
            0
        };
    };
    Queue<TreeNode> q = new Queue<TreeNode>();
    List<int> list = new List<int>();
    q.Enqueue(root);
    while (q.Count > 0)
    {
        var node = q.Dequeue();
        Console.Write($"{node.Value} -> ");
        list.Add(node.Value);
        if (node.Left != null)
        {
            q.Enqueue(node.Left);
        }

        if (node.Right != null)
        {
            q.Enqueue(node.Right);
        }
    }
    return list;
}
#endregion