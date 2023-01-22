namespace DZ_Fibonacci_WithService_WithStaticClass_3.Services
{
    public class Fibonacci
    {
        public long GetValue(int index)
        {
            long[] arr = new long[100];
            arr[0] = 0;
            arr[1] = 1;
            for (int j = 2; j < arr.Length; j++)
            {
                arr[j] = arr[j - 1] + arr[j - 2];
            }
            return arr[index];
        }
    }

    public class FibonacciService
    {
        public readonly Fibonacci fibonacci;

        public FibonacciService(Fibonacci fibonacci)
        {
            this.fibonacci = fibonacci;
        }

        public string GetValue(int index)
        {
            return $"<h2>F = {fibonacci.GetValue(index)}</h2>";
        }
    }
}