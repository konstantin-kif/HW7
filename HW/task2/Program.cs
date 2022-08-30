// Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

int RowsArray = InputUserNumber("Enter the row in the array");
int ColumnsArray = InputUserNumber("Enter the column in the array");

int[,] arrayOfRandomNumbers = CreateArrayOfRandomNumber(3, 4);

PrintArray(arrayOfRandomNumbers);

PrintValueInArray(arrayOfRandomNumbers, RowsArray, ColumnsArray);

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

int[,] CreateArrayOfRandomNumber(int Rows, int Columns)                           // Функция создания и заполнения двухмерного массива
{
    int[,] arrayRandom = new int[Rows, Columns];
    for (int i = 0; i < arrayRandom.GetLength(0); i++)                            // строка
    {
        for (int j = 0; j < arrayRandom.GetLength(1); j++)                         // столбец
        {
            arrayRandom[i, j] = new Random().Next(0, 10);                          // случайные числа
        }

    }
    return arrayRandom;
}

void PrintArray(int[,] arrayInput)                                                 // Функция печати массива
{
    for (int i = 0; i < arrayInput.GetLength(0); i++)                               // строка
    {
        Console.Write("[");
        for (int j = 0; j < arrayInput.GetLength(1); j++)                          // столбец
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

void PrintValueInArray(int[,] arrayInput, int Row, int Column)
{
    Console.Write($"{Row}, {Column} -> ");
    if (Row > 0 && Row < arrayInput.GetLength(0) && Column > 0 && Column < arrayInput.GetLength(1))
    {
        Console.WriteLine($"{arrayInput[Row, Column]}");
        return;
    }
    Console.WriteLine($"There is no such number is the array");
}