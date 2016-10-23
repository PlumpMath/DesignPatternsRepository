using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AF {
    class Program {
        public class Client1 {
            IBody body_;
            ICabin cabin_;
            IChassis chassis_;
            IEngine engine_;
            public Client1(IAutoFactory factory_) {
                body_=factory_.CreateIBody();
                cabin_=factory_.CreateICabin();
                chassis_=factory_.CreateIChassis();
                engine_=factory_.CreateIEngine();
            }
            public void makePhoto() {
                Console.WriteLine("Делаем фото на фоне кузова "+
                           body_.Name+" и кабины "+cabin_.Name);
            }
            public void goRepair() {
                Console.WriteLine("Едем чинить шасси "+
                chassis_.Name+" и двигатель "+engine_.Name);
            }
        }
        static void Main(string[] args) {
            var audi = new AUDIFactory();
            Conveyor(audi);

            var bmw = new BMWFactory();
            Conveyor(bmw);


            var audi_car = new AUDIFactory();
            var c1 = new Client1(audi_car);
            c1.makePhoto();
            c1.goRepair();

            Console.Read();
        }
        public static void Conveyor(IAutoFactory factory) {
            Console.WriteLine("=== Ковейер автомобильный ===");
            var body = factory.CreateIBody();
            var cabin = factory.CreateICabin();
            var engine = factory.CreateIEngine();
            var chassis = factory.CreateIChassis();

            Console.WriteLine($"Создан кузов: {body.Name}");
            Console.WriteLine($"Создана кабина: {cabin.Name}");
            Console.WriteLine($"Создан двигатель: {engine.Name}");
            Console.WriteLine($"Созданы шасси: {chassis.Name}");

            Console.WriteLine();
        }
    }
}
