using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Decorator {
    public abstract class IChat {
        public virtual string Author { get; }
        public virtual string Recipient { get; }
        public virtual string Text { get; }

        public virtual void sendMsg() { }
        public virtual string getMsg() { throw new NotImplementedException(); }
    }
    public class Facebook: IChat {
        public override string Author => "edu@xrm.ru";
        public override string Recipient => "ivanov@mail.ru";
        public override string Text => getMsg();

        public override void sendMsg() { Console.WriteLine(Text); }
        public override string getMsg() { return "Завтра занятия по курсу отменяются!"; }
    }
    public class Vk: IChat {
        public override string Author => "fti@urfu.ru";
        public override string Recipient => "ivanov@mail.ru";
        public override string Text => setMsg();

        public override void sendMsg() { Console.WriteLine("Отправка сообщения вконктакте..."); }
        public override string getMsg() { return ("!Непрочитанное сообщение!"); }
        public string setMsg() { return "Дорогие выпускники..."; }
    }
}
