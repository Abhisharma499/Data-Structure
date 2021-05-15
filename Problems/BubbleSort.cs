namespace TestProject.Problems
{
    public static class BubbleSort
    {
        public static int[] Sort(int [] array)
        {
            int temp = 0;
            bool isItemSwapped;
            for(int i=0; i<= array.Length-2;i++)
            {
                isItemSwapped = false;
                for (int j=0;j<=array.Length-2-i;j++)
                {
                    if(array[j]> array[j+1])
                    {
                        isItemSwapped = true;
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }

                if(isItemSwapped== false)
                {
                    return array;
                }

            }

            return array;
        }
    }
}
