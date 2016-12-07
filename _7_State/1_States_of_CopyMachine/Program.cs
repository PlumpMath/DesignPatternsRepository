using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_States_of_CopyMachine {
    class Program {
        static void Main(string[] args) {
            var machineContext = new CopyMachineContext(10);    //наверное тут лучше использовать StateBuilder
            //нормальная работа                                 //тогда легче конструировать, нужны будут try/catch                
            machineContext.ChooseDevice(new USB());
            machineContext.ChooseDocument("instruction.pdf");
            machineContext.PrintDocument();
            machineContext.getDelivery();
            Console.WriteLine("---------------------------");

            //ненормальная работа1
            try {
                machineContext.EnterMoney(5);
                machineContext.ChooseDevice(new WiFi());
                machineContext.ChooseDocument("Введение.docx");
                machineContext.PrintDocument();
                machineContext.getDelivery();
                Console.WriteLine("---------------------------");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            machineContext.EnterMoney(9);
            machineContext.ChooseDevice(new WiFi());
            machineContext.ChooseDocument("Введение.docx");
            machineContext.PrintDocument();
            machineContext.ChooseDocument("Заключение.docx");
            machineContext.PrintDocument();
            machineContext.getDelivery();
            machineContext.Run();
            Console.WriteLine("---------------------------");

            //ненормальная работа2
            try {
                machineContext.EnterMoney(7);
                machineContext.ChooseDevice(new USB());
                machineContext.ChooseDocument("Док1.docx");
                machineContext.PrintDocument();
                machineContext.ChooseDocument("Док2.docx");
                machineContext.PrintDocument();
                machineContext.getDelivery();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            machineContext.EnterMoney(7);
            machineContext.ChooseDevice(new USB());
            machineContext.ChooseDocument("Док2.docx");
            machineContext.PrintDocument();
            machineContext.getDelivery();

            Console.Read();
        }
    }
}
