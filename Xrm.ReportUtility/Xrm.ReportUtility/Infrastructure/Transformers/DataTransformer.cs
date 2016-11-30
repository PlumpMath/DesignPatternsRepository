using System.Collections.Generic;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    class DataTransformer : IDataTransformer                        //Конкретный кКомпонент 
    {
        private readonly ReportConfig _config;

        public DataTransformer(ReportConfig config)
        {
            _config = config;    
        }

        public Report TransformData(DataRow[] data)                 //шаблонный метод
        {
            return new Report
            {
                Config = _config,
                Data = new DataRow[0],
                Rows = new List<ReportRow>()
            };
        }
    }
}
