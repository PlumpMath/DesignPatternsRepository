using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Decorator {
    class Program {
        abstract class IDecorator: IChat {
            protected IChat chat;
            public IDecorator(IChat c) { chat=c; }
        }
        //согласно заданию нужен конкретный Декоратор по шифровке/расшифровке сообщения, т.е. поля Text
        class EncrypMsg: IDecorator {
            public EncrypMsg(IChat c) : base(c) { }

            public override string Author => chat.Author;
            public override string Recipient => chat.Recipient;
            public override string Text => getMsg();

            public override void sendMsg() { Console.WriteLine(Text); }
            public override string getMsg() {
                StringBuilder encrypt = new StringBuilder(chat.getMsg());
                int hash = 7;
                for (int i = 0; i<encrypt.Length; i++) { encrypt[i]=(char)(encrypt[i]^hash); }  //XOR взаимообратен

                return encrypt.ToString();
            }
        }
        //согласно заданию нужен конкретный Декоратор по сокрытию пользователей, про раскрытие не говорится
        class SecretName: IDecorator {
            public SecretName(IChat c) : base(c) { }

            public override string Author => "Id {"+setIdName()+"}";
            public override string Recipient => "Id {"+setIdRec()+"}";
            public override string Text => chat.Text;

            public override void sendMsg() { chat.sendMsg(); }
            public override string getMsg() { return chat.getMsg(); }
            public string setIdName() {
                int id = 1001;
                return id.ToString();
            }
            public string setIdRec() {
                int id = 1212;
                return id.ToString();
            }
        }
        static void Main(string[] args) {
            IChat chat1 = new Vk();
            chat1=new SecretName(chat1);
            Console.WriteLine($"Автор: {chat1.Author}\nАдресат: {chat1.Recipient}\nПисьмо: {chat1.Text}\n");

            IChat chat2 = new Facebook();
            Console.WriteLine($"До шифрования сообщения:\nАвтор: {chat2.Author}\nАдресат: {chat2.Recipient}\nПисьмо: {chat2.getMsg()}\n");
            chat2=new EncrypMsg(chat2);
            Console.WriteLine($"После шифрования сообщения:\nАвтор: {chat2.Author}\nАдресат: {chat2.Recipient}\nПисьмо: {chat2.getMsg()}\n");
            chat2=new EncrypMsg(chat2);
            Console.WriteLine($"После расшифровки сообщения:\nАвтор: {chat2.Author}\nАдресат: {chat2.Recipient}\nПисьмо: {chat2.getMsg()}\n");

            //я так понимаю, что конструкция 'chat2=new EncrypMsg(chat2)' должна быть взаимообратной:
            //1ое "оборачивание" шифрует, 2ое - расшифровывает

            Console.Read();
        }
    }
}
