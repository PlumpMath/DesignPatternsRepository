using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Visitor {
    interface IVisitor {
        void VisitRectangle(Rectangle r);
        void VisitTriangle(Triangle t);
        void VisitCircle(Circle c);
    }
    class DrawVis: IVisitor {
        public void VisitCircle(Circle c) {
            int temp = c.radius*2;
            for (int i = 0; i<c.radius*2; i++) {
                for (int j = 0; j<c.radius*2; j++) {
                    if (i==0&&j==0||i==0&&j==temp-1||i==temp-1&&j==0||i==temp-1&&j==temp-1) { Console.Write(" "); }
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void VisitRectangle(Rectangle r) {
            for (int i = 0; i<r.lenght; i++) {
                for (int j = 0; j<r.width; j++) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public void VisitTriangle(Triangle t) {
            for (int i = 0; i<t.lenght; i++) {
                for (int j = 0; j<i+1; j++) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
    class GetAreaVis: IVisitor {
        public void VisitCircle(Circle c) { Console.WriteLine($"Площадь {c.Name}'a: {c.radius*c.radius*Math.PI} усл.ед."); }
        public void VisitRectangle(Rectangle r) { Console.WriteLine($"Площадь {r.Name}'a: {r.lenght*r.width} усл.ед."); }
        public void VisitTriangle(Triangle t) { Console.WriteLine($"Площадь {t.Name}'a: {t.lenght*t.height/2} усл.ед."); }
    }
    class ColorVis: IVisitor {
        public void VisitCircle(Circle c) {
            Console.ForegroundColor=ConsoleColor.Blue;
            Console.WriteLine($"{c.Name}");
            Console.ResetColor();
        }
        public void VisitRectangle(Rectangle r) {
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine($"{r.Name}");
            Console.ResetColor();
        }
        public void VisitTriangle(Triangle t) {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine($"{t.Name}");
            Console.ResetColor();
        }
    }
}
