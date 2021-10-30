/*
Задача
Cформировать случайным образом целочисленный массив A из натуральных двузначных чисел. 
Создать на его основе масив B, отбрасывая те, которые

- нарушают порядок возрастания
- больше среднего арифметического элементов A
- чётные
*/

// вывод массива
void printArray(int[] array)

{
    if (array.Length == 0) Console.WriteLine("Массив пуст");

    int index = 0;
    while (index < array.Length) Console.WriteLine(array[index++]);

    Console.WriteLine();
}

// инициализация массива
int[] setArray(int len)
{
    int[] array = new int[len];
    int index = 0;
    while (index < array.Length)
        array[index++] = new Random().Next(10, 100);

    return array;
}

// Задание по 
//   - возрастания
int[] Zadanie1(int[] array)
{
    int[] result = new int[array.Length];


    int index = 1,
        indexResult = 0;
    int curElem = result[indexResult++] = array[0];

    while (index < array.Length)
    {
        if (array[index] > curElem)
        {
            result[indexResult++] = array[index];
            curElem = array[index];
        }
        index++;
    }
    Array.Resize(ref result, indexResult);

    return result;
}

//поиск среднего арифметического
double srArifmet(int[] array)
{
    int index = 0;
    int sum = 0;
    while (index < array.Length) sum += array[index++];

    return (double) sum / array.Length;
}

// Задание по 
//  - больше заданного числа [среднего арифметического элементов A]
int[] Zadanie2(int[] array, double number)
{
    int index = 0;
    int[] result = new int[array.Length];
    int indexResult = 0;

    while (index < array.Length)
    {
        if (array[index] <= number)
            result[indexResult++] = array[index];
        index++;
    }
    Array.Resize(ref result, indexResult);
    return result;
}

int[] Zadanie3(int[] array)
{
    int[] result = new int[array.Length];
    int index = 0,
        indexResult = 0;

    while (index < array.Length)
    {
        if (array[index] % 2 != 0)
            result[indexResult++] = array[index];
        index++;
    }

    Array.Resize(ref result, indexResult);
    return result;
}

Console.WriteLine("Сгенерированный массив:");
int[] myArray = setArray(10);
printArray(myArray);

Console.WriteLine("Массив-результат задания 1:");
int[] myArray1 = Zadanie1(myArray);
printArray(myArray1);

double srednee = srArifmet(myArray);

Console.WriteLine($"Массив-результат задания 2 (Среднее={srednee}):");

int[] myArray2 = Zadanie2(myArray, srArifmet(myArray));
printArray(myArray2);

Console.WriteLine("Массив-результат задания 3:");
int[] myArray3 = Zadanie3(myArray);
printArray(myArray3);

