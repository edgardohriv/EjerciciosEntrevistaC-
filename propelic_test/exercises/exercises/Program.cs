using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace exercises
{
    class Program
    {

        static void Main(string[] args)
        {
           
            int intInputOption;
            string strInputOption;

            do
            {
                Console.WriteLine("*****************************************************************");
                Console.WriteLine("*                                                               *");
                Console.WriteLine("*             DEVELOPER : EDGARDO HERNANDEZ RIVERA              *");
                Console.WriteLine("*                                                               *");
                Console.WriteLine("*****************************************************************");
                Console.WriteLine();
                Console.WriteLine("---------------  Select the operation to perform  ---------------");
                Console.WriteLine();
                Console.WriteLine("1 .- Problema 1 ( Sumatoria de cocientes )");
                Console.WriteLine("2 .- Problema 2 ( Calculate angle between hour and minute hands)");
                Console.WriteLine("3 .- Problema 3 ( Convert integer to roman number )");
                Console.WriteLine("4 .- Problema 4 ( Check if one word is anagram from another)");
                Console.WriteLine("5 .- Problema 5 ( Basic String compression )");
                Console.WriteLine("6 .- Problema 6 ( Swap 2 integers without temporary variable )");
                Console.WriteLine("7 .- Problema 7 ( Check 0 elements in a matrix )");
                Console.WriteLine("8 .- SALIR DEL PROGRAMA");
                Console.WriteLine("------------------------------------------------------------------");

                strInputOption = Console.ReadLine();

                if (!Int32.TryParse(strInputOption, out intInputOption))
                {
                    Console.WriteLine("El numero no se pudo convertir a entero");
                }
                else
                {

                    switch (intInputOption)
                    {
                        case 1:
                            Console.WriteLine("*** SUMATORIA UTILIZANDO FORMULA ***");
                            CalculatingSummatoryFormulaCaller();
                            break; 
                        case 2:
                            Console.WriteLine("*** CALCULATING ANGLE BETWEEN HOURS AND MINUTES ***");
                            CalculatingAnglesCaller();
                            break;
                        case 3:
                            Console.WriteLine("*** CONVERTING INTEGER TO ROMAN NUMBER ***");
                            ConvertingIntegerToRomanStringNumberCaller();
                            break;
                        case 4:
                            Console.WriteLine("***  CHECKING IF TWO STRINGS ARE ANAGRAM OR NOT ***");
                            CheckIfAnagramCaller();
                            break;
                        case 5:
                            Console.WriteLine("***  BASIC STRING COMPRESSION ***");
                            BasicStringCompressionCaller();
                            break;
                        case 6:
                            Console.WriteLine("***   SWAPING 2 INTEGERS WITHOUT USING TEMPORARY VARIABLE  ***");
                            //SwapingTwoIntegersWithoutTempCaller();
                            break;
                        case 7:
                            Console.WriteLine("***   CHANGIN ROW AND COLUMN TO ZERO IF CROSS ELEMENT EQUALS TO ZERO ***");
                            ChangeToZerosInMatrixCaller();
                            break;
                        case 8:  Console.WriteLine("EXITING .....");
                            break;
                    }
                    
                }

                Console.WriteLine("Presione enter para continuar ...");
                Console.ReadKey();
                Console.Clear();


            } while (intInputOption != 8);
        }

        //*** 1.- SUMATORIA UTILIZANDO FORMULA ***
        public static double CalculatingSummatoryFormula(double k, double limite)
        {

            //recursively works but ..it fails when using to high values like 1,000,000
            /*
           sumatoria +=  (Math.Pow(-1, k + 1) / (2 * k - 1));
            if ( k < limite) {     k++;       CalculatingSummatoryFormula();     }
            */

            double sumatoria = 0;
            for (k =1; k <=limite ;  k++) sumatoria += (Math.Pow(-1, k + 1) / (2 * k - 1));
            return 4 * sumatoria;
        }

        //*** 2.- CALCULATING ANGLE BETWEEN HOURS AND MINUTES ***
        public static int CalculatingAngles(int h, int m)
        {
            // primero validamos la entrada
            if (h < 0 || m < 0 || h > 12 || m > 60) Console.Write("Las horas o los minutos son invalidos");
            if (h == 12) h = 0;
            if (m == 60) m = 0;

            // Calsularemos los angulos de la manecilla minuto y manecilla segundo
            // en base a que una hora tiene 360 grados , asi nuestra hora base es 12:00 la cual tiene un angulo=0
            int grados_horas = (int)(0.5 * (h * 60 + m));
            int grados_minutos = (int)(6 * m);

            // Calcularemos la diferencia entre ambos angulos
            int angulo_calculado = Math.Abs(grados_horas - grados_minutos);
            int complemento = 360 - angulo_calculado;

            // Si el complemento del angulo calculado es menor, devolvemos este complemento
            // Esto con la finalidad de no devolver angulos muy grandes
            return Math.Min(complemento, angulo_calculado);
        }

        //*** 3.- CONVERTING INTEGER TO ROMAN NUMBER***
        public static string ConvertingIntegerToRomanStringNumber(int integerNumber)
        {
            if ((integerNumber < 0) || (integerNumber > 3999))
            {
                return "Integer number must be between 1 y 3999";
            }
            else
            {
                if (integerNumber < 1) return string.Empty;
                if (integerNumber >= 1000) return "M" + ConvertingIntegerToRomanStringNumber(integerNumber - 1000);
                if (integerNumber >= 900) return "CM" + ConvertingIntegerToRomanStringNumber(integerNumber - 900);
                if (integerNumber >= 500) return "D" + ConvertingIntegerToRomanStringNumber(integerNumber - 500);
                if (integerNumber >= 400) return "CD" + ConvertingIntegerToRomanStringNumber(integerNumber - 400);
                if (integerNumber >= 100) return "C" + ConvertingIntegerToRomanStringNumber(integerNumber - 100);
                if (integerNumber >= 90) return "XC" + ConvertingIntegerToRomanStringNumber(integerNumber - 90);
                if (integerNumber >= 50) return "L" + ConvertingIntegerToRomanStringNumber(integerNumber - 50);
                if (integerNumber >= 40) return "XL" + ConvertingIntegerToRomanStringNumber(integerNumber - 40);
                if (integerNumber >= 10) return "X" + ConvertingIntegerToRomanStringNumber(integerNumber - 10);
                if (integerNumber >= 9) return "IX" + ConvertingIntegerToRomanStringNumber(integerNumber - 9);
                if (integerNumber >= 5) return "V" + ConvertingIntegerToRomanStringNumber(integerNumber - 5);
                if (integerNumber >= 4) return "IV" + ConvertingIntegerToRomanStringNumber(integerNumber - 4);
                if (integerNumber >= 1) return "I" + ConvertingIntegerToRomanStringNumber(integerNumber - 1);
                throw new ArgumentOutOfRangeException("Number cannot be evaluated");
            }
        }

        //*** 4.- CHECKING IF TWO STRINGS ARE ANAGRAM OR NOT ***
        public static bool CheckIfAnagram(char[] firstString, char[] secondString)
        {
            // lets declare a constant
            int NumCharacters = 256;
            int[] countFirstString = new int[NumCharacters];
            int[] countSecondString = new int[NumCharacters];
            int charIndex;


            for (charIndex = 0; charIndex < firstString.Length && charIndex < secondString.Length; charIndex++)
            {
                countFirstString[firstString[charIndex]]++;
                countSecondString[secondString[charIndex]]++;
            }

            // if are not of the same length then are not anagram
            if (firstString.Length != secondString.Length)
                return false;

            // Lets compare character by character one array to another
            for (charIndex = 0; charIndex < NumCharacters; charIndex++)
                if (countFirstString[charIndex] != countSecondString[charIndex])
                    return false;

            return true;
        }

        //*** 5.- BASIC STRING COMPRESSION ***
        public static string BasicStringCompression(string inputString)
        {
            var alphabet = Enumerable.Range(97, 26).Select(index => (char)index + "+");
            var pattern = "(" + string.Join("|", alphabet) + ")";

            return 
                Regex.Matches(inputString, pattern)
                .Cast<Match>().Select(m => new  {  character = m.Groups[1].Value[0], counter = m.Groups[1].Value.Length })
                .Aggregate(string.Empty, (result, nextGroup) => result.ToString()
                   + nextGroup.character
                   +  nextGroup.counter.ToString() );
        }

        //***  6.- SWAPING 2 INTEGERS WITHOUT USING TEMPORARY VRIABLE  ***
        public static void SwapingTwoIntegersWithoutTemp(ref int firstInteger, ref int secondInteger)
        {
            firstInteger = firstInteger + secondInteger; //"store or hide " the second value in the first variable    
            secondInteger = firstInteger - secondInteger; // retrive the first value  by substracting the second value  annd assign to the second variable      
            firstInteger = firstInteger - secondInteger; // retrive the second value by substracting the second value and assign to the first value
        }

        //***  7.- CHANGIN ROW AND COLUMN TO ZERO IF CROSS ELEMENT EQUALS TO ZERO ***
        public static void ChangeToZerosInMatrix(int[,] M, int m, int n)
        {

            bool[] rowZero = new bool[m];
            bool[] colZero = new bool[n];

            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++) {      if (M[x,y] == 0)  {  rowZero[x] = true;      colZero[y] = true;   }
                }
            }
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++) {      if (rowZero[x] || colZero[y])     M[x,y] = 0;       }
            }
        }


        // ********************************  CALLER UTILITY METHODS  ****************************
        #region ********************************  CALLER UTILITY METHODS  ****************************
        public static void CalculatingSummatoryFormulaCaller()
        {
            int inputPotencia;
            int inputBase;

            Console.WriteLine("Enter the base number of the formula: ");
            string input = Console.ReadLine();
            if (!Int32.TryParse(input, out inputPotencia))
            {
                Console.WriteLine("The base number cannot be converted to number");
            }
            else
            {
                Console.WriteLine("Enter exponent number of the formula : ");
                input = Console.ReadLine();
                if (!Int32.TryParse(input, out inputBase))
                {
                    Console.WriteLine("The exponent number cannot be converted to integer");
                }
                else
                {
                    Console.WriteLine($"The result after apliying the summatory formula is :  {  CalculatingSummatoryFormula(1, Math.Pow(inputPotencia, inputBase))}");
                }
            }


        }
        public static void CalculatingAnglesCaller()
        {
            //Console.WriteLine(calculatingAngles(2, 30)); //sin calcular debe arrojar poco menos de 120 gtados ( la manesilla de la hora tmb se mueve)
            //Console.Write(calculatingAngles(10, 15)); //sin calcular debe arrojar poco menos de 150 grados
            int inputHour;
            int inputMinute;
            Console.WriteLine("Enter the hour : ");
            string input = Console.ReadLine();
            if (!Int32.TryParse(input, out inputHour))
            {
                Console.WriteLine("The hour cannote be converted to ingteger");
            }
            else
            {
                Console.WriteLine("Enter the minutes : ");
                input = Console.ReadLine();
                if (!Int32.TryParse(input, out inputMinute))
                {
                    Console.WriteLine("The minutes cannot be converted to integer ");
                }
                else
                {
                    Console.WriteLine(CalculatingAngles(inputHour, inputMinute));
                }
            }
        }
        public static void ConvertingIntegerToRomanStringNumberCaller()
        {
            int inputNumber;
            Console.WriteLine("Enter the integer number to be converted");
            string input = Console.ReadLine();
            if (!Int32.TryParse(input, out inputNumber))
            {
                Console.WriteLine("The input integer cannot be converted ");
            }
            else
            {
                Console.WriteLine($" The input number  {inputNumber} has a roman equivalent : {ConvertingIntegerToRomanStringNumber(inputNumber)}");
            }
        }
        public static void CheckIfAnagramCaller()
        {

            Console.WriteLine("Enter the firts string: ");
            string firstString = Console.ReadLine();
            Console.WriteLine("Enter the firts string: ");
            string secondString = Console.ReadLine();

            if (CheckIfAnagram(firstString.ToCharArray(), secondString.ToCharArray()))
            {
                Console.WriteLine("YES !!!, the two strings are anagram of each other");
            }
            else
            {
                Console.WriteLine("NO, the two strings are NOT anagram of each other");
            }
        }
        public static void BasicStringCompressionCaller()
        {
            Console.WriteLine("Enter string to be compressed using basic compresion: ");
            string inputString = Console.ReadLine();

            Console.WriteLine($"The output string compressed is : { BasicStringCompression(inputString) }");
        }
        public static void SwapingTwoIntegersWithoutTempCaller()
        {
            int firstInteger;
            int secondInteger;
            Console.WriteLine("Enter the First Integer : ");
            string input = Console.ReadLine();
            if (!Int32.TryParse(input, out firstInteger))
            {
                Console.WriteLine("The First Integer cannot be converted to integer");
            }
            else
            {
                Console.WriteLine("Enter the Second Integer : ");
                input = Console.ReadLine();
                if (!Int32.TryParse(input, out secondInteger))
                {
                    Console.WriteLine("The Second Integer cannot be converted to integer ");
                }
                else
                {
                    Console.WriteLine("Before calling wapping method :  First integer = " + firstInteger + " Second Integer = " + secondInteger);
                    SwapingTwoIntegersWithoutTemp(ref firstInteger, ref secondInteger);
                    Console.WriteLine("After swapping the integers numbers : First Integer = " + firstInteger  + " Second Integer = " + secondInteger);
                }
            }
        }
        public static void ChangeToZerosInMatrixCaller()
        {
            int[,] matrix = new int [,]{{1,2,3},{4,0,6},{7,8,9}};
            Console.WriteLine("Before calling ChangeToZerosInMatrix method");
            PrintMatrix(matrix);
            ChangeToZerosInMatrix(matrix, 3, 3);
            Console.WriteLine("After calling ChangeToZerosInMatrix method");
            PrintMatrix(matrix);
        }

        static public void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    //put a single value
                    Console.Write(matrix[i, k]);
                }
                //next row
                Console.WriteLine();
            }
        }
        #endregion
    }
}
