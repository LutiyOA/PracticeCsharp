/*
Задача
Имеется числовой массив A заполненный числами из отрезка [minValue; maxValue]. 
Создать на его основе масив B, отбрасывая те, которые нарушают порядок

- возрастания
- элементы, больше 8
- знакочередования
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
int[] setArray(int len, int minValue, int maxValue)
{
    int[] array = new int[len];
    int index = 0;
    while (index < array.Length)
    {
        array[index] = new Random().Next(minValue, maxValue + 1);
        index++;
    }
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

// Задание по 
//   - элементы, больше 8
int[] Zadanie2(int[] array)
{
    int[] result = new int[array.Length];

    int index = 0, indexResult = 0;

    while (index < array.Length)
    {
        if (array[index] <= 8) result[indexResult++] = array[index];
        index++;
    }

    Array.Resize(ref result, indexResult);
    return result;
}

// Задание по 
//   - знакочередования
int[] Zadanie3(int[] array)
{
    // true - текущий - положительный, false - отрицательный
    bool znak(int a)
    {
        return (a > 0) ? true : false;
    }

    int index = 0;
    int[] result = new int[array.Length];
    int indexResult = 0;
    bool curZnak = true,
         tempZnak = true;

    while (index < array.Length)
    {
        if (array[index] != 0)
        {
            if (indexResult == 0)
            {
                curZnak = znak(array[index]);
                result[indexResult++] = array[index];
                // Console.WriteLine($"Первый элемент: indexResult={indexResult}, curZnak={curZnak}, Элемент={array[index]}");
            }
            else
            {
                tempZnak = znak(array[index]);
                if ((curZnak && !tempZnak) || (!curZnak && tempZnak))
                {
                    curZnak = tempZnak;
                    result[indexResult++] = array[index];
                    // Console.WriteLine($"Добавили элемент в результат: indexResult={indexResult}, curZnak={curZnak}, Элемент={array[index]}");
                }
                else
                {
                    // Console.WriteLine($"Знак тот же: index={index}, curZnak={curZnak}, Элемент={array[index]}");
                }
            }
        }

        index++;
    }

    Array.Resize(ref result, indexResult);
    return result;
}


Console.WriteLine("Сгенерированный массив:");
int[] myArray = setArray(10, -100, 100);
printArray(myArray);

Console.WriteLine("Массив-результат задания 1:");
int[] myArray1 = Zadanie1(myArray);
printArray(myArray1);

Console.WriteLine("Массив-результат задания 2:");
int[] myArray2 = Zadanie2(myArray);
printArray(myArray2);

Console.WriteLine("Массив-результат задания 3:");
int[] myArray3 = Zadanie3(myArray);
printArray(myArray3);
