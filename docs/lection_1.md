# Лекция 1

### Использование коммментариев

Существует 2 типа комментариев:
- Стадартные комментарии
```
//hello world comment
```
- Xml-комментарии используются для автогенерации документации для библиотек классов, интерфейсов и т.д.([документация](https://docs.microsoft.com/en-us/dotnet/csharp/codedoc) )
 ```
/// <summary>
/// Adds two integers and returns the result.
/// </summary>
/// <returns>
/// The sum of two integers.
/// </returns>
public static int Add(int a, int b)
{
    // If any parameter is equal to the max value of an integer
    // and the other is greater than zero
    if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
        throw new System.OverflowException();

    return a + b;
}
 ```
 
### Типы данных

- **bool/Boolean** (System.Boolean)
- byte [0; 255] (System.Byte)
- sbyte
- short/Int16 [-128; 128] (System.Int16)
- ushort
- **int** 4 байта (System.Int32)
- long (System.Int64)
- ulong
- float (System.Single)
- **double** (System.Double) 8 байт
- decimal (System.Decimal) 16 байт. Используется в банковских проектах.
- **char** (System.Char) ‘s’
- **string** (System.String) “hello”
- **object** (System.Object)

### Типизация переменных

- явная (при явном указании типа данных):
```
int a = 5;
```

- неявная (при автоопределении типа данных):
```
var a = 5;
```

Рекомендуется использовать неявную типизацию при инициализации переменных, а явную - при использовании функций (см. пример) и при ограничении вычислительных ресурсов:
```
var a = 5; //  is equal to int a = 5;
int b = Method(); // int b = 5;

static int Method();
{ return 5; }
```

### Использование консоли

Console.Write(); // без перехода на новую строку
Console.WriteLine(); // с переходом на новую строку
Console.Read(); // чтение из консоли

```
// Enviroment.NewLine – использование параметров среды, так как на некоторых linux-ядра Console.WriteLine() может не работать.
Console.Write(Enviroment.NewLine + “string”) // is equal to Console.WriteLine("string");
```

### Приведение типов данных 

Преобразование прочитанных из консоли данных (String) к типу (Int32) 
```
int a = int.Parse(Console.ReadLine());
```

Попытка приведения к конкретному типу. В случае невозможности преобразования переменной будет присвоено стандартное значение 0.
```
int a = int.TryParse(Console.ReadLine(), out int UserInput); // return 0 by default
Console.WriteLine(UserInput); //
```

### Ссылочные и значимые типы данных

**Ссылочные** типы данных (reference type) (помещаются в кучу):
- object, 
- string, 
- class, 
- interface, 
- delegate.

**Значимые** (value type) (помещается в stack):
- int,
- double и т.д.(все оставшиеся)

Значимые создают объект, выделяют/резервируют память под него.
Ссылочные указывают на фрагмент памяти, но не резервируют память под объект.

### Модификаторы доступа

- public, 
- private,
- protected, 
- internal (типа `public` внутри конкретной сборки),
- internal protected, 
- private protected.

### Enum (перечисления)

Enum (значимый тип)
```
enum ErrorCodes : ushort
{
    Err1 = 1,
    Err2 = 5,
    Err3        // ErrorCodes.Err3 = 6
}
```

### Упаковка и распаковка переменных

Упаковка (boxing) и распаковка (unboxing) переменных при помощи класса object.
```
int i = 5;
object o = i;  	// boxing

o = 123;
i = (int) o; 	// unboxing 
```

Пример:
```
int i = 1;
object a = i;
a = 12;
//int = (double)a; // error
i = Convert.ToInt32((double)a); // ok
```

### Nullable

Используется при работе с базами данных.
```
int? a = null; // делает ссылочным объект типа int
```