using System;
using System.Collections.Generic;

namespace Blackboard
{
    // This class implements the adjacency matrix representation of a weighted graph
    // Graphs by directed or undirected by means of a boolean flag
    public class AdjacencyMatrix
    {
        private bool digraph;  // indicates whether the graph is directed or not
        private int numNodes;  // number of nodes in graph
        private int[,] weights; // 2D array of edges

        // creates an AdjacencyMatrix object with a given number of nodes
        public AdjacencyMatrix(int numNodes, bool digraph=false)
        {
            this.numNodes = numNodes;
            this.digraph = digraph;
            weights = new int[numNodes, numNodes];
            InitialiseWeights();
        }

        public int Order()
        {
            return numNodes;
        }

        // This is an handy way of manipulating the
        // matrix easily using the object itself
        // DO NOT EDIT THIS.
        public int this[int i, int j]
        {
            get => weights[i, j];
            set => AddEdge(i, j, value);
        }

        // This method sets all weights in the graph
        // to +Infinity, except the leading diagonal
        // which will always be zero
        private void InitialiseWeights()
        {
            for (int i = 0; i < numNodes; i++)
            {
                for (int j = 0; j < numNodes; j++)
                {
                    if (i != j)
                    {
                        weights[i, j] = int.MaxValue;
                        weights[j, i] = int.MaxValue;
                    }
                }
            }

        }

        // TASk 1.1: Add an edge between nodes i and j with weight w,
        // preventing self-loops (print an error message in this case).
        // NOTE: You'll need to take into account whether the graph
        // is directed or not when inserting edges...
        // TODO needs implementing
        // must remember that the table is ABC.. one direction and the same the other direction so 1 value can give 2 coords
        public void AddEdge(int i, int j, double w)
        {
            if (i != j)
            {
                int v = Convert.ToInt32(w);
                weights[i,j] = v;
                if (!digraph)
                {
                    weights[j,i] = v;
                }
            }
        }

        // TASK 1.2: Remove an edge between nodes i and j with weight w,
        // preventing self-loops (print an error message in this case).
        // NOTE: You'll need to take into account whether the graph
        // is directed or not when removing edges...
        // TODO needs implementing
        public void DeleteEdge(int i, int j)
        {
            weights[i,j] = 0;
            if (!digraph)
            {
                weights[j, i] = 0;
            }
        }

        // TASK 4 (STRETCH): Add a node to the adjacency matrix by expanding the array
        // This achieved by making a new array, and copying the contents over
        // Don't forget to update numNodes...
        public void AddNode()
        {
            // Add your code here!
            throw new NotImplementedException("Add node not implemented!");
        }

        // Removes a node from the adjacency matrix by shrinking the array
        // This is achieved by copying the contents (except toRemove) into a new array
        // DO NOT EDIT THIS.
        public void RemoveNode(int toRemove)
        {
            numNodes--;  // reduce the node count
            int[,] newMatrix = new int[numNodes, numNodes];  // create new matrix

            // loop over all rows of old matrix
            // create another row index, m, for the new matrix
            for (int i = 0, m = 0; i < weights.GetLength(0); i++)
            {
                if (i == toRemove) continue; // skip over the row we're removing

                // loop over all columns of old matrix
                // create another column index, n, for the new matrix
                for (int j = 0, n = 0; j < weights.GetLength(1); j++)
                {
                    if (j == toRemove) continue; // skip over the column we're removing
                    newMatrix[m, n] = weights[i, j];  // copy the value over
                    n++; // increment new column index
                }
                m++; // increment new row index
            }
            
            weights = newMatrix;
        }

        // Returns a list of node that are neighbours of node i
        // This excludes itself, and nodes with infinite distance
        // DO NOT EDIT THIS.
        public List<int> GetNeighbours(int i)
        {
            List<int> neighbours = new List<int>();
            for (int j = 0; j < numNodes; j++)
            {
                if (weights[i, j] > 0 && weights[i, j] < int.MaxValue)
                {
                    neighbours.Add(j);
                }
            }
            return neighbours;
        }

