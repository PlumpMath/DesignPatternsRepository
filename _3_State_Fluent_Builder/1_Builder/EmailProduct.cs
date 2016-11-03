using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Builder {
    class EmailProduct {
        string topic, body;                                 //атрибуты письма

        List<string> recipients = new List<string>();

        public EmailProduct(string t = null, string b = null, List<string> recipients_ = null) {  //ctor
            topic=t;
            body=b;
            if (recipients_!=null)
                recipients.AddRange(recipients_);
        }

        public void show() {        //вывод письма
            Console.Write("Тема: "+topic+".\nСообщение: "+body+"\n"+"Кому: ");
            foreach (var el in recipients) {
                Console.Write(el+", ");
            }
            Console.WriteLine("\n");
        }
    }
}
