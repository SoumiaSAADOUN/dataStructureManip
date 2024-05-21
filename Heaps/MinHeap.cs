/* Heaps are a sort data structure that stores data in a sorted way;
for Min heaps, the data stored in each level, starting from the tpo, is smaller that the data of the next level 
Heaps can be represented using arrays, the left child is stored in the 2i+1 index and the right child in the 2i+2
the main functions applied to heaps are: 
   - Peek: to read the top value (min or max depending on the minHeapValues's type) of complexity O(1),
   - InsertToHeap: Insert a value to minHeapValues in its proper spot O(logn)
   - DeleteFromHeap: Pop the top value from a minHeapValues while preseving the minHeapValues property O(logn)
   - Heapify: to maintain the minHeapValues property O(nlogn)
*/

public class MinHeap
{
    public int[] minHeapValues;
    public int size;
    public int capacity;
    public MinHeap(int capacity = 10)
    {
        this.minHeapValues = new int[capacity]();
        this.capacity = capacity;
        this.size = 0;
    }

    int getLeftChildIndex(int idx) { return 2 * idx + 1; }
    int getRightChildIndex(int idx) { return 2 * idx + 2; }
    int getParentIndex(int idx) { return idx / 2; }


    int getLeftChildValue(int idx) { return minHeapValues[2 * idx + 1]; }
    int getRightChildValue(int idx) { return minHeapValues[2 * idx + 2]; }
    int getParentValue(int idx) { return minHeapValues[idx / 2]; }

    /* Helper function to swap two elements in an array*/
    void swap(int firstIdx, int secondIdx)
    {
        int temp = minHeapValues[secondIdx];
        minHeapValues[secondIdx] = minHeapValues[firstIdx],
        minHeapValues[firstIdx] = temp;
    }

    void EnsureCapacity()
    {
        if (size == capacity)
        {
            capacity = capacity * 2;
            int[] newArray = int[capacity]();
            minHeapValues = Array.copy(minHeapValues, newArray, capacity);
            return newArray;
        }
    }

    int Peek()
    {
        if (size == 0) throw new EmptyHeapException();
        return minHeapValues[0];

    }

    /* 
        To insert an element to a min minHeapValues, we first insert it at the firt empty spot,
        then we bubble it up until we find its right sport, we compare its value with the parent's value
        if its smaller, we swap them.
    */
    void InsertValueToMinHeap(int value)
    {
        EnsureCapacity();
        minHeapValues[size] = value;
        size++;
        HeapifyUpMinHeap();
    }

    /*
        To extract the min from a Min heap, we pop the root (min value),
        we replace its value by the latest one of the heap and remove the last item,
        the we call te heapifyDown function to retore the heap property and put all items in thei proper locations
    */
    int ExtractMin(int value)
    {
        if (size == 0) throw new EmptyHeapException();
        int result = Peek(minHeapValues);
        minHeapValues[0] = minHeapValues[size - 1];
        size--;
        HeapifyDownMinHeap();
        return result;
    }
    void HeapifyDownMinHeap()
    {
        if (size == 0) throw new EmptyHeapException();
        int idx = 0;
        while (minHeapValues[idx] > minHeapValues[2 * idx + 1] || minHeapValues[idx] > minHeapValues[2 * idx + 2])
        {
            if (minHeapValues[2 * idx + 1] < minHeapValues[2 * idx + 2]) swap(minHeapValues, idx, 2 * idx + 1);
            else swap(minHeapValues, idx, 2 * idx + 2);
        }

    }

    void HeapifyUpMinHeap()
    {
        if (size == 0) throw new EmptyHeapException();
        int idx = size - 1;
        while (minHeapValues[idx] < getParentValue(minHeapValues, idx) && idx > 0)
        {
            swap(minHeapValues, idx, getParentIndex(idx));
            idx = getParentIndex(idx);
        }

    }



}


puclic class EmptyHeapException : Exception
{
    public EmptyHeapException() : base("Heap it empty!")
    {

    }
}