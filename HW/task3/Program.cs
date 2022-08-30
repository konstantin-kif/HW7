// Задайте двумерный массив из целых чисел. 
// Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

int RowsArray = InputUserNumber("Enter the number of rows in the array");
int ColumnsArray = InputUserNumber("Enter the number of columhs in the array");

int[,] ArrayOfRandomNumbers = CeneratorArrayOfRandomNumber(RowsArray, ColumnsArray);

PrintArray(ArrayOfRandomNumbers);

double[] ArithmeticMeanArray = ArithmeticMeanColumnsInArray(ArrayOfRandomNumbers);

PrintArrayTotal(ArithmeticMeanArray);

int InputUserNumber(string message)                                                  // Функция возвращает введенное число
{
    do
    {
        Console.Write(message + " => ");                                             // Ожидает ввод числа     
        bool numberCorrect = int.TryParse(Console.ReadLine(), out int userInput);
        if (numberCorrect)
        {
            return userInput;
        }
        else
        {
            Console.WriteLine("Invalid input!");                                       // Неверный ввод
        }
    }
    while (true);
}

int[,] CeneratorArrayOfRandomNumber(int Rows, int Columns)                           // Функция создания и заполнения двухмерного массива
{
    int[,] arrayRandom = new int[Rows, Columns];
    for (int i = 0; i < arrayRandom.GetLength(0); i++)                                  // строка
    {
        for (int j = 0; j < arrayRandom.GetLength(1); j++)                              // столбец
        {
            arrayRandom[i, j] = new Random().Next(-9, 10);                                 //  числа от -9 до 10
        }

    }
    return arrayRandom;
}

void PrintArray(int[,] arrayInput)                                                    // Функция печати массива
{
    for (int i = 0; i < arrayInput.GetLength(0); i++)                                       // строка
    {
        Console.Write("[");
        for (int j = 0; j < arrayInput.GetLength(1); j++)                                   // столбец
        {
            Console.Write("{0}", arrayInput[i, j]);
            if (j != (arrayInput.GetLength(1) - 1))
            {
                Console.Write("\t ");
            }
        }
        Console.WriteLine("]");
    }
}

double[] ArithmeticMeanColumnsInArray(int[,] arrayInput)          // функция считает по столбцам двухмерного массива
{
    double[] ArithmeticMeanArray = new double[arrayInput.GetLength(1)];
    for (int i = 0; i < arrayInput.GetLength(1); i++)
    {
        for (int j = 0; j < arrayInput.GetLength(0); j++)               // суммарное значения по столбцам
        {
            ArithmeticMeanArray[i] += arrayInput[j, i];
        }
    }
    for (int i = 0; i < ArithmeticMeanArray.Length; i++)
    {
        ArithmeticMeanArray[i] /= arrayInput.GetLength(0);           // деления значения на количество строк
    }
    return ArithmeticMeanArray;
}

void PrintArrayTotal(double[] arrayInput)
{
    Console.WriteLine(" -> ");
    for (int i = 0; i < arrayInput.Length; i++)
    {
        Console.Write($"{arrayInput[i]:f1}");
        if (i < (arrayInput.Length - 1))
        {
            Console.Write("\t ");
        }
    }
    Console.WriteLine("]");
}
