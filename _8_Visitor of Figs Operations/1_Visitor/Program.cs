using System;
using System.Collections.Generic;
/*Необходимо реализовать простейшую иерархию фигур, 
 * (Прямоугольник, треугольник и любую фигуру на ваш выбор). 
 * Для данной иерархии реализовать паттерн посетитель с операциями:
 * Draw(int x, int y) 
 * GetArea()
 * Color()
 */

namespace _1_Visitor {
    class Program {
        class GeometryStructure {       //некая структура
            List<IFigure> figures = new List<IFigure>();
            public void Add(params IFigure[] f) { figures.AddRange(f); }
            public void Remove(IFigure f) { figures.Remove(f); }

            public void Accept(IVisitor visitor) {
                foreach(var fig in figures) 
                    fig.Accept(visitor);
                Console.WriteLine();
            }
        }
        static void Main(string[] args) {
            //var figues = new IFigure[] { new Circle(), new Rectangle(), new Triangle() };
            IFigure[] figures = {
                new Circle(),
                new Rectangle(),
                new Triangle()
            };

            foreach (var figure in figures) {
                figure.Accept(new ColorVis());
                figure.Accept(new GetAreaVis());
                figure.Accept(new DrawVis());

                Console.WriteLine();
            }

            var structure = new GeometryStructure();
            structure.Add(new Rectangle(), new Rectangle(), new Rectangle(), new Rectangle());
            structure.Accept(new GetAreaVis());

            Console.Read();
        }
    }
}
