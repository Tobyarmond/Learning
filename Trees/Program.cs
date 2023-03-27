// See https://aka.ms/new-console-template for more information

using Trees;

BinaryTree tree = new BinaryTree(7,new BinaryTree(1), new BinaryTree(4));
BinaryTree a = new BinaryTree(2,new BinaryTree(8,new BinaryTree(1),new BinaryTree(6)),new BinaryTree(5));
// b split into a few lines to reduce complexity
BinaryTree b = new BinaryTree(5,new BinaryTree(9),new BinaryTree(6));
b.Right.Left = new BinaryTree(1,new BinaryTree(),new BinaryTree(2));
b.Right.Right = new BinaryTree(5,new BinaryTree(7),new BinaryTree());
//a.Show(a);
b.Show(b);