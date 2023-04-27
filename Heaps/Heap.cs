using System;
using System.Collections.Generic;

namespace Blackboard
{
    /*
     * This class used to represent a min-heap data structure.
     * The min-heap property is that the value of any parent node must be less
     * than the values of its children. Hence, the root will always store the lowest value
     * which represents the highest priority item.
     */
    public class MinHeap
    {

        private int[] heap;  // we use an array to store the heap's values
        private int size;  // for keeping track of how many items are in the heap
        private int capacity;  // the total number of items allowed

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            size = 0;
            heap = new int[capacity + 1];
            heap[0] = Int32.MinValue; // this is a trick to make indexing from 1 work!
        }

        /* This is a handy way of creating a heap from any
         * existing array of values. In this way, we need
         * not insert items one at a time (this is more efficient).
         * This won't work until you've implemented MinHeapify!
         */
        public MinHeap(int[] values)
        {
            this.capacity = values.Length;
            size = capacity;
            heap = new int[capacity + 1];
            heap[0] = Int32.MinValue;
            Array.Copy(values, 0, heap, 1, values.Length);
            MinHeapify();
        }

        /*
        * This displays the contents of the heap. DO NOT EDIT.
        */
        public void Display()
        {
            Console.WriteLine("[{0}]", string.Join(", ", heap[1..(size + 1)]));
        }

        /*
        * If the node at heap[i] is the root, this will return true. Otherwise, false.
        */
        public bool IsRoot(int i)
        {
            throw new NotImplementedException("IsRoot not implemented!");
        }

        /*
        * This will return the index of the parent node at position heap[i].
        */
        public int Parent(int i)
        {
            throw new NotImplementedException("Parent not implemented!");
        }

        /*
        * This will return the index of the left child of the node at position heap[i].
        */
        public int Left(int i)
        {
            throw new NotImplementedException("Left not implemented!");
        }

        /*
        * This will return the index of the right child of the node at position heap[i].
        */
        public int Right(int i)
        {
            throw new NotImplementedException("Right not implemented!");

        }

        /*
        * This will swap the values at positions i and j using a temporary variable.
        */
        public void Swap(int i, int j)
        {
            throw new NotImplementedException("Swap not implemented!");

        }

        /* This procedure will swap node i with its parent,
         * if it currently violates the min-heap property.
         * The process is recursive. DO NOT EDIT.
         */
        public void BubbleUp(int i)
        {
            if (IsRoot(i)) // we've hit the top of the tree
            {
                return;
            }
            else if (heap[i] < heap[Parent(i)]) // we can swap this node with its parent
            {
                Swap(i, Parent(i));
                BubbleUp(Parent(i));
            }
        }

        /* This procedure will swap node i with its left or right child,
         * depending on which of the two is smaller.
         * The process is recursive. DO NOT EDIT.
         */
        public void BubbleDown(int i)
        {
            if (Left(i) > size) // we're already at a leaf node
            {
                return;
            }
            else if (heap[i] > heap[Left(i)] || heap[i] > heap[Right(i)])
            {
                if (heap[Left(i)] < heap[Right(i)])
                {
                    Swap(i, Left(i));
                    BubbleDown(Left(i));
                }
                else
                {
                    Swap(i, Right(i));
                    BubbleDown(Right(i));
                }
            }
        }

        /* This method will initially insert a value
         * into the next empty heap slot, and then move it up as
         * needed in order to maintain the min-heap property.
         */
        public void Insert(int value)
        {
            // 1. Put the value at next available location in the heap (print error if there's no space)
            //   (eensure that the heap size is increased by one in doing so...)
            // 2. Bubble up from the location you just inserted into.
            throw new NotImplementedException("Insert not implemented!");

        }

        /* This method will first swap the root with the last
         * element in the heap, and then bubble it back down.
         * The original root value is returned.
         */
        public int RemoveMin()
        {
            // 1. Extract the minimum value from the heap (the root)
            // 2. Set the root node's value to that of the rightmost node in the heap.
            //    (ensure that the heap size is decreased by one in doing so...)
            // 3. Bubble down from the root node.
            // 4. Return the minimum.
            throw new NotImplementedException("RemoveMin not implemented!");
        }

        /* This method performs the min-heapify
         * operation in order to re-order a given
         * array to be a min-heap. 
         */
        public void MinHeapify()
        {
            throw new NotImplementedException("MinHeapify not implemented!");
        }

        public static void Main(string[] args)
        {

            // 1. Implement IsRoot/Parent/Left/Right/Swap.
            // Use the code below to check that your implementation works!
            MinHeap heap = new MinHeap(9);
            Console.WriteLine(heap.IsRoot(1)); // should print true
            Console.WriteLine(heap.Parent(4)); // should print 2
            Console.WriteLine(heap.Left(4)); // should print 8
            Console.WriteLine(heap.Right(4));// should print 9

            heap.heap[1] = 10; heap.heap[2] = 7; heap.heap[3] = 12;
            heap.Swap(1, heap.Right(1)); // swaps 10 and 12
            Console.WriteLine(heap.heap[1]); // should print 12

            // 2. Implement Insert.
            // The code below will generate random numbers and insert them into a heap one-by-one.
            // Verify the max-heap property is satisfied!
            int maxSize = 9;
            heap = new MinHeap(maxSize);
            Random rand = new Random();
            int[] values = new int[maxSize];

            Console.WriteLine("--- Insert ---");
            for (int i = 0; i < maxSize; i++)
            {
                values[i] = rand.Next(1, 100); // random number between 1-100
                heap.Insert(values[i]); // insert into heap
                heap.Display(); // display the heap array
            }

            // 3. Observe how the highest priority elements are removed one-by-one.
            // Is the min-heap property always satisfied?
            Console.WriteLine("--- Remove ---");
            while (heap.size > 0)
            {
                heap.RemoveMin();
                heap.Display();
            }

            // 4. Use MinHeapify to recreate the original min-heap
            Console.WriteLine("--- Min-heapify ---");
            heap = new MinHeap(values);
            heap.Display();
        }

    }

}