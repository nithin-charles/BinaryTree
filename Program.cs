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

//var values = BreadthFirstSearch(treeNode);

//var iterativePreOrder = IterativePreOrder(treeNode);
// var iterativeInOrder = IterativeInOrder(treeNode);

var iterativePostOrder = IterativePostOrder(treeNode);
foreach (var node in iterativePostOrder)
{
    Console.Write($"{node} -> ");
}
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

#region DFS- Iterative Methods

static List<int> IterativePreOrder(TreeNode root)
{
    if (root == null) return new List<int>();
    Stack<TreeNode> stack = new Stack<TreeNode>();
    List<int> list = new List<int>();
    stack.Push(root);
    while (stack.Count > 0)
    {
        var node = stack.Pop();
        Console.Write($"{node.Value} -> ");
        list.Add(node.Value);
        if (node.Right != null)
        {
            stack.Push(node.Right);
        }

        if (node.Left != null)
        {
            stack.Push(node.Left);
        }
        
    }
    return list;
}

static List<int> IterativeInOrder(TreeNode root)
{
    if (root == null) return new List<int>();
    Stack<TreeNode> stack = new Stack<TreeNode>();
    List<int> list = new List<int>();
    var node = root;
    while (true) // run it infinitely
    {
        if (node != null)
        {
            stack.Push(node);
            node = node.Left;
        }
        else
        {
            if (stack.Count == 0)
            {
                break;
            }
            node = stack.Pop();
            list.Add(node.Value);
            node = node.Right;
        }
    }
    return list;
}

/// <summary>
/// Post Order using 2 stack
/// </summary>

static List<int> IterativePostOrder(TreeNode root)
{
    if (root == null) return new List<int>();
    Stack<TreeNode> stack1 = new Stack<TreeNode>();
    Stack<int> stack2 = new Stack<int>();
    List<int> list = new List<int>();
    stack1.Push(root);

    while (stack1.Count > 0)
    {
        var node = stack1.Pop();
        if (node.Left != null)
        {
            stack1.Push(node.Left);
        }

        if (node.Right != null)
        {
            stack1.Push(node.Right);
        }
        stack2.Push(node.Value);
    }
    return stack2.ToList();


}
#endregion