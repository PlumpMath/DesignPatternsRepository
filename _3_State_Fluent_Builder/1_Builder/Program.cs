using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Builder {
    class Program {

        static void Main(string[] args) {

            //все конструируемые объекты заканчиваются методом getRes()
            var urfuEmail = new EmailBuilder()
                .addTopic("Вручение дипломов")
                .addBody("Дорогие выпускники...")
                .addRecipients(new List<string> { "imkn@urfu.ru", "fti@urfu.ru" })
                .getRes();
            urfuEmail.show();

            var college_begin = new EmailBuilder()      //начало конструирования письма
                .addTopic("Поступление 2017");
            var college_end = college_begin.addBody("Дорогие первокурсники...") //конец конструирования
                .addRecipients(new List<string> { "first@mail.ru", "second@mail.ru" })
                .getRes();
            college_end.show();

            var urgpu = new EmailBuilder.BodyBuilder().addRecipients(new List<string> { "history@urgpu.ru", "psycology@urgpu.ru" })
                .getRes();
            urgpu.show();

            var smth = new EmailBuilder()
                .addTopic("theme")
                .getRes();
            smth.show();

            Console.Read();
        }
    }
}
