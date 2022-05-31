using AutoMapper;
using MediatR;
using PhoneDict.Common.Models.RequestModels;
using Report.Application.Repositories;

namespace Report.Application.Features.Command;

public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand, bool>
{
    #region Variables
    private readonly IReportRepository _reportRepository;
    #endregion

    #region Constructor
    public UpdateReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
    }
    #endregion

    public async Task<bool> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
    {
        var reportDbData = await _reportRepository.FindAsync(request.Id);

        reportDbData.ReportStatus = request.Status;
        reportDbData.ReportPath = request.ReportPath;

        await _reportRepository.UpdateReport(reportDbData);

        return true;

    }
}
