using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_States_of_CopyMachine {
    public interface IState {
        void EnterMoney(CopyMachineContext c);
        void ChooseDevice(CopyMachineContext c);
        void ChooseDocument(CopyMachineContext c);
        void PrintDocument(CopyMachineContext c);
        int getDelivery(CopyMachineContext c);
        void Run(CopyMachineContext c);
    }
    public abstract class StateBase: IState {
        public virtual void EnterMoney(CopyMachineContext c) {
            Console.WriteLine($"Вносим. Текущая сумма {c.money}$");
            c.state=new DeviceState();
        }
        public virtual void Run(CopyMachineContext c) {
            Console.WriteLine($"Срочно убегаем! Оставляем все!");
            c.money=0;
            c.DocName="";
            c.device=null;
            c.state=new RunState();
        }
        public abstract void ChooseDevice(CopyMachineContext c);
        public abstract void ChooseDocument(CopyMachineContext c);
        public abstract void PrintDocument(CopyMachineContext c);
        public abstract int getDelivery(CopyMachineContext c);
    }
    public class EnterMoneyState: StateBase {
        public override void ChooseDevice(CopyMachineContext c) {
            Console.WriteLine($"Выбираем устройство {c.device.type}");
            if (c.money<7)
                Console.WriteLine($"Недостаточно средств! Нужно еще {7-c.money} $");
            else
                c.state=new DeviceState();
        }
        public override void ChooseDocument(CopyMachineContext c) { throw new Exception("Error!"); }
        public override void PrintDocument(CopyMachineContext c) { throw new Exception("Error! "); }
        public override int getDelivery(CopyMachineContext c) { throw new Exception("Error!"); }
    }

    public class DeviceState: StateBase {
        public override void ChooseDevice(CopyMachineContext c) { }
        public override void ChooseDocument(CopyMachineContext c) {
            Console.WriteLine($"Выбираем документ {c.DocName}");
            c.state=new DocumentState();
        }
        public override void PrintDocument(CopyMachineContext c) { throw new Exception("Error! Не выбран документ!"); }
        public override int getDelivery(CopyMachineContext c) { throw new Exception("Error! Не выбран документ!"); }
    }
    public class DocumentState: StateBase {
        public override void ChooseDevice(CopyMachineContext c) { throw new Exception("Error! Уже выбран документ!"); }
        public override void ChooseDocument(CopyMachineContext c) { }

        public override void PrintDocument(CopyMachineContext c) {
            if (c.money!=0) {
                c.money=c.money-7;
                Console.WriteLine($"Печатаем документ {c.DocName}");
                c.state=new PrintState();
            }
            else {
                c.state=new RunState();
                throw new Exception("Не хватает средств!");
            }
        }
        public override int getDelivery(CopyMachineContext c) { throw new Exception("Error! Уже выбран документ!"); }
    }
    public class PrintState: StateBase {
        public override void ChooseDevice(CopyMachineContext c) { Console.WriteLine("Подождите, печатается документ..."); }
        public override void ChooseDocument(CopyMachineContext c) {
            Console.WriteLine($"Выбираем документ {c.DocName}");
            c.state=new DocumentState();
        }
        public override void PrintDocument(CopyMachineContext c) { Console.WriteLine("Подождите, печатается документ..."); }
        public override int getDelivery(CopyMachineContext c) {
            Console.WriteLine($"Получаем сдачу ({c.money}$) и уходим");
            c.money=0;
            c.device=null;
            c.state=new RunState();
            return c.money;
        }
    }
    public class RunState: StateBase {
        public override void EnterMoney(CopyMachineContext c) {
            Console.WriteLine($"Вносим деньги ({c.money}) для копирования");
            c.state=new EnterMoneyState();
        }
        public override void ChooseDevice(CopyMachineContext c) { throw new Exception("Бежим куда то"); }
        public override void ChooseDocument(CopyMachineContext c) { throw new Exception("Бежим куда то"); }
        public override int getDelivery(CopyMachineContext c) { throw new Exception("Бежим куда то"); }
        public override void PrintDocument(CopyMachineContext c) { throw new Exception("Бежим куда то"); }
        public override void Run(CopyMachineContext c) { Console.WriteLine("..."); }
    }
}
