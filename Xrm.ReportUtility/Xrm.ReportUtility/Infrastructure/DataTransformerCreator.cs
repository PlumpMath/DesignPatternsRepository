using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator                                  //лучше сделать Singleton (чтобы создать объект, только при его необходимости), а также это даст возможность для расширения!
    {                                                                           //видим Посредника, который отделил объекты друг от друга, и содержит всю логику системы
        public static IDataTransformer CreateTransformer(ReportConfig config)       
        {
            IDataTransformer service = new DataTransformer(config);

            if (config.WithData)                                            //вместо цеопчик If, лучше использовать цепочку обязанностей - Chain of Responsibility
            {
                service = new WithDataReportTransformer(service);           //причем тут можно использовать также и БИлдер,
            }                                                               // например StateBuilder, чтобы конструировать объект            
                                                                            // по частям в этом месте
            if (config.VolumeSum)
            {
                service = new VolumeSumReportTransformer(service);          //также тут мы наблюдаем некий фасад, который предсавляет простой интерфейс к сложной подсистеме
            }

            if (config.WeightSum)
            {
                service = new WeightSumReportTransfomer(service);
            }

            if (config.CostSum)
            {
                service = new CostSumReportTransformer(service);
            }

            if (config.CountSum)
            {
                service = new CountSumReportTransformer(service);
            }

            return service;
        }
    }
}