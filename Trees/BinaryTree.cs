namespace Trees;

// Workshop for Algorithms and complexity week 7
public class BinaryTree
{
    public int ?Value;
    public BinaryTree? Left;
    public BinaryTree? Right;

    public BinaryTree()
    {
    }
    
    public BinaryTree(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }

    public BinaryTree(int value, BinaryTree left, BinaryTree right)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public void Show(BinaryTree t)
    {
        if (t.Left != null)
        {
            Show(t.Left);
        }
        Console.Write(t.Value);
        if (t.Right != null)
        {
            Show(t.Right);
        }
    }
    
    // could have a left and right int 
    public int Height(BinaryTree tree)
    {
        int Calculate(BinaryTree t)
        {
            if (t.Left != null)
            {
                int leftDepth = Height(t.Left);
            }
            else if (t.Right != null)
            {
                int rightDepth = Height(t.Right);
            }
            else
            {
                return -1;
            }  
        }
        
    }
}