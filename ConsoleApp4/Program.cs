/*Упражнение 4: Реализуйте класс Прямоугольник.
Поля класса: длина и ширина (закрытые).
Методы класса:
 конструктор по умолчанию (инициализирует поля класса значением 1);
 Set (double a, double b) – присваивает полям длина и ширина значения a и b
соответственно;
 вычисление площади;
 вычисление периметра;
 вывод информации о фигуре (длина, ширина, площадь и периметр) - используйте
интерполяцию строк.
В основной программе продемонстрируйте работу всех методов класса.*/

Rectangle abcd = new Rectangle();
abcd.Set(3.5, 4);
Console.WriteLine($"Площадь = {abcd.Square()}");
Console.WriteLine($"Периметр = {abcd.Perimetr()}");
abcd.GetInfo();

class Rectangle
{

    private double a;
    private double b;
    public Rectangle()
    {
        a = 1;
        b = 1;
    }
    public void Set(double a_, double b_)
    {
        a = a_;
        b = b_;
    }

    public double Square() => a*b;

    public double Perimetr() => a*2+b*2;

    public void GetInfo() => Console.WriteLine($"Сторона a = {a}; \nСторона b = {b}; \nПлощадь = {Square()}; \nПериметр = {Perimetr()};");
}



