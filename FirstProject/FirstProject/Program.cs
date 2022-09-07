/*
1. Создать класс Point (содержит две координаты типа int X и Y), конструктор для инициализации этих полей
Создать классы для Прямоугольника (две точки), Треугольника (три точки), Круга (точка центра и радиус) ??
Реализовать для каждого класса метод double GetArea(), вычисляющий площадь
Создать по два объекта для классов Прямоугольник, Треугольник, Круг с произвольными
значениями, ссылки на объекты разместить в едином массиве размеров на 6 элементов
Вычислить и вывести на консоль суммарную площадь этих фигур

2. Добавить ограничения в код классов Circle и Rectangle, чтобы нельзя было создать
окружность, если хотя бы одна координата центра отрицательная, и нельзя создать
прямоугольник, если хотя бы одна его сторона длиной больше 10. При попытке создать
невалидную окружность или прямоугольник выбрасывать исключение

3. Добавить в геометрические фигуры информацию для их отрисовки- цвет, толщина и тип линии
Написать метод, принимающий массив фигур и возвращающий отфильтрованный массив фигур, содержащий фигуры
только заданного цвета и толщины линии

4.Пока для коллекции фигур перейди от использования массива к использованию списка (List)
И введи ограничение на создание треугольника- пусть конструктор выбрасывает исключение если 
не существует треугольника с заданными вершинами



*/
using System;

namespace FirstProject
{
    class Program
    {
        public static List<Shape> FilterList(List<Shape> list, string color, int thickness) //type?
        {

            var filterColor = list.Where(a => a.ShapeLine.Color == color);
            var filterThickness = list.Where(a => a.ShapeLine.Thickness == thickness);
            return filterColor.Intersect(filterThickness).ToList<Shape>();

            /*
            foreach (Shape i in array)
            {
                if (i.ShapeLine.Color == "red" & i.ShapeLine.Thickness == 3)
                {
                    return i;
                }

            }
            */
        }

        static void Main(string[] args)
        {

            Circle circle1;
            Circle circle2;
            Rectangle rectangle1;
            Rectangle rectangle2;
            Triangle triangle1;
            Triangle triangle2;

            try
            {
                Point trianglePoint1 = new Point(1, 1);
                Point trianglePoint2 = new Point(4, 1);
                Point trianglePoint3 = new Point(2, 4);
                Line triangleLine = new Line("red", "dotted", 3);
                triangle1 = new Triangle(trianglePoint1, trianglePoint2, trianglePoint3, triangleLine);
                triangle2 = new Triangle(trianglePoint1, trianglePoint2, trianglePoint3, triangleLine);


                Point circlePoint = new Point(6, 2);
                Line circleLine = new Line("blue", "defalut", 5);
                circle1 = new Circle(circlePoint, 10, circleLine);
                circle2 = new Circle(circlePoint, 2, circleLine);


                Point rectanglePoint1 = new Point(5, 4);
                Point rectanglePoint2 = new Point(7, 6);
                Line rectangleLine = new Line("green", "defalut", 2);
                rectangle1 = new Rectangle(rectanglePoint1, rectanglePoint2, rectangleLine);
                rectangle2 = new Rectangle(rectanglePoint1, rectanglePoint2, rectangleLine);

                /*
                Shape[] array = new Shape[6];
                array[0] = triangle1;
                array[1] = triangle2;
                array[2] = rectangle1;
                array[3] = rectangle2;
                array[4] = circle1;
                array[5] = circle2;
                */

                List<Shape> shapeList = new List<Shape>(5);
                shapeList.Add(triangle1);
                shapeList.Add(triangle2);
                shapeList.Add(rectangle1);
                shapeList.Add(rectangle2);
                shapeList.Add(circle1);
                shapeList.Add(circle2);

                List<Shape> newList = new List<Shape>();
                newList = FilterList(shapeList, "red", 3);
                for (int i = 0; i < newList.Count; i++)
                {
                    System.Console.WriteLine(newList[i].ShapeLine.Color);

                }


                double sum = 0;
                for (int i = 0; i < shapeList.Count; i++)
                {
                    sum += shapeList[i].GetArea();
                    System.Console.WriteLine(sum);
                }
            }

            catch (ArgumentException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
