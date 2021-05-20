using System;

namespace ConsoleApp12
{
    class Program
    {
        static double[,] ReadImageDataFromFile(string imageDataFilePath)
        {
            string[] lines = System.IO.File.ReadAllLines(imageDataFilePath);
            int imageHeight = lines.Length;
            int imageWidth = lines[0].Split(',').Length;
            double[,] imageDataArray = new double[imageHeight, imageWidth];

            for (int i = 0; i < imageHeight; i++)
            {
                string[] items = lines[i].Split(',');
                for (int j = 0; j < imageWidth; j++)
                {
                    imageDataArray[i, j] = double.Parse(items[j]);
                }
            }
            return imageDataArray;
        }

        static void WriteImageDataToFile(string imageDataFilePath,
                                 double[,] imageDataArray)
        {
            string imageDataString = "";
            for (int i = 0; i < imageDataArray.GetLength(0); i++)
            {
                for (int j = 0; j < imageDataArray.GetLength(1) - 1; j++)
                {
                    imageDataString += imageDataArray[i, j] + ", ";
                }
                imageDataString += imageDataArray[i,
                                                imageDataArray.GetLength(1) - 1];
                imageDataString += "\n";
            }

            System.IO.File.WriteAllText(imageDataFilePath, imageDataString);
        }

        static void Main(string[] args)
        {
            Console.Write("Input file address :");
            string InputFileAdd = Console.ReadLine();
            Console.Write("Convolution Kernel file address :");
            string ConKerFileAdd = Console.ReadLine();
            Console.Write("Result file address :");
            string ResultFileadd = Console.ReadLine();

            ReadImageDataFromFile(InputFileAdd);

            ReadImageDataFromFile(ConKerFileAdd);
            /*for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    ReadImageDataFromFile(InputFileAdd)[i, 1] = ReadImageDataFromFile(InputFileAdd)[i, 6];
                    if (i == 1)
                    {
                        ReadImageDataFromFile(InputFileAdd)[1, 1] = ReadImageDataFromFile(InputFileAdd)[6, 1];
                        ReadImageDataFromFile(InputFileAdd)[1, 1] = ReadImageDataFromFile(InputFileAdd)[6, 6];
                    }
                }
            }
            Console.WriteLine(ReadImageDataFromFile(InputFileAdd));  */

            WriteImageDataToFile(ResultFileadd, ReadImageDataFromFile(ConKerFileAdd));
        }
    }
}
