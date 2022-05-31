using PhoneDict.Common.Models.Enums;

namespace Report.Domain.Models;

public class Report : BaseEntity
{
    public DateTime RequestedDate { get; set; }
    public ReportStatus ReportStatus { get; set; }
    public string ReportPath { get; set; }
}
