using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AF {
    #region Interfaces
    public interface IAutoFactory {
        IBody CreateIBody();
        IEngine CreateIEngine();
        ICabin CreateICabin();
        IChassis CreateIChassis();
    }
    public interface IBody {    //кузов
        string Name { get; }
    }
    public interface IEngine {  //двигатель
        string Name { get; }
    }
    public interface ICabin {   //салон
        string Name { get; }
    }
    public interface IChassis { //шасси
        string Name { get; }
    }
    #endregion

    #region CarBMW
    public class BMWFactory: IAutoFactory {
        public IBody CreateIBody() {
            return new Sedan();
        }
        public IEngine CreateIEngine() {
            return new Diesel();
        }
        public ICabin CreateICabin() {
            return new Leather();
        }
        public IChassis CreateIChassis() {
            return new Adaptive();
        }
    }
    public class Sedan: IBody {
        public string Name => "Седан - закрытый кузов";
    }
    public class Diesel: IEngine {
        public string Name => "Дизельный";
    }
    public class Leather: ICabin {
        public string Name => "Натуральная кожа";
    }
    public class Adaptive: IChassis {
        public string Name => "Адаптивная ходовая часть";
    }
    #endregion

    #region CarAUDI
    public class AUDIFactory: IAutoFactory {
        public IBody CreateIBody() {
            return new Cabriolet();
        }
        public IEngine CreateIEngine() {
            return new Einspritzung();
        }
        public ICabin CreateICabin() {
            return new Plastic();
        }
        public IChassis CreateIChassis() {
            return new M_Type();
        }
    }
    public class Cabriolet: IBody {
        public string Name => "Кабриолет - открытый кузов";
    }
    public class Einspritzung: IEngine {
        public string Name => "Инжекторный";
    }
    public class Plastic: ICabin {
        public string Name => "Элитный пластик";
    }
    public class M_Type: IChassis {
        public string Name => "ходовая часть М-типа";
    }
    #endregion
}
