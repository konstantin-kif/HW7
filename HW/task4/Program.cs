// Найдите максимальное значение в матрице по каждой строке, ссумируйте их. 
// Затем найдети минимальное значение по каждой колонке, тоже ссумируйте их. 
// Затем из первой суммы (с максимумами) вычтите вторую сумму(с минимумами)

int RowsArray = InputUserNumber("Enter the number of rows in the array");
int ColumnsArray = InputUserNumber("Enter the number of columhs in the array");

int[,] ArrayOfRandomNumbers = CeneratorArrayOfRandomNumber(RowsArray, ColumnsArray);

PrintArray(ArrayOfRandomNumbers);

int[] maxValuesInRowsInArray = MaxValuesInRowsInArray(ArrayOfRandomNumbers);
int[] minValuesInColumnsInArray = MinValuesInColumnsInArray(ArrayOfRandomNumbers);

int sumMaxValuesInRowsInArray = SumValuesInArray(maxValuesInRowsInArray);
int sumMinValuesInColumnsInArray = SumValuesInArray(minValuesInColumnsInArray);

int differenceBetweenSumMaxAndSumMin = sumMaxValuesInRowsInArray - sumMinValuesInColumnsInArray;

Console.WriteLine($"The difference between max and min -> {differenceBetweenSumMaxAndSumMin}");

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
            arrayRandom[i, j] = new Random().Next(0, 10);                                 //  числа от 0 до 10
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

int[] MaxValuesInRowsInArray(int[,] arrayInput) // Функция находит максимальное значение в матрице по каждой строке
{
    int[] maxValuesInRowsInArray = new int[arrayInput.GetLength(0)];
    for (int i = 0; i < arrayInput.GetLength(0); i++)  // Поиск максимального значения
    {
        maxValuesInRowsInArray[i] = int.MinValue;
        for (int j = 0; j < arrayInput.GetLength(1); j++)
        {
            maxValuesInRowsInArray [i] = maxValuesInRowsInArray[i] > arrayInput[i, j] 
                                        ? maxValuesInRowsInArray[i] : arrayInput[i, j];
        }
    }
    return maxValuesInRowsInArray;
}

int[] MinValuesInColumnsInArray(int[,] arrayInput) // Функция находит минимальное значение в матрице по каждому столбцу
{
    int[] minValuesInColumnsInArray = new int[arrayInput.GetLength(0)];
    for (int i = 0; i < arrayInput.GetLength(1); i++)  // Поиск максимального значения
    {
        minValuesInColumnsInArray[i] = int.MaxValue;
        for (int j = 0; j < arrayInput.GetLength(0); j++)
        {
            minValuesInColumnsInArray[i] = minValuesInColumnsInArray[i] > arrayInput[i, j]
                                 ? minValuesInColumnsInArray[i] : arrayInput[i, j];
        }
    }
    return minValuesInColumnsInArray;
}

int SumValuesInArray(int[] arrayInput)      // Функция суммирует значения массива
{
    int sum = 0;
    for (int i = 0; i < arrayInput.Length; i++)                              
    {
        sum += arrayInput[i];
    }
    return sum;
}
