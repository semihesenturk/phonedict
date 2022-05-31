using MediatR;
using PhoneDict.Common;
using PhoneDict.Common.Events;
using PhoneDict.Common.Infrastructure;
using PhoneDict.Common.Models.RequestModels;
using Report.Application.Repositories;

namespace Report.Application.Features.Command;

public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, bool>
{
    #region Variables
    private readonly IReportRepository _reportRepository;
    #endregion

    #region Constructor
    public CreateReportCommandHandler(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }
    #endregion
    public async Task<bool> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        var result = await _reportRepository.CreateReport(new Domain.Models.Report()
        {
            RequestedDate = DateTime.UtcNow,
            ReportPath = "",
            ReportStatus = PhoneDict.Common.Models.Enums.ReportStatus.Preparing
        });



        QueueFactory.SendMessageToExchange(exchangeName: PhoneDictConstants.ReportExchangeName,
            exchangeType: PhoneDictConstants.DefaultExchangeType,
            queueName: PhoneDictConstants.CreateReportQueueName,
            obj: new CreateReportEvent()
            {
                Location = request.Location,
                ReportRequestedDate = DateTime.UtcNow
            });

        return true;
    }
}
