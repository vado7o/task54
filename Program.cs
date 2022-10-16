// Задача 54: Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

Console.Clear();
Console.WriteLine("Программа упорядочивает по убыванию элементы каждой строки двумерного массива");

int row = AskForInput("строк");
int column = AskForInput("столбцов");

int[,] array = FillArray(row, column, 1, 10);

Console.Write("\nCгенерированный массив: \n");
PrintArray(array);

System.Console.WriteLine("\nМассив с отсортированными по убыванию строками: \n");
SortArrayRow(array);


//////////////////////////// функции ////////////////////////////////////////////////////

int[,] FillArray(int row, int column, int min, int max)
{
    int[,] filledArray = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            filledArray[i, j] = new Random().Next(min, max);
        }
    }
    return filledArray;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i,j] + " ");
        }
    Console.WriteLine();
    }   
}

int AskForInput(string str)
{
    while (true)
    {
        Console.Write($"\nНапишите - из скольки {str} должен состоять массив? :");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number > 0) 
            {
                return number;
                break;
            }
            else Console.WriteLine($"Некорректно указано количество {str} массива!\n");
        }
        else Console.WriteLine($"Некорректно указано количество {str} массива!\n");
    }
}

void SortArrayRow(int[,] array)
{
    int [] tempArray = new int [column];
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            tempArray[j] = array[i,j];
        }
     QuickSortRow(0, column - 1, tempArray);
     System.Console.WriteLine(string.Join(" ", tempArray));
    }
} 

void QuickSortRow(int low, int high, int [] tempArray)
{
    if(low < high)
    {
        int pivot = PivotSelect(tempArray, low, high);
        QuickSortRow(low, pivot - 1, tempArray);
        QuickSortRow(pivot + 1, high, tempArray);
    }
}

int PivotSelect(int [] array, int low, int high)
{
    int pivot = array[high];
    int index = low;
    for(int j = low; j < high; j++)
    {
        if(array[j] >= pivot)
        {
            int temp_1 = array[index];
            array[index] = array[j];
            array[j] = temp_1;
            index++;
        }
    }
    int temp_2 = array[index];
    array[index] = array[high];
    array[high] = temp_2;
    return index;
}