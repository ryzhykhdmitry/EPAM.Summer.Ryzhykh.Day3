using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BitAdder
{
    /// <summary>
    /// Allows to use some bit operations
    /// </summary>
    public class Adder
    {
        /// <summary>
        /// Allows to insert one number into second number by bits
        /// </summary>
        /// <param name="number1">The number, in which we insert</param>
        /// <param name="number2">The number, that we insert.</param>
        /// <param name="startPosition">Start bit position </param>
        /// <param name="endPosition">End bit position</param>
        /// <returns>The number, that contains bits of two numbers</returns>
        public static int insertIntoPosition(int number1, int number2, int startPosition, int endPosition)
        {
            if (startPosition > endPosition) throw new ArgumentException();
            if (startPosition < 0 || endPosition < 0 || startPosition > 32 || endPosition > 32) throw new ArgumentException();

            // converting the number to BitArray
            BitArray a = new BitArray(new int[] { number1 });
            BitArray b = new BitArray(new int[] { number2 });

            for (int j = startPosition; j <= endPosition; j++)
            {               
                    a.Set(j, b.Get(j));            
            }
     
            // converting BitArray to byte again
            int[] array = new int[1];
            a.CopyTo(array, 0);
            return array[0];
        }
    }
}
