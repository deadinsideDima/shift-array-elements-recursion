using System;

namespace ShiftArrayElements
{
    public static class RecursiveEnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[]? source, Direction[]? directions)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source is null");
            }

            if (directions is null)
            {
                throw new ArgumentNullException(nameof(directions), "Directions are null");
            }

            if (directions.Length == 0)
            {
                return source;
            }

            if (directions[0] == Direction.Left)
            {
                int temp = source[0];
                int[] tSourc = new int[source.Length];
                Array.Copy(source, 1, tSourc, 0, source.Length - 1);
                tSourc[tSourc.Length - 1] = temp;
                Direction[] directionsTemp = new Direction[directions.Length - 1];
                Array.Copy(directions, 1, directionsTemp, 0, directions.Length - 1);
                return Shift(tSourc, directionsTemp);
            }
            else if (directions[0] == Direction.Right)
            {
                int temp = source[source.Length - 1];
                int[] tempSource = new int[source.Length];
                Array.Copy(source, 0, tempSource, 1, source.Length - 1);
                tempSource[0] = temp;
                Direction[] directionsTemp = new Direction[directions.Length - 1];
                Array.Copy(directions, 1, directionsTemp, 0, directions.Length - 1);
                return Shift(tempSource, directionsTemp);
            }
            else
            {
                throw new InvalidOperationException($"Incorrect {directions} enum value.");
            }
        }
    }
}
