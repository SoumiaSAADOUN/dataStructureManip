class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node(int val)
    {
        this.val = val;

    }

    public Node SearchValInBinarySearchTree(Node root, int val)
    {
        if (root == null || root.val == val)
            return root;
        else if (root.val > val)
            return SearchValInBinarySearchTree(root.left, val);
        else
            return SearchValInBinarySearchTree(root.right, val);


    }

    public Node InsertIntoBinarySearchTree(Node root, int val)
    {
        if (root == null)
        {
            return new Node(val);
        }
        if (root.val > val)
            root.left = InsertIntoBinarySearchTree(root.left, val);

        else
            root.right = InsertIntoBinarySearchTree(root.right, val);
        return root;
    }

    public Node DeleteValFromBinarySearchTree(Node root, int val)
    {
        if (root == null)
        {
            return root;
        }

        if (root.val > val)
            root.right = DeleteValFromBinarySearchTree(root.right, val);
        else if (root.val < val)
            root.left = DeleteValFromBinarySearchTree(root.left, val);
        else
        {
            // case that the node has only right child
            if (root.left == null)
            {
                root = root.right;
                return root;
            }
            // case that the node has only left child
            if (root.right == null)
            {
                root = root.left;
                return root;
            }

            // case that the node has 2 children, we replace it with the biggest val of its left child
            Node maxValue = GetMaxValueInBinarySearchTree(root.left);
            root.val = maxValue.val;

            root.left = DeleteValFromBinarySearchTree(root.left, maxValue.val);

        }

        return root;
    }

    public Node GetMaxValueInBinarySearchTree(Node root)
    {
        Node current = root;

        while (current != null && current.right != null)
        {
            current = current.right;
        }
        return current;
    }

    public void BinaryTreeSearchInorderTraversal(Node root)
    {
        if (root != null)
        {
            BinaryTreeSearchInorderTraversal(root.left);
            Console.WriteLine(root.val);
            BinaryTreeSearchInorderTraversal(root.right);
        }

    }

    public void BinaryTreeSearchPostorderTraversal(Node root)
    {
        if (root != null)
        {
            BinaryTreeSearchPostorderTraversal(root.left);
            BinaryTreeSearchPostorderTraversal(root.right);
            Console.WriteLine(root.val);


        }
    }

        public void BinaryTreeSearchPretorderTraversal(Node root){
            if(root!=null){
                Console.WriteLine(root.val);
                BinaryTreeSearchPretorderTraversal(root.left);
                BinaryTreeSearchPretorderTraversal(root.right);

            }
        }


}