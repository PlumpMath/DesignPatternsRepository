using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers.Abstract
{
    public abstract class ReportServiceTransformerBase : IDataTransformer                                   //Декоратор (базовый класс)
    {
        protected readonly IDataTransformer DataTransformer;

        protected ReportServiceTransformerBase(IDataTransformer dataTransformer)            
        {
            DataTransformer = dataTransformer;
        }

        public abstract Report TransformData(DataRow[] data);                                   //абстрактный метод для оборачивания (будет реализован в конкетных декораторах)
    }
}
