using System;
using System.Runtime.InteropServices;

namespace Arrays
{


    //1d array

    //class Program
    //{
    //    static void Main()
    //    {
    //        // Declare and initialize a 1D array
    //        int[] numbers = { 10, 20, 30, 40, 50 };

    //        // Print the elements of the array
    //        Console.WriteLine("Array Elements:");
    //        for (int i = 0; i < numbers.Length; i++)
    //        {
    //            Console.WriteLine(numbers[i]);
    //        }

    //        // Modify an element
    //        numbers[3] = 45; // Change the value at index 2

    //        // Print the modified array
    //        Console.WriteLine("\nModified Array Elements:");
    //        foreach (int number in numbers)
    //        {
    //            Console.WriteLine(number);
    //        }
    //    }
    //}


    //2d array

    //class Program
    //{
    //    static void Main()
    //    {
    //        // Declare and initialize a 2D array
    //        int[,] matrix = {
    //        { 1, 2, 3 },
    //        { 4, 5, 6 },
    //        { 7, 8, 9 }
    //    };

    //        // Print the elements of the 2D array
    //        Console.WriteLine("Matrix Elements:");
    //        for (int i = 0; i < matrix.GetLength(0); i++) // Iterate through rows
    //        {
    //            for (int j = 0; j < matrix.GetLength(1); j++) // Iterate through columns
    //            {
    //                Console.Write(matrix[i, j] + "\t");
    //            }
    //            Console.WriteLine(); // New line after each row
    //        }


    //        // Modify an element
    //        matrix[1, 0] = 5; // Change the value at row 1, column 1

    //        // Print the modified 2D array
    //        Console.WriteLine("\nModified Matrix Elements:");
    //        for (int i = 0; i < matrix.GetLength(0); i++)
    //        {
    //            for (int j = 0; j < matrix.GetLength(1); j++)
    //            {
    //                Console.Write(matrix[i, j] + "\t");
    //            }
    //            Console.WriteLine();
    //        }
    //    }
    //}



    // array methods


    ////sort
    //class Program
    //{
    //    static void Main()
    //    {
    //        int[] numbers = { 4, 2, 5, 1, 3 };

    //        // Sort the array
    //        Array.Sort(numbers);

    //        // Print sorted array
    //        foreach (int num in numbers)
    //        {
    //            Console.Write(num + " ");
    //        }
    //    }
    //}


    //reverse array

    //class Program
    //{
    //    static void Main()
    //    {
    //        int[] numbers = { 1, 2, 3, 4, 5 };

    //        // Reverse the array
    //        Array.Reverse(numbers);

    //        // Print reversed array
    //        foreach (int num in numbers)
    //        {
    //            Console.Write(num + " ");
    //        }
    //    }
    //}


    //array index

    //class Program
    //{
    //    static void Main()
    //    {
    //        int[] numbers = { 10, 20, 30, 40, 50 };

    //        // Find the index of a value
    //        int index = Array.IndexOf(numbers, 30);
    //        Console.WriteLine("Index of 30: " + index); // Output: 2
    //    }
    //}


    //array clear

    //class Program
    //{
    //    static void Main()
    //    {
    //        int[] numbers = { 1, 2, 3, 4, 5 };

    //        // Clear the first two elements
    //        Array.Clear(numbers, 0, 2);

    //        // Print array after clear
    //        foreach (int num in numbers)
    //        {
    //            Console.Write(num + " ");
    //        }
    //    }
    //}


    // array resize

    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3 };

            // Resize the array to hold 5 elements
            Array.Resize(ref numbers, 5);
            numbers[3] = 4; // Add a new value
            numbers[4] = 5; // Add another new value

            // Print resized array
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
        }
    }


}
