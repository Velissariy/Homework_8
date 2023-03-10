// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

// Задача 58: Задайте две матрицы. 
// Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Menu();

void Menu() //Меню выбора задачи.
{
    Console.Clear();
    Console.WriteLine("Меню выбора задачи.");
    Console.WriteLine("Введите цифру для выбора задачи:");
    Console.WriteLine("1 - Программа, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
    Console.WriteLine("2 - Программа, которая находит строку с наименьшей суммой элементов в двумерном массиве.");
    Console.WriteLine("3 - Программа, которая находит произведение двух матриц");
    Console.WriteLine("4 - Программа, которая  построчно выводит массив, добавляя индексы каждого элемента.");
    Console.WriteLine("5 - Программа, которая заполнит спирально массив 4 на 4.");
    int result = Prompt("Введите номер задачи");
   

      switch (result)
      {
        case 1:
          Console.Clear();
          Task_54();
          break;

        case 2:
          Console.Clear();
          Task_56();
          break;

        case 3:
          Console.Clear();
          Task_58();
          break;

        case 4:
          Console.Clear();
          Task_60();
          break;

        case 5:
          Console.Clear();
          Task_62();
          break;

        default:
          Console.Clear();
          Console.WriteLine("Номер задачи введен некорректно. Повторите попытку.");
          Console.ReadLine();
          break;
    }
  }

static int Prompt(string message)
{
    System.Console.Write(message);
    int result = Convert.ToInt32(Console.ReadLine());
    return result;
}

static void arrayFilling(int[,] arr)
{
    Random number = new Random();
    for(int i = 0; i<arr.GetLength(0); i++)
    {
        for(int j = 0; j<arr.GetLength(1); j++)
        {
            arr[i, j] = number.Next(0, 11);
        }
    }
}

static void arrayFilling2(int[,,] arr, int m, int n, int k)
{
    int[] arrXYZ = new int[m*n*k];
    for(int index = 0; index < arrXYZ.Length; index++)
    {
        arrXYZ[index] = index;
    }

    Random digit = new Random();
    int arraySize = arrXYZ.Length-1;
    for (int z = 0; z < arr.GetLength(2); z++)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        { 
            for(int j = 0; j < arr.GetLength(1); j++)
            {
                int randomPosition = digit.Next(0, arraySize);
                arr[i, j, z] = arrXYZ[randomPosition];
                int digitTemporary = arrXYZ[arraySize];
                arrXYZ[arraySize] = arrXYZ[randomPosition];
                arrXYZ[randomPosition] = digitTemporary;
                arraySize = arraySize - 1;
            }
        }
    }
}

static void arraySpiralFilling3(int[,] arr)
{
    int iStart = 0;
    int iFinish = arr.GetLength(0);
    int jStart = 0;
    int jFinish = arr.GetLength(1);
    int iCurrent = iStart;
    int jCurrent = jStart;
    int count = 0;
    
    for(int index = 0; index < arr.GetLength(0)+arr.GetLength(1)-1; index++)
    {
        if(iCurrent == iStart && jCurrent == jStart)
        {
            for (int j = jCurrent, i = iCurrent; j < jFinish; j++)
            {
                arr[i,j] = count;
                count++;
            }
            iStart = iStart+1;
            iCurrent = iStart;
            jCurrent = jFinish;
        }

        if(iCurrent == iStart && jCurrent == jFinish)
        {
            for(int i = iCurrent, j = jCurrent-1; i < iFinish; i++)
            {
                arr[i,j] = count;
                count++;
            }
            jFinish = jFinish - 1;
            iCurrent = iFinish;
            jCurrent = jFinish;
        }

        if(iCurrent == iFinish && jCurrent == jFinish)
        {
            for(int j = jCurrent-1, i = iCurrent-1; j >= jStart; j--)
            {
                arr[i, j] = count;
                count++;
            }
            iFinish = iFinish - 1;
            iCurrent = iFinish;
            jCurrent = jStart;
        }

        if(iCurrent == iFinish && jCurrent == jStart)
        {
            for(int i = iCurrent-1, j = jCurrent; i >= iStart; i--)
            {
                arr[i, j] = count;
                count++;
            }
            jStart = jStart+1;
            iCurrent = iStart;
            jCurrent = jStart;
        }
    }
}

static void arrayArrangeHighLow(int[,] Array1)
{
    for(int i = 0; i<Array1.GetLength(0); i++)
    {
        for(int counter = 0; counter<Array1.GetLength(1); counter++)
        {
            for(int j = 0; j<Array1.GetLength(1)-1; j++)
            {
                if(Array1[i,j] < Array1[i,j+1])
                {
                    int digitTemporary = Array1[i,j+1];
                    Array1[i,j+1] = Array1[i,j];
                    Array1[i,j] = digitTemporary; 
                }
            }
        }
    }
}

