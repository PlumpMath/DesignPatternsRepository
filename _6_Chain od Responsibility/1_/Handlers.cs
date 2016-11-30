using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_ {
    #region Banknote
    public enum CurrencyType { Eur, Dollar, Rub }
    public abstract class IBanknote {
        public abstract CurrencyType Currency { get; }
        public abstract string sign { get; }
        public abstract string value_ { get; }
    }
    public class Dollar: IBanknote {
        public override CurrencyType Currency => CurrencyType.Dollar;
        public override string sign => "$";
        public override string value_ { get; }

        public Dollar(string v) { value_=v; }
    }
    public class Euro: IBanknote {
        public override CurrencyType Currency => CurrencyType.Eur;
        public override string sign => "euro";
        public override string value_ { get; }

        public Euro(string v) { value_=v; }
    }
    public class Ruble: IBanknote {
        public override CurrencyType Currency => CurrencyType.Rub;
        public override string sign => "руб";
        public override string value_ { get; }

        public Ruble(string v) { value_=v; }
    }
    #endregion

    public abstract class BanknoteHandler {
        private readonly BanknoteHandler _nextHandler;

        protected BanknoteHandler(BanknoteHandler nextHandler) { _nextHandler=nextHandler; }

        public virtual bool Validate(IBanknote banknote) {
            if (_nextHandler!=null&&_nextHandler.Validate(banknote)) {
                return true;
            }
            else {
                if (_nextHandler==null)
                    Console.WriteLine();
                return false;
            }
        }
    }

    #region Ruble Handlers
    public abstract class RubleHandlerBase: BanknoteHandler {
        public override bool Validate(IBanknote banknote) {
            int money;
            if (!(Int32.TryParse(banknote.value_, out money)))
                Console.WriteLine("Введите число.");
            int cnt = (money/Value);

            if (cnt!=0) {
                getMoney(cnt);
                money=money-Value*cnt;
                if (money>=10||money!=0)
                    Console.Write(" +");
            }
            if (money<10&&money!=0) {
                Console.WriteLine(" "+money.ToString()+" не валидная сумма =(");
                return false;
            }
            return base.Validate(new Ruble(money.ToString()));
        }
        protected abstract int Value { get; }
        protected RubleHandlerBase(BanknoteHandler nextHandler) : base(nextHandler) { }
        public abstract void getMoney(int count);
    }

    public class FiveThousandRubleHandler: RubleHandlerBase {
        public FiveThousandRubleHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 5000;
        public override void getMoney(int count) { Console.Write(" 5000"); if (count>1) Console.Write("x"+count); }
    }

    public class ThousandDRubleHandler: RubleHandlerBase {
        public ThousandDRubleHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 1000;
        public override void getMoney(int count) { Console.Write(" 1000"); if (count>1) Console.Write("x"+count); }
    }

    public class FiveHundredRubleHandler: RubleHandlerBase {
        public FiveHundredRubleHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 500;
        public override void getMoney(int count) { Console.Write(" 500"); if (count>1) Console.Write("x"+count); }
    }

    public class HundredRubleHandler: RubleHandlerBase {
        public HundredRubleHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 100;
        public override void getMoney(int count) { Console.Write(" 100"); if (count>1) Console.Write("x"+count); }
    }

    public class FiftyRubleHandler: RubleHandlerBase {
        public FiftyRubleHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 50;
        public override void getMoney(int count) { Console.Write(" 50"); if (count>1) Console.Write("x"+count); }
    }

    public class TenRubleHandler: RubleHandlerBase {
        public TenRubleHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 10;
        public override void getMoney(int count) { Console.Write(" 10"); if (count>1) Console.Write("x"+count); }
    }
    #endregion

    #region Dollar Handlers
    public abstract class DollarHandlerBase: BanknoteHandler {
        public override bool Validate(IBanknote banknote) {
            int money;
            if (!(Int32.TryParse(banknote.value_, out money))&&money>0)
                Console.WriteLine("Введите число.");
            int cnt = (money/Value);

            if (cnt!=0) {
                getMoney(cnt);
                money=money-Value*cnt;
                if (money!=0)
                    Console.Write(" +");
            }
            return base.Validate(new Dollar(money.ToString()));
        }
        protected abstract int Value { get; }
        protected DollarHandlerBase(BanknoteHandler nextHandler) : base(nextHandler) { }
        public abstract void getMoney(int count);
    }

    public class HundredDollarHandler: DollarHandlerBase {
        public HundredDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 100;
        public override void getMoney(int count) { Console.Write(" 100"); if (count>1) Console.Write("x"+count); }
    }

    public class FiftyDollarHandler: DollarHandlerBase {
        public FiftyDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 50;
        public override void getMoney(int count) { Console.Write(" 50"); if (count>1) Console.Write("x"+count); }
    }

    public class TwentyDollarHandler: DollarHandlerBase {
        public TwentyDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 20;
        public override void getMoney(int count) { Console.Write(" 20"); if (count>1) Console.Write("x"+count); }
    }

    public class TenDollarHandler: DollarHandlerBase {
        public TenDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 10;
        public override void getMoney(int count) { Console.Write(" 10"); if (count>1) Console.Write("x"+count); }
    }

    public class FiveDollarHandler: DollarHandlerBase {
        public FiveDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 5;
        public override void getMoney(int count) { Console.Write(" 5"); if (count>1) Console.Write("x"+count); }
    }

    public class TwoDollarHandler: DollarHandlerBase {
        public TwoDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 2;
        public override void getMoney(int count) { Console.Write(" 2"); if (count>1) Console.Write("x"+count); }
    }

    public class OneDollarHandler: DollarHandlerBase {
        public OneDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 1;
        public override void getMoney(int count) { Console.Write(" 1"); if (count>1) Console.Write("x"+count); }
    }
    #endregion

    #region Euro Handlers
    public abstract class EuroHandlerBase: BanknoteHandler {
        public override bool Validate(IBanknote banknote) {
            int money;
            if (!(Int32.TryParse(banknote.value_, out money)))
                Console.WriteLine("Введите число.");
            int cnt = (money/Value);

            if (cnt!=0) {
                getMoney(cnt);
                money=money-Value*cnt;
                if (money>=10||money!=0)
                    Console.Write(" +");
            }
            if (money<5&&money!=0) {
                Console.WriteLine(" "+money.ToString()+" не валидная сумма =(");
                return false;
            }
            return base.Validate(new Euro(money.ToString()));
        }
        protected abstract int Value { get; }
        protected EuroHandlerBase(BanknoteHandler nextHandler) : base(nextHandler) { }
        public abstract void getMoney(int count);
    }

    public class FiveHundredEuroHandler: EuroHandlerBase {
        public FiveHundredEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 500;
        public override void getMoney(int count) { Console.Write(" 500"); if (count>1) Console.Write("x"+count); }
    }

    public class TwoHundredEuroHandler: EuroHandlerBase {
        public TwoHundredEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 200;
        public override void getMoney(int count) { Console.Write(" 200"); if (count>1) Console.Write("x"+count); }
    }

    public class HundredEuroHandler: EuroHandlerBase {
        public HundredEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 100;
        public override void getMoney(int count) { Console.Write(" 100"); if (count>1) Console.Write("x"+count); }
    }

    public class FiftyEuroHandler: EuroHandlerBase {
        public FiftyEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 50;
        public override void getMoney(int count) { Console.Write(" 50"); if (count>1) Console.Write("x"+count); }
    }

    public class TwentyEuroHandler: EuroHandlerBase {
        public TwentyEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 20;
        public override void getMoney(int count) { Console.Write(" 20"); if (count>1) Console.Write("x"+count); }
    }

    public class TenEuroHandler: EuroHandlerBase {
        public TenEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 10;
        public override void getMoney(int count) { Console.Write(" 10"); if (count>1) Console.Write("x"+count); }
    }

    public class FiveEuroHandler: EuroHandlerBase {
        public FiveEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) { }

        protected override int Value => 5;
        public override void getMoney(int count) { Console.Write(" 5"); if (count>1) Console.Write("x"+count); }
    }
    #endregion
}
