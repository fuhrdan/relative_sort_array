/**
 * Note: The returned array must be malloced, assume caller calls free().
 */

int* relativeSortArray(int* arr1, int arr1Size, int* arr2, int arr2Size, int* returnSize) {
    int currentPos = 0;
    int swapNum = 0;
    *returnSize = arr1Size;
    int* retNum = (int *)malloc((arr1Size+1) * sizeof(int));
    int hash[1001] = {0};
    int maxnum = 0;
    for(int x = 0; x < arr2Size; x++)
    {
        for(int y = 0; y < arr1Size; y++)
        {
            
            if(arr1[y] > maxnum) maxnum = arr1[y];
            if(arr1[y] == arr2[x])
            {
                swapNum = arr1[currentPos];
                arr1[currentPos] = arr1[y];
                arr1[y] = swapNum;
                currentPos++;
                hash[y]++;
            }
        }
        hash[x] = 0;
    }
//    printf("CurrentPos = %d, maxnum = %d\n",currentPos,maxnum);
    //sort the list
    while(currentPos < arr1Size)
    {
        for(int x = currentPos; x < arr1Size; x++)
        {
//            printf("Compare arr1[%d] = %d to arr1[%d] = %d\n",x,arr1[x],currentPos,arr1[currentPos]);
            if(arr1[x] < arr1[currentPos])
            {
                swapNum = arr1[x];
                arr1[x] = arr1[currentPos];
                arr1[currentPos] = swapNum;
            }
        }
        currentPos++;
    }
    for(int x = 0; x < arr1Size; x++)
    {
        retNum[x] = arr1[x];
//        printf("retNum[%d] = %d\n",x,retNum[x]);
    }
    return retNum;
}