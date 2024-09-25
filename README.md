# GeometryLib

GeometryLib - это библиотека на C#, которая предоставляет возможность вычисления площадей различных геометрических фигур, таких как круги и треугольники. Библиотека поддерживает использование фабрики для динамического создания экземпляров фигур с использованием рефлексии и обеспечивает типобезопасность через интерфейсы и дженерики.

## Установка

1. Склонируйте или скачайте репозиторий:

   ```bash
   git clone https://github.com/yellow1cucumber/GeometryLib.git
   ```

2. Откройте проект в вашей любимой IDE (например, Visual Studio).

3. Скомпилируйте проект для создания библиотеки.

## Использование

### Основные классы и интерфейсы

- **`IShape`**: Интерфейс для всех фигур, определяет метод `GetArea()`.
- **`Circle`**: Класс для представления круга, реализующий `IShape`.
- **`Triangle`**: Класс для представления треугольника, реализующий `IShape`.
- **`ShapeFactory`**: Фабрика для создания экземпляров фигур, поддерживающая типизацию и рефлексию.

### Пример использования

#### Вычисление площади фигур

Пример использования для вычисления площади круга и треугольника:

```csharp
using Mindbox.GeometryLib;
using Mindbox.GeometryLib.Circle;
using Mindbox.GeometryLib.Triangle;

#region SHAPES_AREA

// Circle
IShape shape = new CircleImmutable(10);
var circleArea = shape.GetArea();
Console.WriteLine($"Circle area: {circleArea}");

// Triangle
IShape triangle = new TriangleImmutable(3, 4, 5);
var triangleArea = triangle.GetArea();
Console.WriteLine($"Triangle area: {triangleArea}");

/*
Output:
Circle area: 314.1592653589793
Triangle area: 6
*/

#endregion
```

#### Проверка на прямоугольность треугольника

Пример использования для проверки, является ли треугольник прямоугольным:

```csharp
#region RIGHT_TRIANGLE

var rightTriangle = new TriangleImmutable(3, 4, 5);
var notRightTriangle = new TriangleImmutable(3);

Console.WriteLine($"Is triangle with 3,4,5 right: {rightTriangle.IsRightTriangle()}");
Console.WriteLine($"Is triangle with 3,3,3 right: {notRightTriangle.IsRightTriangle()}");

/*
Output:
Is triangle with 3,4,5 right: True
Is triangle with 3,3,3 right: False
*/

#endregion
```

#### Использование мутабельного круга

Пример использования мутабельного круга с подпиской на события изменения:

```csharp
#region MUTABLE

CircleMutable mutableCircle = new CircleMutable(10);
mutableCircle.onChanges += () => {
    Console.WriteLine("Radius and area changed"); 
};

var mutableCircleArea = mutableCircle.GetArea();
Console.WriteLine($"Area before changes: {mutableCircle.GetArea()}");

mutableCircle.SetRadius(5);
Console.WriteLine($"Area after changes: {mutableCircle.Area}");

/*
Output:
Area before changes: 314.1592653589793
Radius and area changed
Area after changes: 78.53981633974483
*/

#endregion
```

#### Использование фабрики для создания фигур

Пример использования фабрики для создания множества треугольников с использованием рефлексии:

```csharp
#region FACTORY

var trianglesInfo = new object[][]
{
    [3, 4, 5],
    [6, 7, 8],
    [9, 10, 11],
    [11, 12, 13],
};

IEnumerable<TriangleAbstract> triangles = ShapeFactory.CreateShapes<TriangleImmutable>(trianglesInfo);
foreach(var tr in triangles)
{
    Console.WriteLine($"Triangle area with sides a={tr.SideA}, b={tr.SideB}, c={tr.SideC} = {tr.GetArea()}");
}

/*
Output:
Triangle area with sides a=3, b=4, c=5 = 6
Triangle area with sides a=6, b=7, c=8 = 20.33316256758894
Triangle area with sides a=9, b=10, c=11 = 42.42640687119285
Triangle area with sides a=11, b=12, c=13 = 61.48170459575759
*/

#endregion
```

### Юнит-тесты

В библиотеке реализованы юнит-тесты для проверки корректности вычислений площадей фигур и работы фабрики.

- **`MutableCircleAreaTest`**: Тест для проверки вычисления площади мутабельного круга.
- **`ShapeFactoryTests`**: Тесты для проверки работы фабрики с разными фигурами.

### Как добавить новые фигуры

Чтобы добавить новую фигуру:

1. Создайте класс, реализующий интерфейс `IShape`.
2. Реализуйте метод `GetArea()`.

### Зависимости

- .NET 8.0
