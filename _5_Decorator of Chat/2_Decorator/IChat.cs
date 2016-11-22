using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Decorator {
    #region Компоненты
    public abstract class IChat {
        public virtual string Author { get; }
        public virtual string Recipient { get; }
        public virtual string Text { get; }

        public virtual void sendMsg(string msg) { }
        public virtual string getMsg() { throw new NotImplementedException(); }
    }
    public class Facebook: IChat {
        public override string Author => "edu@xrm.ru";
        public override string Recipient => "ivanov@mail.ru";
        public override string Text => getMsg();

        public override void sendMsg(string msg) { }
        public override string getMsg() { return "Завтра занятия по курсу отменяются!"; }
    }
    public class Vk: IChat {
        public override string Author => "fti@urfu.ru";
        public override string Recipient => "ivanov@mail.ru";
        public override string Text => getMsg();

        public override void sendMsg(string msg) { }
        public override string getMsg() { return ("Дорогие выпускники..."); }
    }
    #endregion
}
