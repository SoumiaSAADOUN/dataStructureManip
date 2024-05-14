class QuickSort
{
    static void swap(int[] arr, int i, int j)
    {
        if (i < 0 || j < 0 || arr.Length <= i || arr.Length <= j)
            throw new ArgumentOutOfRangeException("Index out of range!")
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static int partition(int[] arr, int start, int end)
    {
        // init the pivot -last elem of the given array-
        int pivot = arr[end];
        //inti the index of the smallest elem
        int i = start - 1;
        // loop over the array to find the right postion og the pivot
        for (int j = start; j < end; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                swap(arr, i, j);
            }
        }
        swap(arr, i + 1, end);
        return i + 1; // the left part is smaller than the pivot and the right one is greatter
    }

    static void QuickSort(int[] arr, int start, int end)
    {
        if (start < end)
        {
            int partitionIndex = partition(arr, start, end);
            QuickSort(arr, start, partitionIndex - 1);
            QuickSort(arr, partitionIndex + 1, end);
        }

    }



}