using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class WithDataReportTransformer : ReportServiceTransformerBase                                   //конкртеный компонент Декоратора
    {
        public WithDataReportTransformer(IDataTransformer reportService) : base(reportService) { }

        public override Report TransformData(DataRow[] data)                                                //оборачиваем метод
        {
            var report = DataTransformer.TransformData(data);

            report.Data = data;

            return report;
        }
    }
}