static void arrayPrint(int[,] arrayPrint)
{
    for(int i = 0; i<arrayPrint.GetLength(0); i++)
    {
        System.Console.WriteLine();
        for (int j = 0; j<arrayPrint.GetLength(1); j++)
        {
            System.Console.Write(arrayPrint[i,j] + "    ");
        }
    }
}

static void arrayPrint2(int[,] arrayPrint)
{
    for(int i = 0; i<arrayPrint.GetLength(0); i++)
    {
        System.Console.WriteLine();
        for (int j = 0; j<arrayPrint.GetLength(1); j++)
        {
            System.Console.Write("{0:d3} ", arrayPrint[i,j]);
        }
    }
}

static void arrayPrint3(int[, ,] arrayPrint)
{
    for (int z = 0; z < arrayPrint.GetLength(2); z++)
    {
        for (int i = 0; i < arrayPrint.GetLength(0); i++)
        {
            System.Console.WriteLine();
            for (int j = 0; j < arrayPrint.GetLength(1); j++)
            {
                System.Console.Write("|{0:d2}| ({1}, {2}, {3})  ", arrayPrint[i, j, z], i, j, z);
            }
        }
        System.Console.WriteLine();
    }
}

static void arrayFillingSumOfRow(int[,] arraySMSVoid, int[] arrayOfSumVoid)
{
    //int[] arrayOfSum = new int[arraySMSVoid.GetLength(0)];
    int index = 0;
    for(int i = 0; i < arraySMSVoid.GetLength(0); i++)
    {
        int rowSum = 0;
        for (int j = 0; j < arraySMSVoid.GetLength(1); j++)
        {
            rowSum = rowSum + arraySMSVoid[i, j];
        }
        arrayOfSumVoid[index] = rowSum;
        index++;
    }
}

static void arraySearchMinimalSum(int[] arrayOfSumVoid)
{
    int imin = 0;
    int minimalValue = arrayOfSumVoid[imin];
    for (int i = 0; i<arrayOfSumVoid.Length; i++)
    {
        if(arrayOfSumVoid[i] < minimalValue)
        {
            minimalValue = arrayOfSumVoid[i];
            imin = i;
        }
    }
    System.Console.WriteLine($"Минимальная сумма из  {imin+2} строк равна {minimalValue}");
}

static void arraysMultiplication(int[,] array1, int[,] array2, int[,] array3)
{
    for(int iResult = 0, i=0; iResult < array3.GetLength(0); iResult++, i++)
    {
        for(int jResult = 0, j2 = 0; jResult < array3.GetLength(1); jResult++, j2++)
        {
            int cellMultiplicationResult = 0;
            for(int j = 0, i2 = 0; j < array1.GetLength(1) && i2 < array2.GetLength(0); j++, i2++)
            {
                cellMultiplicationResult += array1[i,j] * array2 [i2, j2];
            }
            array3[iResult, jResult] = cellMultiplicationResult;
        }

    }
}

void Task_54()
{

int[,] array = new int[new Random().Next(3,7), new Random().Next(4,7)];
arrayFilling(array);
arrayPrint(array);
System.Console.WriteLine();
arrayArrangeHighLow(array);
arrayPrint(array);
System.Console.WriteLine();
}

void Task_56()
{
int[,] array = new int[new Random().Next(3,7), new Random().Next(4,7)];
int[] arrayOfSum = new int[array.GetLength(0)];
arrayFilling(array);
arrayPrint(array);
System.Console.WriteLine();
arrayFillingSumOfRow(array, arrayOfSum);
System.Console.WriteLine();

System.Console.Write("Сумма строк: ");
foreach(int value in arrayOfSum)
{
    System.Console.Write($"{value}  ");
}
System.Console.WriteLine();
arraySearchMinimalSum(arrayOfSum);
System.Console.WriteLine();

}

void Task_58()
{
int m1 = new Random().Next(3,7);
int n1 = new Random().Next(3,7);
int m2 = n1;
int n2 = new Random().Next(3,7);

int[,] array1 = new int[m1, n1];
int[,] array2 = new int[m2, n2];
int[,] arrayResult = new int[array1.GetLength(0), array2.GetLength(1)];

arrayFilling(array1);
arrayFilling(array2);
arrayPrint(array1);
System.Console.WriteLine();
arrayPrint(array2);
System.Console.WriteLine();
arraysMultiplication(array1, array2, arrayResult);
System.Console.WriteLine();

System.Console.WriteLine("Результата произведения 2х матриц: ");
arrayPrint2(arrayResult);
System.Console.WriteLine();
System.Console.WriteLine();
}

void Task_60()
{
System.Console.WriteLine();
int m = new Random().Next(2,7);
int n = new Random().Next(2,7);
int k = new Random().Next(2,7);

int[,,] array = new int[m, n, k];
arrayFilling2(array, m, n, k);
arrayPrint3(array);
System.Console.WriteLine();
}

void Task_62()
{
    int m = 4;
int n = 4;
int[,] array = new int[m,n];

arraySpiralFilling3(array);
arrayPrint(array);
System.Console.WriteLine();
System.Console.WriteLine();

}