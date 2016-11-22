using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Decorator {
    class Program {
        abstract class IDecorator: IChat {
            protected IChat chat;
            //public IDecorator(IChat c) { chat=c; }            // этот пример сделан ч/з метод SetEncrypt,                                                             
            public abstract IChat SetEncrypt(IChat ch);         // а не ч/з ctor
        }
        class EncryptMsg: IDecorator {
            //public EncryptMsg(IChat c) : base(c) { }
            public override IChat SetEncrypt(IChat ch) {
                chat=ch;
                sendMsg(chat.Text);
                return this;
            }
            public override string Author => chat.Author;
            public override string Recipient => chat.Recipient;
            public override string Text => getMsg();                //оборачиваем в теги
            string temp;

            public override void sendMsg(string msg) { temp="Шифровано {"+msg+"}"; }
            public override string getMsg() { return "Расшифровано {"+temp+"}"; }
        }
        class SecretName: IDecorator {
            public override IChat SetEncrypt(IChat ch) {
                chat=ch;
                IdAuthor=setIdName();
                IdRecipient=setIdRec();
                sendMsg(ch.Text);
                return this;
            }

            public override string Author => IdAuthor;
            public override string Recipient => IdRecipient;
            public override string Text => chat.getMsg();
            string IdAuthor, IdRecipient;

            public override void sendMsg(string msg) { IdAuthor="Id {"+IdAuthor+"}"; IdRecipient="Id {"+IdRecipient+"}"; }
            public override string getMsg() { return chat.getMsg(); } //текст не трогаем

            string setIdName() { int id = 1001; return id.ToString(); }
            string setIdRec() { int id = 1212; return id.ToString(); }
        }
        static void Main(string[] args) {
            //переделал, теперь у меня письмо шифруется в send(), а расшифровывается в get() 
            IChat chat2 = new Facebook();
            chat2=new EncryptMsg().SetEncrypt(chat2);
            Console.WriteLine($"Автор: {chat2.Author}\nАдресат: {chat2.Recipient}\nПисьмо: {chat2.Text}\n");

            IChat chat1 = new Vk();
            chat1=new SecretName().SetEncrypt(chat1);
            Console.WriteLine($"Автор: {chat1.Author}\nАдресат: {chat1.Recipient}\nПисьмо: {chat1.Text}\n");

            Console.Read();
        }
    }
}
