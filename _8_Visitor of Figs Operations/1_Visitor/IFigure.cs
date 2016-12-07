using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Visitor {
    interface IFigure {
        string Name { get; }
        void Accept(IVisitor visitor);
    }
    class Rectangle: IFigure {
        public int lenght { get { return 2; } }
        public int width { get { return 2; } }
        public string Name => "Прямоугольник";

        public void Accept(IVisitor visitor) { visitor.VisitRectangle(this); }
    }
    class Triangle: IFigure {
        public int lenght { get { return 4; } }
        public int height { get { return 5; } }
        public string Name => "Треугольник";

        public void Accept(IVisitor visitor) { visitor.VisitTriangle(this); }
    }
    class Circle: IFigure {
        public int radius { get { return 3; } }
        public string Name => "Круг";

        public void Accept(IVisitor visitor) { visitor.VisitCircle(this); }
    }
}
