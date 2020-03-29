# Лекция 2. Строки

## Содержание

---

1. [Операторы](#operators)
2. [Массивы](#arrays)
3. [Строки](#string)

## <a name="operators"> 1. Операторы </a>

---

### Типы по порядку выполнения

- префиксный (++i)
- постфиксный (i++)

### Оператор остатка (`%`)

### Логические операторы

- `&` - И
- `|` - ИЛИ
- `!` - НЕ (приоритетный)

### Операторы сравнения:

- `==`
    int a = 1;
    int b = 2;
    int c = 3;
    Console.WriteLinw( a+b == b+c); // false

### Тернарный оператор (`?:`)

Переводится как "is this condition true ? yes : no"

Пример:

    int a = 1;
    int b = 2;
    int c = 3;
    int d;

    d = a == 1 ? b : c;
    Console.WriteLine($"Value is {d}"); // d = 2

### Оператор `default`

Возвращает стандартное значение объекта/ класса:

    Console.WriteLine(default(int)); // 0
    Console.WriteLine(default(object) is null); // true

### Оператор nameof

    Console.WriteLine(nameof(List<int>)); // List
    Console.WriteLine(nameof(List<int>.Count)); // Count

### Циклические операторы

- for
- foreach
- while
- do...while

Остановка циклических операторов:

- break
- continue

### Условные операторы

- if...else
- switch
- тернарный (?:)

## <a name="arrays"> 2. Массивы </a>

---

[Документация](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays)

Инициализация:
type[] arrayName;

Пример (1D, 2D, Jagger):

    // Declare a single-dimensional array. 
    int[] array1 = new int[5];

    // Declare and set array element values.
    int[] array2 = new int[] { 1, 3, 5, 7, 9 };

    // Alternative syntax.
    int[] array3 = { 1, 2, 3, 4, 5, 6 };

    // Declare a two dimensional array.
    int[,] multiDimensionalArray1 = new int[2, 3];

    // Declare and set array element values.
    int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

    Console.WriteLine($"multiDimensionalArray2 rank is {multiDimensionalArray2.Rank}");
    for (int j = 0; j < multiDimensionalArray2.Rank; j++)
        for (int k = 0; k < multiDimensionalArray2.Length/multiDimensionalArray2.Rank; k++)
            Console.WriteLine($"multiDimensionalArray2[{j}][{k}] =  {multiDimensionalArray2[j,k]}");

    // Declare a jagged array (array of arrays)
    int[][] jaggedArray = new int[6][];

    // Set the values of the first array in the jagged array structure.
    jaggedArray[0] = new int[4] { 1, 2, 3, 4 };

## <a name="array"> 3. Строки (System.String) </a>

---

### Интерполяция строк

    int a = 1;
    Console.WriteLine($"Value is {a}");
    Console.WriteLine("Value is {0}", a); // is equal

Инициализация и проверка пустой строки

    string qqq = string.Empty; // is equal ` string qqq = "";`
    string aaa = " "; //

    Console.WriteLine(string.IsNullOrEmpty(qqq)); // true
    Console.WriteLine(string.IsNullOrEmpty(aaa)); // false

    Console.WriteLine(string.IsNullOrWhiteSpace(qqq)); // true
    Console.WriteLine(string.IsNullOrWhiteSpace(aaa)); // true

Вывод строки без редактирования (используется для указания путей)

    string str = @"C:\perls\word.txt";
    Console.WriteLine(str);

Обрезка строк

    char[] charsToTrim = { '*', ' ', '\'' };
    string banner = "*** Much Ado About Nothing ***";
    string res = banner.Trim(charsToTrim); // `Much Ado About Nothing`
    Console.WriteLine("Trimmmed\n   {0}\nto\n   '{1}'", banner, res);

Замена элементов и поиск позиции элемента

    String str = "1 2 3 4 5 6 7 8 9";
    Console.WriteLine(str.Replace(' ', ',')); // 1,2,3,4,5,6,7,8,9
    Console.WriteLine(str.IndexOf('8')); // 14

## **ДЗ**

Создать обработки введенного дня недели. Для этого использовать:

- ENUM,
- ReadLine (1, monday, Mon)
- en/ru

Функционал:

- Планировать дела за конкретную дату
- Сохранять данные (какие дела запланированы)
- Выводить список дел за указанную дату (день недели)