using MediatR;
using PhoneDict.Common;
using PhoneDict.Common.Events;
using PhoneDict.Common.Infrastructure;
using PhoneDict.Common.Models.RequestModels;

namespace Report.Application.Features.Command;

public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, bool>
{
    #region Variables

    #endregion

    #region Constructor

    #endregion
    public Task<bool> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: PhoneDictConstants.ReportExchangeName,
            exchangeType: PhoneDictConstants.DefaultExchangeType,
            queueName: PhoneDictConstants.CreateReportQueueName,
            obj: new CreateReportEvent()
            {
                Location = request.Location,
                ReportRequestedDate = DateTime.UtcNow
            });

        return Task.FromResult(true);
    }
}
