using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Interfaces
{
    public interface IDataTransformer                   //компонент паттерна Декоратор
    {                                                  //(это не может быть интерфейс Посредника)
        Report TransformData(DataRow[] data);
    }
}