using PhoneDict.Common.Models.Enums;

namespace PhoneDict.Common.Events;

public class CreateReportEvent
{
    public Location Location { get; set; }
    public DateTime ReportRequestedDate { get; set; }
}

