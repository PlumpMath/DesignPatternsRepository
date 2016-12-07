using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_ {
    class Program {
        public class Bancomat {
            private readonly BanknoteHandler _handler;

            public Bancomat(IBanknote banknote) {
                if (banknote is Dollar) {
                    _handler=new OneDollarHandler(null);                // 1
                    _handler=new TwoDollarHandler(_handler);            // 2
                    _handler=new FiveDollarHandler(_handler);           // 5
                    _handler=new TenDollarHandler(_handler);            // 10
                    _handler=new TwentyDollarHandler(_handler);         // 20
                    _handler=new FiftyDollarHandler(_handler);          // 50
                    _handler=new HundredDollarHandler(_handler);        // 100
                }
                else if (banknote is Euro) {
                    _handler=new FiveEuroHandler(null);                 // 5
                    _handler=new TenEuroHandler(_handler);              // 10
                    _handler=new TwentyEuroHandler(_handler);           // 20
                    _handler=new FiftyEuroHandler(_handler);            // 50
                    _handler=new HundredEuroHandler(_handler);          // 100
                    _handler=new TwoHundredEuroHandler(_handler);       // 200
                    _handler=new FiveHundredEuroHandler(_handler);      // 500
                }
                else if (banknote is Ruble) {
                    _handler=new TenRubleHandler(null);                    // 10
                    _handler=new FiftyRubleHandler(_handler);              // 50
                    _handler=new HundredRubleHandler(_handler);            // 100
                    _handler=new FiveHundredRubleHandler(_handler);        // 500
                    _handler=new ThousandDRubleHandler(_handler);          // 1000
                    _handler=new FiveThousandRubleHandler(_handler);       // 5000
                }
            }
            public bool Validate(IBanknote banknote) {
                Console.Write($"{banknote.value_} {banknote.sign} =");
                return _handler.Validate(banknote);
            }
        }
        static void Main(string[] args) {
            var dollars = new Dollar("10");            // хотим снять доллары
            var bankomat = new Bancomat(dollars);      // выбираем эту сумму в банкомате
            bankomat.Validate(dollars);                //проверяем

            var rubs = new Ruble("10");                 // тест: 1050, 2033, 1, 10, 11   
            var bankomat2 = new Bancomat(rubs);
            bankomat2.Validate(rubs);

            var euros = new Euro("10");
            var bankomat3 = new Bancomat(euros);
            bankomat3.Validate(euros);

            Console.Read();
        }
        /* рубли (7 купюр): 10, 50, 100, 500, 1000, 5000
        * доллары (7 купюр): 1, 2, 5, 10, 20, 50, 100
        * евро (7 купюр): 5, 10, 20, 50, 100, 200, 500
        */

    }
}
