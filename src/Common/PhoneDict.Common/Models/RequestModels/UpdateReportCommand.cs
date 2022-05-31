using MediatR;
using PhoneDict.Common.Models.Enums;

namespace PhoneDict.Common.Models.RequestModels;

public class UpdateReportCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public ReportStatus Status { get; set; }
    public string ReportPath { get; set; }

    public UpdateReportCommand(Guid id, ReportStatus status, string reportPath)
    {
        Id = id;
        Status = status;
        ReportPath = reportPath;
    }
}
