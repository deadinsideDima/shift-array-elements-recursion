using System;

namespace ShiftArrayElements
{
    public static class RecursiveShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (odd elements - left direction, even elements - right direction).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[]? source, int[]? iterations)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source is null");
            }

            if (iterations == null)
            {
                throw new ArgumentNullException(nameof(iterations), "Iterations are null");
            }

            if (iterations.Length == 0)
            {
                return source;
            }

            int num = 0;
            for (int i = 0; i < iterations.Length; i++)
            {
                if (iterations[i] > 0)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        num = 1;
                    }
                    else
                    {
                        num--;
                    }

                    iterations[i]--;
                    break;
                }
            }

            if (num == -1)
            {
                int temp = source[0];
                for (int i = 0; i < source.Length - 1; i++)
                {
                    source[i] = source[i + 1];
                }

                source[source.Length - 1] = temp;
                return Shift(source, iterations);
            }
            else if (num == 1)
            {
                int temp = source[source.Length - 1];
                for (int i = source.Length - 1; i > 0; i--)
                {
                    source[i] = source[i - 1];
                }

                source[0] = temp;
                return Shift(source, iterations);
            }
            else
            {
                return source;
            }
        }
    }
}
