using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_States_of_CopyMachine {
    public interface IDevice { string type { get; } }
    public class USB: IDevice { public string type => "usb"; }
    public class WiFi: IDevice { public string type => "wifi"; }

    public class CopyMachineContext {
        public IState state { get; set; }
        public IDevice device { get; set; }
        public string DocName { get; set; }
        public int money { get; set; }
        public CopyMachineContext(int sum) {
            money=sum;
            Console.WriteLine($"===Стоимость печати 7$ за документ===");
            Console.WriteLine($"Вносим деньги {money} $");
            state=new EnterMoneyState();
        }
        public void EnterMoney(int sum) {
            money+=sum;
            state.EnterMoney(this);
        }
        public void ChooseDevice(IDevice d) {
            device=d;
            state.ChooseDevice(this);
        }
        public void ChooseDocument(string doc) {
            DocName=doc;
            state.ChooseDocument(this);
        }
        public void PrintDocument() {
            state.PrintDocument(this);
        }
        public int getDelivery() {
            return state.getDelivery(this);
        }
        public void Run() {
            state.Run(this);
        }
    }
}