        // This prints the contents of the weight matrix
        // DO NOT EDIT THIS.
        public void Display()
        {
            for (int i = 0; i < numNodes; i++)
            {
                for (int j = 0; j < numNodes; j++)
                {   
                    if (weights[i, j] == int.MaxValue)
                    {
                        Console.Write("x ");
                    } else
                    {
                        Console.Write("{0} ", weights[i, j]);
                    }
                }
                Console.Write("\n");
            }
        }

    }

    // This class implements several graph traversal methods.
    // It is a wrapper around the adjacency matrix
    public class Graph
    {
        // private attributes
        private string[] labels;
        private AdjacencyMatrix matrix;

        // creates a graph object, initialising an adjacency matrix
        // and an array of labels for the nodes in the graph 
        public Graph(string[] names)
        {
            this.labels = names;
            matrix = new AdjacencyMatrix(names.Length);
        }

        public AdjacencyMatrix GetMatrix()
        {
            return matrix;
        }

        public void SetMatrix(AdjacencyMatrix matrix)
        {
            this.matrix = matrix;
        }

        public int GetNodeByLabel(string label)
        {
            return Array.IndexOf(labels, label);
        }

        public string GetLabelByNode(int index)
        {
            return labels[index];
        }

        // TASK 2: Perform breadth first traversal, printing
        // the names of nodes it visits in order along the way
        public void BFT(int root)
        {
            Queue<Int32> queue = new Queue<int>();
            bool[] visited = new bool[matrix.Order()];
            queue.Enqueue(root);
            while (visited.Any() == false)
            {
                // how do I not visit stuff again.
                
                int currentNode = queue.Dequeue();
                visited[currentNode] = true;
                Console.WriteLine(currentNode);
                // look along row for connected nodes
                for (int i = 0; i < matrix.Order(); i++)
                {
                    if (matrix[currentNode, i] > 0)
                    {
                        queue.Enqueue(i);
                    }
                }
            }
            
            // create "visited" array here of correct size (you can use Order() to get this)
            // create a queue of type to store neighbouring nodes
            // enqueue the root onto the queue

            // using a while-loop, iterate until the queue is empty
            // within the loop, do the following
            // - dequeue node n
            // - if it hasn't been visited already,
            //   mark it visited in the array and then
            //   print its label (labels[n])
            //   Then, push all of its neighbours onto the queue
            //   (you can use GetNeighbours(n) for this).
            throw new NotImplementedException("BFT not implemented yet!");
        }

        // TASK 3: Perform depth first traversal, printing
        // the nodes it visits in order along the way
        public void DFT(int root)
        {
            // follow the same exact routine as for BFT
            // the only difference is that DFT uses a Stack
            // the methods will therefore be .Push() and .Pop()
            throw new NotImplementedException("DFT not implemented yet!");
        }

        // This code will not work until various methods are implemented above!
        public static void Main()
        {
            // A list of buildings that are labels for the graph nodes
            string[] names = { "Isaac Newton", "Minerva", "Alfred Tennyson",
                               "Stephen Langton", "Janet Lane-Claypon",
                               "Nicola de la Haye", "Peter de Wint",
                               "Sara Swift", "David Chiddick" };

            int noPlaces = names.Length;
            Graph uol = new Graph(names);
            Random rand = new Random();

            for (int i = 0; i < noPlaces; i++)
            {
                for (int j = i; j < noPlaces; j++)
                {
                    // adds edges between buildings with an "l" in the name
                    if (names[i].ToLower().Contains("l") || names[j].ToLower().Contains("l"))
                    {
                        uol.matrix.AddEdge(i, j, rand.Next(1, 9)); // random edge weight from 1 - 9
                    }
                }
            }

            // Print the list of place names and adjacency matrix
            Console.WriteLine("[{0}]", string.Join(", ", names));
            uol.matrix.Display();

            Console.WriteLine("Breadth-first traversal");
            uol.BFT(0);

            Console.WriteLine("Depth-first traversal");
            uol.DFT(0);

        }
    }
}
