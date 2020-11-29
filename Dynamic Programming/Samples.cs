public static class Samples
{
  // Max rain water stored 
  public static int MaxWater(int[] arr)
  {
      int lo, hi, result = 0;
      int left_max = 0, right_max = 0;
      lo = 0;
      hi = arr.Length - 1;
      while (lo <= hi)
      {
          if (arr[lo] < arr[hi])
          {
              if (arr[lo] > left_max)
              {
                  left_max = arr[lo];
              }
              else
              {
                  result += left_max - arr[lo];
              }
              lo++;
          }
          else
          {
              if (arr[hi] > right_max)
              {
                  right_max = arr[hi];
              }
              else
              {
                  result += right_max - arr[hi];
              }
              hi--;
          }
      }
      return result;
  }
}
