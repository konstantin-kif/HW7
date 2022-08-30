// Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

int RowsArray = InputUserNumber("Enter the number of rows in the array");
int ColumnsArray = InputUserNumber("Enter the number of columhs in the array");

double[,] ArrayOfRandomNumbers = CeneratorArrayOfRandomNumber(RowsArray, ColumnsArray);

PrintArray(ArrayOfRandomNumbers);

int InputUserNumber(string message)      // Функция возвращает введенное число
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

double[,] CeneratorArrayOfRandomNumber(int Rows, int Columns)                           // Функция создания и заполнения двухмерного массива
{
    double[,] arrayRandom = new double[Rows, Columns];
    for (int i = 0; i < arrayRandom.GetLength(0); i++)                                  // строка
    {
        for (int j = 0; j < arrayRandom.GetLength(1); j++)                              // столбец
        {
            arrayRandom[i, j] = (double)(new Random().Next(-999, 1000)) / 10;          // случайные числа
        }

    }
    return arrayRandom;
}

void PrintArray(double[,] arrayInput)                                                    // Функция печати массива
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
